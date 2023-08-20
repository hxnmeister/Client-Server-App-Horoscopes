using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bytesAmount;
            byte[] outcomeBuffer;
			byte[] incomeBuffer = new byte[1024];
			string zodiacName;
			string prediction;
            Socket client;

			try
			{
				do
				{
                    Console.Clear();
                    Console.Write("Enter your zodiac: ");
                    zodiacName = Console.ReadLine();
                    outcomeBuffer = Encoding.UTF8.GetBytes(zodiacName);

                    client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                    client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9222));
                    client.Send(outcomeBuffer);

                    bytesAmount = client.Receive(incomeBuffer);
                    prediction = Encoding.UTF8.GetString(incomeBuffer, 0, bytesAmount);

                    Console.WriteLine($"\n Your prediction: {prediction}");

                    client.Shutdown(SocketShutdown.Both);
                    client.Close();

                    if (zodiacName == "STOP-SERVER-1488") break;

                    Console.Write("\n Press 'N' to exit, or any key to continue: ");
                    
                } while (char.ToUpper(Console.ReadKey().KeyChar) != 'N');
			}
			catch (Exception ex)
			{
                Console.WriteLine("\n Error: " + ex.Message);
            }
            finally
            {
                
                Console.WriteLine("\n Client has been stoped!");
            }
        }
    }
}
