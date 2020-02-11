using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class ClientThread
    {
        Thread _thread;

        int _id;
        string _server;

        public ClientThread(int id, string server)
        {
            _id = id; _server = server;
            _thread = new Thread(new ThreadStart(Run));
        }

        private void Run()
        {
            HttpClient _client = new HttpClient();
            

            for (int i=0; i < 10; i++)
            {
                Console.WriteLine("" + _id + "started on "  + (i+1) + ": " + DateTime.Now);
                Task<HttpResponseMessage> response = _client.GetAsync(_server);

                String result = (response.Result.Content.ReadAsStringAsync().Result);

                Console.WriteLine("" + _id + ": " + result);

            }
        }

        public void Start() => _thread.Start();

        public void Join() => _thread.Join();

        public bool IsAlive => _thread.IsAlive;

    }
}
