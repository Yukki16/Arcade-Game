using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using TiledMapParser;
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
public class MyGame : Game
{
	SceneManager sceneManager;

	public MyGame() : base(Settings.Width, Settings.Height, Settings.FullScreen, true, Settings.ScreenResolutionX, Settings.ScreenResolutionY)
	{
		sceneManager = new SceneManager();
		sceneManager.sfx.LoadSongs();
		sceneManager.LoadScene(SceneManager.Scenes.GameScene);
		AddChild(sceneManager);
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