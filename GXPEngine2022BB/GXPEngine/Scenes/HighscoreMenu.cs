using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace GXPEngine.Scenes
{
    class HighscoreMenu : Scene
    {
		SceneManager sceneManager;
		EasyDraw easyDraw;

		int Song_1Score = 0;
		int Song_2Score = 0;
		int Song_3Score = 0;

		Font minecraftFont;
		public HighscoreMenu(SceneManager sceneManager)
        {
			minecraftFont = Utils.LoadFont("Fonts/MINECRAFT.ttf", 40);

			this.sceneManager = sceneManager;
            background = new Sprite("Art/Backgrounds/beat_it_background_final_big.png");
            background.SetXY(0, 0);
            this.AddChild(background);

			buttons = new Button[1];

			buttons[0] = new Button("Art/Buttons/back_button.png", this.sceneManager, SceneManager.Scenes.MainMenu, SFX.Songs.MenuSong, true);
			buttons[0].SetOrigin(buttons[0].width / 2, buttons[0].height / 2);
			buttons[0].SetXY(game.width / 2, 4 * game.height / 5);
			AddChild(buttons[0]);

			LoadData("Highscore.txt");

			easyDraw = new EasyDraw(Settings.Width, Settings.Height, false);
			easyDraw.TextAlign(CenterMode.Center, CenterMode.Center);
			easyDraw.TextFont(minecraftFont);

			easyDraw.Text("Song 1 highscore:", game.width / 4, game.height / 5, false);
			easyDraw.Text("Song 2 highscore:", game.width / 4, 2* game.height / 5, false);
			easyDraw.Text("Song 3 highscore:", game.width / 4, 3 * game.height / 5, false);

			easyDraw.Text(Song_1Score.ToString(), 2 * game.width / 3, game.height / 5, false);
			easyDraw.Text(Song_2Score.ToString(), 2 * game.width / 3, 2 * game.height / 5, false);
			easyDraw.Text(Song_3Score.ToString(), 2 * game.width / 3, 3 * game.height / 5, false);

			AddChild(easyDraw);
		}
		void LoadData(string filename)
		{
			if (!File.Exists(filename))
			{
				Console.WriteLine("No save file found!");
				return;
			}
			try
			{
				// StreamReader: For reading a text file - requires System.IO namespace:
				// Note: the "using" block ensures that resources are released (reader.Dispose is called) when an exception occurs
				using (StreamReader reader = new StreamReader(filename))
				{

					string line = reader.ReadLine();
					while (line != null)
					{
						// Here's a demo of different string parsing methods:

						// Find the position of the first '=' symbol (-1 if doesn't exist)
						int splitPos = line.IndexOf('=');
						if (splitPos >= 0)
						{
							// Everything before the '=' symbol:
							string key = line.Substring(0, splitPos);
							// Everything after the '=' symbol:
							string value = line.Substring(splitPos + 1);

							// Split value up for every comma:
							//string[] numbers = value.Split(',');

							switch (key)
							{
								case "song_1":			
										Song_1Score = int.Parse(value);
									break;

								case "song_2":								
										Song_2Score = int.Parse(value);
									break;

								case "song_3":  
										Song_3Score = int.Parse(value);
									break;
                            }
						}
						line = reader.ReadLine();
					}
					reader.Close();

					Console.WriteLine("Load from {0} successful ", filename);
				}
			}
			catch (Exception error)
			{
				Console.WriteLine("Error while reading save file: {0}", error.Message);
			}
		}

		public void SaveData(string filename, int highscore, SFX.Songs songToChangeScore)
		{
			try
			{
				// StreamWriter: For writing to a text file - requires System.IO namespace:
				// Note: the "using" block ensures that resources are released (writer.Dispose is called) when an exception occurs
				using (StreamWriter writer = new StreamWriter(filename))
				{
					bool wrotesomething = false;

					if(songToChangeScore == SFX.Songs.Song1 && Song_1Score < highscore)
                    {
						writer.WriteLine("song_1=" + highscore);
						writer.WriteLine("song_2=" + Song_2Score);
						writer.WriteLine("song_3=" + Song_3Score);
						wrotesomething = true;
					}
					
					if(songToChangeScore == SFX.Songs.Song2 && Song_2Score < highscore)
                    {
						writer.WriteLine("song_1=" + Song_1Score);
						writer.WriteLine("song_2=" + highscore);
						writer.WriteLine("song_3=" + Song_3Score);
						wrotesomething = true;
					}
					
					if(songToChangeScore == SFX.Songs.Song3 && Song_3Score < highscore)
                    {
						writer.WriteLine("song_1=" + Song_1Score);
						writer.WriteLine("song_2=" + Song_2Score);
						writer.WriteLine("song_3=" + highscore);
						wrotesomething = true;
					}

					if(!wrotesomething)
                    {
						writer.WriteLine("song_1=" + Song_1Score);
						writer.WriteLine("song_2=" + Song_2Score);
						writer.WriteLine("song_3=" + Song_3Score);
					}
					writer.Close();

					Console.WriteLine("Positions successfully saved to file " + filename);
				}
			}
			catch (Exception error)
			{
				Console.WriteLine("Error while trying to save: {0}", error.Message);
			}
		}
	}
}
