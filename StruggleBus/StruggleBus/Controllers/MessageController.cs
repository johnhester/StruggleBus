using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;

namespace StruggleBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : TwilioController
    {
        [HttpGet("{phone}")]
        public IActionResult getUserMessages(string phone)
        {
            //grab twilio authentication environment variables
            var TwilioSID = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            var TwilioAuthToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(TwilioSID, TwilioAuthToken);

            var messages = MessageResource.Read(from: new Twilio.Types.PhoneNumber(phone));

            if (messages == null)
            {
                return NotFound();
            }

            foreach(var item in messages)
            {
                Console.WriteLine(item);
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
