using System;

namespace Worm
{
	public enum Colour { None ,Red, Yellow, Blue};
	public class Wormik
	{
		private uint head;
		private uint tail;
		private uint length;
		private uint routeLength;
		private Colour colour;
		private uint speed;
		private bool moveing;


		public Wormik(uint length, uint routeLength, Colour colour, uint speed = 1)
		{
			this.head = 0;
			this.tail = routeLength - length;
			this.length = length;
			this.routeLength = routeLength;
			this.colour = colour;
			this.speed = speed;
			this.moveing = false;
		}

		public uint GetHead()
        {
			return this.head;
        }

		public uint GetTail()
        {
			return this.tail;
        }

		public uint GetLength()
        {
			return this.length;
        }

		public uint GetSpeed()
        {
			return this.speed;
        }

		public void SetSpeed(uint speed)
        {
			this.speed = speed;
        }

		public void Start()
        {
			this.moveing = true;
        }

		public void Stop()
        {
			this.moveing = false;
        }
		
		public bool IsMoveing()
        {
			return this.moveing;
        }
		public void MoveOneStep()
        {
			this.head = ++this.head % this.routeLength;
			this.tail = ++this.tail % this.routeLength;
        }

	}

}
