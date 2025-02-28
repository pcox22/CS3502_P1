using System;
using System.Threading;
using System.Transactions;

namespace OS_SubwaySystem {
	class Driver
	{
		public static Mutex mutex = new Mutex();
		// Used in later phases
		// public static Mutex mutwoex = new Mutex();

		static void Main(string[] args)
		{
			Random random = new Random();
			List<BTrain> Subway = new List<BTrain>();
			List<Thread> depThreads = new List<Thread>();
			List<Thread> maintThreads = new List<Thread>();



			for (int i = 0; i < 10; i++)
			{
				// Randomly generate station numbers and assign new Train objects to Subway List
				BTrain bTrain = new BTrain(random.Next(4));
				Subway.Add(bTrain);
				
				Thread newThread = new Thread(new ThreadStart(Subway[i].Depart));
				depThreads.Add(newThread);

				Thread newerThread = new Thread(new ThreadStart(Subway[i].Maintenance));
				maintThreads.Add(newerThread);

			}

			// Initialize all threads: Two different sets of two different tasks will run, each requiring lock aquisition
			foreach (Thread thread in depThreads)
			{
				thread.Start();
            }

			foreach (Thread thread in maintThreads)
			{
				thread.Start();
			}

			while (threadsAlive(maintThreads, depThreads))
			{
				continue;
			}

			Console.WriteLine("All operations completed - Total Successful: " + BTrain.getTotalOperations());
			
		}

		public static bool threadsAlive(List<Thread> maintThreads, List<Thread> depThreads)
		{
			foreach (Thread thread in maintThreads)
			{
				if (thread.IsAlive){return true;}
			}

			foreach (Thread thread in depThreads)
			{
				if (thread.IsAlive){return true;}
			}
			
			return false;
		}

	}
}

