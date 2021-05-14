using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Client
{
    public class MyCallback : Proxy.IChatServiceCallback
    {
        public void RecieveMessage(string user, string message)
        {
            Console.WriteLine("{0}: {1}", user, message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InstanceContext context = new InstanceContext(new MyCallback());
            Proxy.ChatServiceClient server = new Proxy.ChatServiceClient(context);

            Console.Write("Enter Username: ");
            var username = Console.ReadLine().Trim();
            server.Join(username);


            Console.WriteLine("\nEnter message: ");
            Console.WriteLine("Press 'Q' to Exit.");
            var message = Console.ReadLine().Trim();

            while(message.ToUpper() != "Q")
            {
                if(!string.IsNullOrEmpty(message))
                    server.SendMesssage(message);

                message = Console.ReadLine();
            }
        }
    }
}
