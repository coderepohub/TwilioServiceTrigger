using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using TwillioServices.Interfaces;

namespace TwillioServices.TwillioLogics
{
    public class TwillioLogic : ITwillioLogic
    {
        static readonly string recipentNumber = ConfigurationManager.AppSettings["RecipentNumber"].ToString();
        static readonly string senderNumber = ConfigurationManager.AppSettings["SenderNumber"].ToString();
        static readonly string accountsid = ConfigurationManager.AppSettings["AccountSid"].ToString();
        static readonly string authtoken = ConfigurationManager.AppSettings["AuthToken"].ToString();
        public bool SendMessageToSender( string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                var accountSid = accountsid;
                var authToken = authtoken;
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber(recipentNumber));
                messageOptions.From = new PhoneNumber(senderNumber);
                messageOptions.Body = message;

                var messageResponse = MessageResource.Create(messageOptions);
               
            }
            return true;
        }
    }
}
