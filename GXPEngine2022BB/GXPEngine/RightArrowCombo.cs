using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class RightArrowCombo :ArrowCombo
    {
        public RightArrowCombo(MyGame.Player playerNumber) : base("Art/ComboKeySprites/Right.png")
        {
            if (playerNumber == MyGame.Player.P1)
            {
                this.x = 0 + this.width * 2;
            }
            else
            {
                this.x = game.width - this.width;
            }
        }

        public void Update()
        {
            y += 3;
        }
    }
}
