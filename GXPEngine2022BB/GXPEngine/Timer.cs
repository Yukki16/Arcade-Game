using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Timer : GameObject
    {
        EasyDraw easyDraw;
        int time;
        float timerVerticalPoz = 75;
        float fontSize = 35;

        float clock = 0f;
        public Timer()
        {
            time = 63;
            easyDraw = new EasyDraw(Settings.Width, Settings.Height, false);
            easyDraw.SetXY(0, 0);
            easyDraw.TextAlign(CenterMode.Center, CenterMode.Center);

            
            easyDraw.TextFont("MINECRAFT", fontSize);
            if (time % 60 < 10)
            {
                easyDraw.Text(time / 60 + ":0" + time % 60, easyDraw.width / 2, timerVerticalPoz, false);
            }
            else
            {
                easyDraw.Text(time / 60 + ":" + time % 60, easyDraw.width / 2, timerVerticalPoz, false);
            }
            this.AddChild(easyDraw);
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
                easyDraw.ClearTransparent();
                if (time % 60 < 10)
                {
                    easyDraw.Text(time / 60 + ":0" + time % 60, easyDraw.width / 2, timerVerticalPoz, false);
                }
                else
                {
                    easyDraw.Text(time / 60 + ":" + time % 60, easyDraw.width / 2, timerVerticalPoz, false);
                }
            }
        }
    }
}
