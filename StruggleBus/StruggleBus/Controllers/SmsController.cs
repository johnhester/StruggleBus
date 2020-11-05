using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Core;
using Twilio.AspNet.Common;
using Twilio.TwiML;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.AspNetCore.SignalR.Protocol;
using StruggleBus.Repositories;
using Microsoft.AspNetCore.Http;
using StruggleBus.Models;
using System.Security.Claims;
using StruggleBus.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StruggleBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : TwilioController
    {
        private readonly IUserRepository _userRepo;

        public SmsController(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        // GET: api/<SmsController>
        [HttpGet]
        public IActionResult Get()
        {
            return NoContent();
        }


        // GET api/<SmsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("receivesms")]
        public IActionResult ReceiveSms()
        {
            // get text body
            string requestBody = Request.Form["Body"];            
            // get user phone
            string inboundPhone = Request.Form["From"];
            // create new response
            var response = new MessagingResponse();

            var user = _userRepo.GetByPhoneNumber(inboundPhone);
            user.ContactMessage = requestBody;


            if (user == null)
            {
                response.Message("Sorry, but we don't have a user in our database with this number. If you are a user please check your Struggle Bus account.");
                return TwiML(response);
            }

            switch(requestBody.ToUpper())
            {
                case "TEST":
                    
                    response.Message("Testing...1...2...3...");
                    return TwiML(response);
                case "OPTIONS":

                    response.Message(@"Thanks for asking.
                        1) Send TEST any time you want to test connectivity.
                        2) Send OPTIONS to get this menu.
                        3) Send anything else to get a check in.");
                    return TwiML(response); ;
                default:
                    response.Message($"Thanks for reaching out {user.FirstName}. You've been heard, and we're passing along the word.");
                    SendSms(user);
                    return TwiML(response);
            }


        }


        //POST api/<SmsController>
        [Route("sendsms")]
        public IActionResult SendSms(User user)
        {

            List<User> users = _userRepo.GetAllButCurrent(user.Id);
            var contact = MessageUtils.getRandomUser(users);

            //grab twilio authentication variables from env.Local
            var TwilioSID = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            var TwilioAuthToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(TwilioSID, TwilioAuthToken);

            var to = new PhoneNumber(contact.UserPhone);
            var from = new PhoneNumber("+18476076770");

            string body = $"Hi {contact.FirstName}! It's Struggle Bus. {user.FirstName} is having a tough time. Could you check in on them at {user.UserPhone}? Their outreach message was: '{user.ContactMessage}'";

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: body);

            return Content(message.Sid);
        }

        // DELETE api/<SmsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private User GetCurrentUser()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userRepo.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
