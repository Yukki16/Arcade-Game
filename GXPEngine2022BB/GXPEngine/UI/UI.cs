using GXPEngine.Core;
using System;
using System.Drawing;

namespace GXPEngine
{
    class UI : GameObject
    {
        EasyDraw timerUI;
        public int time;
        float timerVerticalPoz = 75;
        //float fontSize = 35;

        float clock = 0f;

        EasyDraw healthUI;

        public int playerOneHp = 10;
        public int playerTwoHp = 10;

        private Vector2 playerOneHpPoz;
        private Vector2 playerTwoHpPoz;

        EasyDraw comboUI;

        Font minecraftFont;
        public UI(SFX.Songs songPlaying)
        {
            if (songPlaying == SFX.Songs.Song1)
            {
                time = 124;
            }
            else if(songPlaying == SFX.Songs.Song2)
            {
                time = 104;
            }
            else if(songPlaying == SFX.Songs.Song3)
            {
                time = 118;
            }


            minecraftFont = Utils.LoadFont("Fonts/MINECRAFT.ttf", 40);

            timerUI = new EasyDraw(Settings.Width, Settings.Height, false);
            timerUI.SetXY(0, 0);
            timerUI.TextAlign(CenterMode.Center, CenterMode.Center);


            timerUI.TextFont(minecraftFont);
            if (time % 60 < 10)
            {
                timerUI.Text(time / 60 + ":0" + time % 60, timerUI.width / 2, timerVerticalPoz, false);
            }
            else
            {
                timerUI.Text(time / 60 + ":" + time % 60, timerUI.width / 2, timerVerticalPoz, false);
            }


            this.AddChild(timerUI);

            healthUI = new EasyDraw(Settings.Width, Settings.Height, false);
            healthUI.Fill(211, 39, 164);
            healthUI.NoStroke();

            playerOneHpPoz = new Vector2(0, 45);
            playerTwoHpPoz = new Vector2(game.width, 45);

            healthUI.Rect(playerOneHpPoz.x, playerOneHpPoz.y, 170 * playerOneHp, 50);
            healthUI.Rect(playerTwoHpPoz.x, playerTwoHpPoz.y, 170 * playerTwoHp, 50); // I really don t understand why it works as it should
                                                                                      // the corner of the second hp bar is top right, but why? I am so confused

            this.AddChild(healthUI);

            comboUI = new EasyDraw(Settings.Width, Settings.Height, false);
            comboUI.SetXY(0, 0);

            comboUI.TextFont(minecraftFont);
            //comboUI.TextSize(40);
            comboUI.TextAlign(CenterMode.Center, CenterMode.Center);

            comboUI.Text("x0", game.width / 3f, 200, false);
            comboUI.Text("x0", game.width / 1.5f, 200, false);
            this.AddChild(comboUI);
        }

        private void Update()
        {
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            if (Time.time - clock >= 1000)
            {
                clock = Time.time;
                time--;
                timerUI.ClearTransparent();
                if (time % 60 < 10)
                {
                    timerUI.Text(time / 60 + ":0" + time % 60, timerUI.width / 2, timerVerticalPoz, false);
                }
                else
                {
                    timerUI.Text(time / 60 + ":" + time % 60, timerUI.width / 2, timerVerticalPoz, false);
                }
            }
        }

        public void UpdateHealth()
        {
            healthUI.ClearTransparent();
            healthUI.Rect(playerOneHpPoz.x, playerOneHpPoz.y, 170 * playerOneHp, 50);
            healthUI.Rect(playerTwoHpPoz.x, playerTwoHpPoz.y, 170 * playerTwoHp, 50);

            Console.WriteLine(playerOneHp + " " + playerTwoHp);
        }

        public void UpdateCombo(float playerOneCombo, float playerTwoCombo)
        {
            comboUI.ClearTransparent();
            comboUI.Text("x" + playerOneCombo, game.width / 3f, 200, false);
            comboUI.Text("x" + playerTwoCombo, game.width / 1.5f, 200, false);
        }
    }
}
