using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class UI : GameObject
    {
        EasyDraw timerUI;
        int time;
        float timerVerticalPoz = 75;
        float fontSize = 35;

        float clock = 0f;

        EasyDraw healthUI;

        public int playerOneHp = 10;
        public int playerTwoHp = 10;

        private Vector2 playerOneHpPoz;
        private Vector2 playerTwoHpPoz;
        public UI()
        {
            time = 124;
            timerUI = new EasyDraw(Settings.Width, Settings.Height, false);
            timerUI.SetXY(0, 0);
            timerUI.TextAlign(CenterMode.Center, CenterMode.Center);

            
            timerUI.TextFont("MINECRAFT", fontSize);
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
            healthUI.Fill(255, 0, 0);
            healthUI.NoStroke();

            playerOneHpPoz = new Vector2(0, 45);
            playerTwoHpPoz = new Vector2(game.width, 45);

            healthUI.Rect(playerOneHpPoz.x, playerOneHpPoz.y, 170 * playerOneHp, 50);
            healthUI.Rect(playerTwoHpPoz.x, playerTwoHpPoz.y, 170 * playerTwoHp, 50); // I really don t understand why it works as it should
                                                                                      // the corner of the second hp bar is top right, but why? I am so confused

            this.AddChild(healthUI);
        }

        private void Update()
        {
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            if(Time.time - clock >= 1000)
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
    }
}
