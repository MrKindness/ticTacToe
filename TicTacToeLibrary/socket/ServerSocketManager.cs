using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TicTacToeLibrary.socket
{
    public class ServerSocketManager
    {
        string address = "127.0.0.1";
        int port = 80;
        Task? workTask;
        Task? listenTask;
        Socket? server;
        Socket? client;

        public ConectionEstablished? conectionEstablishedEvent;
        public ConnectionLost? connectionLostEvent;
        public MessageReceived? messageReceivedEvent;

        public ServerSocketManager()
        {
        }

        public void start()
        {
            workTask = Task.Factory.StartNew(() =>
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(new IPEndPoint(IPAddress.Parse(address), port));
                server.Listen(2);
                client = server.Accept();

                listenTask = Task.Factory.StartNew(listen);
                conectionEstablishedEvent?.Invoke();
            });
        }

        private void listen()
        {
            while (true)
            {
                byte[] responseData = new byte[40];
                int realAmount = 0;
                try
                {
                    realAmount = client.Receive(responseData);
                }
                catch
                {
                    server.Close();
                    start();
                    connectionLostEvent?.Invoke();
                    return;
                }

                byte[] bytes = new byte[realAmount];
                for (int i = 0; i < realAmount; i++)
                {
                    bytes[i] = responseData[i];
                }
                string commandString = Encoding.UTF8.GetString(bytes);
                Message message = JsonSerializer.Deserialize<Message>(commandString);
                messageReceivedEvent?.Invoke(message);
            }
        }

        public bool send(Message message)
        {
            string result = JsonSerializer.Serialize(message);
            byte[] bytes = Encoding.UTF8.GetBytes(result);
            try
            {
                client.Send(bytes);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public delegate void ConectionEstablished();
        public delegate void ConnectionLost();
        public delegate void MessageReceived(Message message);
    }
}
