using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StruggleBus.Models;
using StruggleBus.Repositories;
using Twilio;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;

namespace StruggleBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : TwilioController
    {
        private readonly IMessageRepository _messageRepo;
        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepo = messageRepository;
        }

        [HttpGet("{userId}")]
        public IActionResult getUserMessages(int userId)
        {
            List<UserMessage> messages = _messageRepo.getUserMessages(userId);

            if (messages == null)
            {
                return NotFound();
            }

            return Ok(messages);
        }

        [HttpDelete("{messageSid}")]
        public IActionResult deleteUserMessage(string messageSid)
        {
            //grab twilio authentication environment variables
            var TwilioSID = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            var TwilioAuthToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(TwilioSID, TwilioAuthToken);

            MessageResource.Delete(pathSid: messageSid);

            return NoContent();
        }
    }
}
