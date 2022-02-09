using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using TiledMapParser;
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game
{
	public enum Player
    {
		P1,
		P2
    }

	PlayerKeysCombo playerOne;
	PlayerKeysCombo playerTwo;
	public MyGame() : base(800, 600, false)
	{
		playerOne = new PlayerKeysCombo(Player.P1);
		playerOne.SetKeys(65, 87, 68);

		playerTwo = new PlayerKeysCombo(Player.P2);
		playerTwo.SetKeys(285, 283, 286);
		AddChild(playerOne);
		AddChild(playerTwo);

	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		
		
		
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}