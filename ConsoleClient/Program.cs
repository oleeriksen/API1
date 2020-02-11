using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Client!");
            Console.ReadKey();
            CallServer();
        }

        private static void CallServer()
        {
            List<ClientThread> ct = new List<ClientThread>();

            for (int i = 1; i <= 3; i++)
                ct.Add(new ClientThread(i, "https://localhost:5001/7"));
                
            Console.WriteLine("Clients created");

            foreach (ClientThread c in ct)
                    c.Start();

            Console.WriteLine("Clients started");

            foreach (ClientThread c in ct)
                    c.Join();
        }
    }
}
