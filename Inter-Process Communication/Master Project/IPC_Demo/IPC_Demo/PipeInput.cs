using System;
using System.IO;
using System.IO.Pipes;


namespace IPC_Demo_In
{

	class PipeInput
	{
		static void Main()
		{
			Console.WriteLine("[Initialized]");
			using (NamedPipeServerStream pI = new NamedPipeServerStream("MyPipeLine", PipeDirection.InOut))
			{
				Console.WriteLine("Awaiting Input...");
				pI.WaitForConnection();
				Console.WriteLine("Connection Established.");

				using (StreamReader input = new StreamReader(pI))
				{
					// Note: Attempted to complete section w/o following string, realized that input.ReadLine() will lose the data when read.
					string msgFromPipeOut;
					while ((msgFromPipeOut = input.ReadLine()) != null)
					{
						Console.WriteLine("Input Received: " + msgFromPipeOut);
					}
				}
			}
		}
	}
}