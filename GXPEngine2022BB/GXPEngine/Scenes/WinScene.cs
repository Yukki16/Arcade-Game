using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GXPEngine.Scenes
{
    class WinScene : Scene
    {
        float timer;

        EasyDraw easyDraw;

        SceneManager sceneManager;

        Character playerOneCharacter;
        Character playerTwoCharacter;

        Font minecraftFont;
        public WinScene(int p1Score, int p2Score, SceneManager sceneManager, string playerOneFile, string playerTwoFile)
        {
            this.sceneManager = sceneManager;

            minecraftFont = Utils.LoadFont("Fonts/MINECRAFT.ttf", 40);

            easyDraw = new EasyDraw(Settings.Width, Settings.Height, false);
            easyDraw.TextAlign(CenterMode.Center, CenterMode.Center);
            easyDraw.TextFont(minecraftFont);

            background = new Sprite("Art/Backgrounds/beat_it_background_final_big.png");
            background.SetXY(0, 0);
            AddChild(background);

            playerOneCharacter = new Character(playerOneFile, SceneManager.Player.P1);

            playerTwoCharacter = new Character(playerTwoFile, SceneManager.Player.P2);

            if (p1Score > p2Score)
            {
                playerOneCharacter.ChangeState(Character.playerState.winner);
                playerTwoCharacter.ChangeState(Character.playerState.defeated);
                easyDraw.Text("Player one wins", game.width / 2, game.height / 5, false);
                easyDraw.Text(p1Score.ToString(), game.width / 2, 4 * game.height / 5, false);
            }
            else if(p1Score < p2Score)
            {
                playerOneCharacter.ChangeState(Character.playerState.defeated);
                playerTwoCharacter.ChangeState(Character.playerState.winner);
                easyDraw.Text("Player two wins", game.width / 2, game.height / 5, false);
                easyDraw.Text(p2Score.ToString(), game.width / 2, 4 * game.height / 5, false);
            }
            else
            {
                playerOneCharacter.ChangeState(Character.playerState.winner);
                playerTwoCharacter.ChangeState(Character.playerState.winner);
                easyDraw.Text("Draw", game.width / 2, game.height / 5, false);
                easyDraw.Text(p2Score.ToString(), game.width / 2, 4 * game.height / 5, false);
            }

            AddChild(playerOneCharacter);
            AddChild(playerTwoCharacter);
            AddChild(easyDraw);

            timer = Time.time;


        }

        new private void Update()
        {
            if(Time.time - timer > 5000)
            {
                sceneManager.LoadScene(SceneManager.Scenes.MainMenu, SFX.Songs.MenuSong);
            }
        }
    }
}
