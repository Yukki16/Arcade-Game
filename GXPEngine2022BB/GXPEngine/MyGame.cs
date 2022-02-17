using GXPEngine;                                // GXPEngine contains the engine
using System;									// System contains a lot of default C# libraries 

public class MyGame : Game
{

    /// </info>
    /// I have a lot of code repetition from time to time :<, maybe you can take care of it, or I ll do it next week
    /// </info>
    SceneManager sceneManager;


    public MyGame() : base(Settings.Width, Settings.Height, Settings.FullScreen, true, Settings.ScreenResolutionX, Settings.ScreenResolutionY)
    {
        sceneManager = new SceneManager();
        sceneManager.sfx.LoadSongs();
        sceneManager.LoadScene(SceneManager.Scenes.MainMenu, SFX.Songs.MenuSong);
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