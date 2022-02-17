using System;
using System.Drawing;

namespace GXPEngine.Scenes
{
    class SettingsScene : Scene
    {
        SceneManager sceneManager;
        SFX sfx;

        EasyDraw easyDraw;

        Font minecraftFont;

        public string[] characters;
        public int playerOneCharactersIndex = 0;
        public int playerTwoCharactersIndex = 0;
        public SettingsScene(SceneManager sceneManager, SFX sfx)
        {
            minecraftFont = Utils.LoadFont("Fonts/MINECRAFT.ttf", 40);

            characters = new string[2];
            characters[0] = "Girl";
            characters[1] = "Man";

            this.sceneManager = sceneManager;
            this.sfx = sfx;

            playerOneCharactersIndex = sceneManager.playerOneFileIndex;
            playerTwoCharactersIndex = sceneManager.playerTwoFileIndex;

            background = new Sprite("Art/Backgrounds/beat_it_background_final_big.png");
            background.SetXY(0, 0);
            AddChild(background);

            easyDraw = new EasyDraw(Settings.Width, Settings.Height, false);
            easyDraw.TextAlign(CenterMode.Center, CenterMode.Center);
            easyDraw.TextFont(minecraftFont);
            AddChild(easyDraw);

            buttons = new Button[7];

            buttons[0] = new Button("Art/Buttons/arrow_highlight.png", true, this, -1, SceneManager.Player.P1);
            buttons[0].SetOrigin(buttons[0].width / 2, buttons[0].height / 2);
            buttons[0].SetXY(game.width / 4, game.height / 5);
            AddChild(buttons[0]);

            buttons[1] = new Button("Art/Buttons/arrow_right_highlight.png", false, this, 1, SceneManager.Player.P1);
            buttons[1].SetOrigin(buttons[1].width / 2, buttons[1].height / 2);
            buttons[1].SetXY(3 * game.width / 4, game.height / 5);
            AddChild(buttons[1]);

            buttons[2] = new Button("Art/Buttons/arrow_highlight.png", false, this, -1, SceneManager.Player.P2);
            buttons[2].SetOrigin(buttons[2].width / 2, buttons[2].height / 2);
            buttons[2].SetXY(game.width / 4, 2 * game.height / 5);
            AddChild(buttons[2]);

            buttons[3] = new Button("Art/Buttons/arrow_right_highlight.png", false, this, 1, SceneManager.Player.P2);
            buttons[3].SetOrigin(buttons[3].width / 2, buttons[3].height / 2);
            buttons[3].SetXY(3 * game.width / 4, 2 * game.height / 5);
            AddChild(buttons[3]);

            buttons[4] = new Button("Art/Buttons/arrow_highlight.png", false, this, -1, SceneManager.Player.None);
            buttons[4].SetOrigin(buttons[4].width / 2, buttons[4].height / 2);
            buttons[4].SetXY(game.width / 4, 3 * game.height / 5);
            AddChild(buttons[4]);

            buttons[5] = new Button("Art/Buttons/arrow_right_highlight.png", false, this, 1, SceneManager.Player.None);
            buttons[5].SetOrigin(buttons[5].width / 2, buttons[5].height / 2);
            buttons[5].SetXY(3 * game.width / 4, 3 * game.height / 5);
            AddChild(buttons[5]);

            buttons[6] = new Button("Art/Buttons/back_button.png", this.sceneManager, SceneManager.Scenes.MainMenu, SFX.Songs.MenuSong, false);
            buttons[6].SetOrigin(buttons[6].width / 2, buttons[6].height / 2);
            buttons[6].SetXY(game.width / 2, 4 * game.height / 5);
            AddChild(buttons[6]);

            UpdateUI(SceneManager.Player.Null);
        }

        public void UpdateUI(SceneManager.Player player)
        {
            easyDraw.ClearTransparent();

            if(player == SceneManager.Player.P1)
            {
                playerOneCharactersIndex += buttons[buttonIndex].increment;
                playerOneCharactersIndex = Mathf.Round(Mathf.Clamp(playerOneCharactersIndex, 0, characters.Length - 1));
            }
            
            if(player == SceneManager.Player.P2)
            {
                playerTwoCharactersIndex += buttons[buttonIndex].increment;
                playerTwoCharactersIndex = Mathf.Round(Mathf.Clamp(playerTwoCharactersIndex, 0, characters.Length - 1));
            }

            if(player == SceneManager.Player.None)
            {
                sfx.volume += buttons[buttonIndex].increment;
                sfx.volume = Mathf.Round(Mathf.Clamp(sfx.volume, 0, 10));
            }

            easyDraw.Text(characters[playerOneCharactersIndex], game.width / 2, game.height / 5, false);
            easyDraw.Text(characters[playerTwoCharactersIndex], game.width / 2, 2 * game.height / 5, false);
            easyDraw.Text(sfx.volume.ToString(), game.width / 2, 3 * game.height / 5, false);




            easyDraw.Text("Character player 1", game.width / 2, game.height / 9, false);
            easyDraw.Text("Character player 2", game.width / 2, 3 * game.height / 9, false);
            easyDraw.Text("Volume", game.width / 2, 4.5f * game.height / 9, false);


            sceneManager.playerOneFileIndex = playerOneCharactersIndex;
            sceneManager.playerTwoFileIndex = playerTwoCharactersIndex;
            /*easyDraw.Text(buttons[buttonIndex].characters[buttons[buttonIndex].playerOneCharactersIndex], game.width / 2, game.height / 5, false);
            easyDraw.Text(buttons[buttonIndex].characters[buttons[buttonIndex].playerTwoCharactersIndex], game.width / 2, 2 * game.height / 5, false);*/


            //Console.WriteLine(buttons[0].playerOneCharactersIndex + " " + buttons[0].playerTwoCharactersIndex);
        }
    }
}
