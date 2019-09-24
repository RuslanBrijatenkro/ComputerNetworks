using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab1
{
	class Server
	{
		void MessageListener(NetworkStream stream)
		{
			List<byte> buffer = new List<byte>();
			Console.WriteLine("Message Listener: start");
			while(true)
			{
				if(stream.DataAvailable)
				{
					while (stream.DataAvailable)
					{
						buffer.Add((byte)stream.ReadByte());
					}
					Console.WriteLine("Client:" + Encoding.ASCII.GetString(buffer.ToArray()));
					buffer.Clear();
				}
				Thread.Sleep(50);
			}
		}
		public void Run()
		{

			TcpListener tcpListener = new TcpListener(IPAddress.Parse("192.168.0.145"),13000);
			TcpClient client;
			NetworkStream stream;
			try
			{
				tcpListener.Start();
				Console.WriteLine("Server started");
				while(true)
				{
					client = tcpListener.AcceptTcpClient();
					stream = client.GetStream();
					new Thread(()=>MessageListener(stream)).Start();
					//string message = "Ok";
					//byte[] buffer = Encoding.ASCII.GetBytes(message);
					//stream.Write(buffer,0,buffer.Length);
				}
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
