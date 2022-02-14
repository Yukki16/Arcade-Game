using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    abstract class Scene : GameObject
    {
        public Sprite background;

        public Button[] buttons;

        public int buttonIndex = 0;

        public Scene()
        {
        }
        public void Update()
        {
            if (buttons != null)
            {
                if (Input.GetKeyDown(Key.A) || Input.GetKeyDown(Key.LEFT))
                {
                    if (buttonIndex > 0)
                    {
                        buttons[buttonIndex].highlighted = false;
                        buttonIndex--;
                        buttons[buttonIndex].highlighted = true;
                    }
                }

                if (Input.GetKeyDown(Key.D) || Input.GetKeyDown(Key.RIGHT))
                {
                    if (buttonIndex < buttons.Length)
                    {
                        buttons[buttonIndex].highlighted = false;
                        buttonIndex++;
                        buttons[buttonIndex].highlighted = true;
                    }
                }
            }
        }
    }
}
