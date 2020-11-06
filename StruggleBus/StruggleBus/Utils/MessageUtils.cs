using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio.AspNet.Core;
using Twilio.TwiML;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using StruggleBus.Models;
using Microsoft.AspNetCore.Mvc;

namespace StruggleBus.Utils
{
    public class MessageUtils
    {
        //a utility for extra sms responses
        //help response


        //get random user from currently existing users
        public static User getRandomUser(List<User> users)
        {
            var random = new Random();
            int index = random.Next(users.Count);

            return users[index];
        }

    }
}
