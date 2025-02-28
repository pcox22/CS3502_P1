using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OS_SubwaySystem
{
	public class CTrain
	{
		private int id = 0;
		private static int nextID = 0;
		private int route = 0;
		private int stationNumber;
		private static bool tools;
		private bool serviced = false;
		
		// This integer will demonstrate the "Shared Resource" by incrementing each time either operation is performed.
		// Note: Will only increment if the operation was completed successfully.
		private static int totalOperations;
		
		// Default Constructor; never used
		public CTrain() 
		{
			id = nextID;
			nextID++;
			stationNumber = 0;
			tools = true;
			serviced = false;
		}

		// Overloaded to take in random station numbers
		public CTrain(int station)
		{
			id = nextID;
			nextID++;
			stationNumber = station;
			tools = true;
			serviced = false;
		}

		public int getId() { return id; }
		public int getStation() { return stationNumber;}
		public static int getTotalOperations() { return totalOperations; }
		public void Depart()
		{
			if (Driver.mutex.WaitOne())
			{
				totalOperations++;
				Console.WriteLine("Train " + id + " Departing... Standby While Locomotive Reaches Speed.");
				switch (stationNumber)
				{
					case 0:
						Thread.Sleep(1000);
						stationNumber++;
						break;

					case 1:
						Thread.Sleep(1300);
						stationNumber++;
						break;

					case 2:
						Thread.Sleep(900);
						stationNumber++;
						break;

					case 3:
						Thread.Sleep(1500);
						stationNumber = 0;
						break;
					default:
						break;
				}
				if (Driver.mutwoex.WaitOne())
				{
					Console.WriteLine("Train has arrived at Station " + stationNumber);
					Driver.mutwoex.ReleaseMutex();
				}
				else
				{
                    Console.WriteLine("Train broke down on route to Station " + stationNumber);
                }
				Driver.mutex.ReleaseMutex();
			}
			else
			{
                Console.WriteLine("Train is unable to leave Station.");
            }



        }

		public void Maintenance() {

			if (Driver.mutwoex.WaitOne())
			{
				tools = false;
				Console.WriteLine("Train currently undergoing maintenance...");

				Thread.Sleep(700);

				if (Driver.mutex.WaitOne())
				{

					Console.WriteLine("Train back in Service");
					serviced = true;
					tools = true;
					totalOperations++;
					Driver.mutex.ReleaseMutex();
				}
				else
				{
                    Console.WriteLine("An advanced repair is needed.");
                }
				Driver.mutwoex.ReleaseMutex();
			}
			else
			{
                Console.WriteLine("The required tools are unavailable; this maintenance cannot be performed at this time.");
            }

		}

		public bool isServiced()
		{
			return serviced;
		}

		public void Deadlocked()
		{
			
		}


	}
}
