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
    public class ClientSocketManager
    {
        string address = "127.0.0.1";
        int port = 80;
        Task? workTask;
        Socket? socket;

        public ConectionEstablished? conectionEstablishedEvent;
        public ConnectionLost? connectionLostEvent;
        public MessageReceived? messageReceivedEvent;

        public ClientSocketManager() { }

        public void start()
        {
            workTask = Task.Factory.StartNew(() =>
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                while (!socket.Connected)
                {
                    try
                    {
                        socket.Connect(address, port);
                    }
                    catch (Exception ex)
                    {
                        Thread.Sleep(500);
                    }
                }
                workTask = Task.Factory.StartNew(listen);
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
                    realAmount = socket.Receive(responseData);
                }
                catch
                {
                    socket.Close();
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
                socket.Send(bytes);
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
