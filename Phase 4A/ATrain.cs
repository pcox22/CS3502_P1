using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OS_SubwaySystem
{
	public class ATrain
	{
		private int id = 0;
		private static int nextID = 0;
		private int route = 0;
		private int stationNumber;
		private static bool tools;
		private bool serviced = false;
		
		// Default Constructor; never used
		public ATrain() 
		{
			id = nextID;
			nextID++;
			stationNumber = 0;
			tools = true;
			serviced = false;
		}

		// Overloaded to take in random station numbers
		public ATrain(int station)
		{
			id = nextID;
			nextID++;
			stationNumber = station;
			tools = true;
			serviced = false;
		}

		public int getId() { return id; }
		public int getStation() { return stationNumber;}
		public void Depart()
		{
			
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

				Console.WriteLine("Train has arrived at Station " + stationNumber);

        }

		public void Maintenance() {
			
			tools = false;
			Console.WriteLine("Train currently undergoing maintenance...");

			Thread.Sleep(700);

				Console.WriteLine("Train back in Service");
				serviced = true;
				tools = true;
			
		}
	

		public bool isServiced()
		{
			return serviced;
		}


	}
}
