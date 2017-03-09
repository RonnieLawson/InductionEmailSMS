using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenPop.Mime;
using OpenPop.Pop3;


namespace EmailSMS
{
    class EmailSMS
    {
        private readonly string _username;
        private string SMTPServer = "ems.esendex.net";

        public EmailSMS(string username)
        {
            _username = username;
        }

        public List<Message> GetMessages(string password)
        {
            using (Pop3Client client = new Pop3Client())
            {
                // Connect to the server
                client.Connect(SMTPServer, 110, false);

                // Authenticate ourselves towards the server
                client.Authenticate(_username, password);

                // Get the number of messages in the inbox
                int messageCount = client.GetMessageCount();

                // We want to download all messages
                List<Message> allMessages = new List<Message>(messageCount);

                // Messages are numbered in the interval: [1, messageCount]
                // Ergo: message numbers are 1-based.
                // Most servers give the latest message the highest number

                for (int i = messageCount; i > 0; i--)
                {
                        allMessages.Add(client.GetMessage(i));
                }

                // Now return the fetched messages
                return allMessages;
            }
        }
    }
}
