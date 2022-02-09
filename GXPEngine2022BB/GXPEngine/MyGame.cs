using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using TiledMapParser;
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game
{
	ManagerAndStuff.Difficulty difficultySetting;

	PlayerKeysCombo playerOne;
	PlayerKeysCombo playerTwo;
	public MyGame() : base(Settings.Width, Settings.Height, Settings.FullScreen, true, Settings.ScreenResolutionX, Settings.ScreenResolutionY)
	{
		playerOne = new PlayerKeysCombo(ManagerAndStuff.Player.P1);
		playerOne.SetKeys(Settings.P1Left, Settings.P1Up, Settings.P1Right);
		AddChild(playerOne);

		playerTwo = new PlayerKeysCombo(ManagerAndStuff.Player.P2);
		playerTwo.SetKeys(Settings.P2Left, Settings.P2Up, Settings.P2Right);
		AddChild(playerTwo);

	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		
	}

	static void Main()
	{
		Settings.Load();
		if (Settings.FullScreen)
		{
			try
			{
				new MyGame().Start();
			}
			catch (Exception error)
			{
				Console.WriteLine("Error: {0}\n terminating game.", error.Message);
			}
		}
		else
		{
			new MyGame().Start();
		}
	}
}