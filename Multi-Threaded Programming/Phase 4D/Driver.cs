using System;
using System.Threading;
using System.Transactions;

namespace OS_SubwaySystem {
	class Driver
	{
		public static Mutex mutex = new Mutex();
		public static Mutex mutwoex = new Mutex();
		public static bool deadlocked = false;

		static void Main(string[] args)
		{
			Random random = new Random();
			List<MasterTrain> Subway = new List<MasterTrain>();
			List<Thread> depThreads = new List<Thread>();
			List<Thread> maintThreads = new List<Thread>();



			for (int i = 0; i < 10; i++)
			{
				// Randomly generate station numbers and assign new Train objects to Subway List
				MasterTrain cTrain = new MasterTrain(random.Next(4));
				Subway.Add(cTrain);
				
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
			
			int TO = 30000;
			DateTime start = DateTime.Now;
			while ((DateTime.Now - start).TotalMilliseconds < TO)
			{
				if (!threadsAlive(maintThreads, depThreads))
				{
					deadlocked = false;
					break;
				}

				deadlocked = true;
			}
		

			if (!deadlocked)
			{
				Console.WriteLine("All operations completed - Total Successful: " + MasterTrain.getTotalOperations());
			}
			else
			{
				Console.WriteLine("Subway System seems to be experiencing a deadlock. Please exit the Program.");
			}
			
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

