using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;

namespace IPC_Demo_Out
{
	class PipeOutput
	{
		static void Main()
		{
			using (NamedPipeClientStream pO = new NamedPipeClientStream(".", "MyPipeLine", PipeDirection.Out))
			{
				pO.Connect();
				Console.WriteLine("Established Connection to: MyPipeLine");

				using (StreamWriter writer = new StreamWriter(pO))
				{
					writer.AutoFlush = true;
					while (true)
					{
						Console.Write("Enter Message to send through PipeLine: ");
						string msg = Console.ReadLine();
						writer.WriteLine(msg);
						System.Threading.Thread.Sleep(1000);
					}
				}
			}
		}
	}
}
