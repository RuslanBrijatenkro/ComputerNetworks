using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter:");
			int key = Convert.ToInt32(Console.ReadLine());
			switch (key)
			{
				case 1:
					Server server = new Server();
					server.Run();
					break;
				case 2:
					Client client = new Client("192.168.0.145");
					client.Run();
					break;
			}
			Console.ReadLine();
		}
	}

}
