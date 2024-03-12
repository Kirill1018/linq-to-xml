using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Linq_to_xml
{
    internal class Program
    {
        static void Main(string[] args) => new Program().Code();
        public void Code()
        {
            XElement messages = XElement.Load("messages.xml");
            XElement users = XElement.Load("users.xml");
            IEnumerable<XElement> message_elements = messages.Elements();
            IEnumerable<XElement> user_elements = users.Elements();
            foreach (XElement message in message_elements)
            {
                DateTime time = (DateTime)message.Element("datetime");
                int user_id = (int)message.Element("userId");
                string text = (string)message.Element("text");
                XElement message_user = user_elements
                    .Where(user => (int)user.Attribute("id") == user_id)
                    .First();
                Console.WriteLine($@"{time} {(string)message_user.Element("firstName")} {(string)message_user.Element("lastName")}: {text}");
            }
        }
    }
}