using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bytesAmount;
            byte[] incomeBuffer = new byte[1024];
            byte[] outcomeBuffer;
            string zodiacName;
            Socket acceptor = null;
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                listener.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9222));
                listener.Listen(1000);

                while (true)
                {
                    Console.WriteLine(" Waiting for request...");

                    acceptor = listener.Accept();
                    bytesAmount = acceptor.Receive(incomeBuffer);
                    zodiacName = Encoding.UTF8.GetString(incomeBuffer, 0, bytesAmount);

                    Console.WriteLine($" {DateTime.Now}: {zodiacName}\n");

                    if (zodiacName != "STOP-SERVER-1448")
                    {
                        outcomeBuffer = Encoding.UTF8.GetBytes(new ConnectToDB("connectToHoroscopesDB").GetPrediction(zodiacName));
                        acceptor.Send(outcomeBuffer);
                    }

                    acceptor.Shutdown(SocketShutdown.Both);
                    acceptor.Close();

                    if (zodiacName == "STOP-SERVER-1448") break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Error: " + ex.Message);
            }
            finally
            {
                listener?.Close();
                Console.WriteLine(" Server has been stoped!");
            }
        }
    }
}
