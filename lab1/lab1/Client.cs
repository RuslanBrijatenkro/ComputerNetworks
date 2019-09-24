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
	class Client
	{
		List<Task> tasks;
		NetworkStream stream;
		TcpClient client;
		public Client(TcpClient client)
		{
			this.client = client;
		}
		public Client(string ip)
		{
			client = new TcpClient(ip,13000);
		}
		void SendMessage()
		{
			Console.WriteLine("SendMessageAsync: start");
			try
			{
				while (true)
				{
					Console.WriteLine("Enter your message:");
					string message = Console.ReadLine();
					byte[] buffer = Encoding.ASCII.GetBytes(message);
					stream.Flush();
					stream.Write(buffer,0,buffer.Length);
				}
			}
			catch(Exception e)
			{
				throw e;
			}

		}
		public void Run()
		{
			tasks = new List<Task>();
			stream = client.GetStream();
			try
			{
				Console.WriteLine("Run: start");
				tasks.Add(Task.Run((Action)SendMessage));
				Task.WaitAll(tasks.ToArray());
				Console.WriteLine("SendMessageAsync: end");
				//tasks.Add(Task.Factory.StartNew(SendMessageAsync));
				//Task.WaitAll(tasks.ToArray());
				Console.WriteLine("Run: end");
				Console.ReadKey();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (stream != null)
					stream.Close();
				if (client != null)
					client.Close();
			}
		}
	}
}
