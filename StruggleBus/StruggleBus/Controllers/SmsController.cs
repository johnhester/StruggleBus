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
            string accountSid = "AC85e55decc6115b58491e69da3a83ef01";
            string authToken = "ae609351400d4c90b356767c1002e117";

            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+12567623851");
            var from = new PhoneNumber("+18476076770");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "teeeeeest");

            return Content(message.Sid);
        }

        [HttpGet("sms")]
        public IActionResult SendSms()
        {
            string accountSid = "AC85e55decc6115b58491e69da3a83ef01";
            string authToken = "ae609351400d4c90b356767c1002e117";

            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+12567623851");
            var from = new PhoneNumber("+18476076770");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "are we live?");

            return Content(message.Sid);
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
            
            var response = new MessagingResponse();
            response.Message("It's alive and it's saying ");

            return TwiML(response);
        }

        //POST api/<SmsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SmsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SmsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
