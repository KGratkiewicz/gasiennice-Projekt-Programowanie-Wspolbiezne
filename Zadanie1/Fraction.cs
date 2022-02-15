using System;
using System.Threading;
using Worm;
public class Fraction
{
	private Wormik redWormik;
	private Wormik yellowWormik;
	private Wormik blueWormik;
	private SemaphoreSlim sharingBlueRed;
	private SemaphoreSlim sharingRedYellow;
	private SemaphoreSlim sharingYellowBlue;
	private SemaphoreSlim fractionLimit;

	public Fraction()
	{
		this.redWormik = new Wormik(9, 30, Colour.Red, 5);
		this.blueWormik = new Wormik(7, 28, Colour.Blue, 5);
		this.yellowWormik = new Wormik(5, 26, Colour.Red, 5);

		this.sharingBlueRed = new SemaphoreSlim(1, 1);
		this.sharingRedYellow = new SemaphoreSlim(1, 1);
		this.sharingYellowBlue = new SemaphoreSlim(1, 1);

		this.fractionLimit = new SemaphoreSlim(2, 2);
	}

	public Wormik GetWorm(Worm.Colour color)
    {
        switch (color)
        {
			case Colour.Red:
				return this.redWormik;
			case Colour.Blue:
				return this.blueWormik;
			case Colour.Yellow:
				return this.yellowWormik;
			default:
				return null;
        }
    }


	public void StartSimulation()
	{
		Thread red = new Thread(MoveRed);
		red.Start();

		Thread blue = new Thread(MoveBlue);
		blue.Start();

		Thread yellow = new Thread(MoveYellow);
		yellow.Start();

	}

	public Wormik GetRedWormik()
	{
		return this.redWormik;
	}

	public Wormik GetBlueWormik()
	{
		return this.blueWormik;
	}

	public Wormik GetYellowWormik()
	{
		return this.yellowWormik;
	}

	private void MoveRed()
    {
		int delay;

		while (true)
        {
			delay = 1000 / (int) this.redWormik.GetSpeed();
			this.redWormik.MoveOneStep();

			if(this.redWormik.GetHead() == 3)
            {
				this.fractionLimit.Wait();
				this.sharingRedYellow.Wait();
            }

			if (this.redWormik.GetHead() == 6)
			{
				this.sharingBlueRed.Wait();
			}

			if (this.redWormik.GetTail() == 8)
			{
				this.sharingRedYellow.Release();
			}

			if (this.redWormik.GetTail() == 17)
			{
				this.sharingBlueRed.Release();
				this.fractionLimit.Release();
			}

			Thread.Sleep(delay);
        }

    }

	private void MoveBlue()
	{
		int delay;

		while (true)
		{
			delay = 1000 / (int)this.blueWormik.GetSpeed();
			this.blueWormik.MoveOneStep();

			if (this.blueWormik.GetHead() == 6)
			{
				this.fractionLimit.Wait();
				this.sharingBlueRed.Wait();
			}

			if (this.blueWormik.GetHead() == 15)
			{
				this.sharingYellowBlue.Wait();
			}

			if (this.blueWormik.GetTail() == 17)
			{
				this.sharingBlueRed.Release();
			}

			if (this.blueWormik.GetTail() == 20)
			{
				this.sharingYellowBlue.Release();
				this.fractionLimit.Release();
			}

			Thread.Sleep(delay);
		}

	}

	private void MoveYellow()
	{
		int delay;

		while (true)
		{
			delay = 1000 / (int)this.yellowWormik.GetSpeed();
			this.yellowWormik.MoveOneStep();

			if (this.yellowWormik.GetHead() == 2)
			{
				this.fractionLimit.Wait();
				this.sharingYellowBlue.Wait();
			}

			if (this.yellowWormik.GetHead() == 5)
			{
				this.sharingRedYellow.Wait();
			}

			if (this.yellowWormik.GetTail() == 7)
			{
				this.sharingYellowBlue.Release();
			}

			if (this.yellowWormik.GetTail() == 10)
			{
				this.sharingRedYellow.Release();
				this.fractionLimit.Release();
			}

			Thread.Sleep(delay);
		}

	}
}
