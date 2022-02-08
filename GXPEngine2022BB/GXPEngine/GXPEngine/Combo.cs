using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine.GXPEngine
{
    class Combo : GameObject
    {
        public Sprite leftArrow, upArrow, rightArrow;
        public Combo()
        {
            leftArrow = new Sprite("Sprites/Arrows/Left.png");
            leftArrow.SetXY(0, 0);
            upArrow = new Sprite("Sprites/Arrows/Up.png");
            upArrow.SetXY(leftArrow.width, 0);
            rightArrow = new Sprite("Sprites/Arrows/Right.png");
            rightArrow.SetXY(leftArrow.width + upArrow.width, 0);

            AddChild(leftArrow);
            AddChild(upArrow);
            AddChild(rightArrow);
        }

        private void Update()
        {
            leftArrow.y++;
            upArrow.y++;
            rightArrow.y++;

            if(leftArrow.y > game.height/2 && Input.GetKeyDown(Key.Q))
            {
                leftArrow.y = 0;
            }
        }
    }
}
