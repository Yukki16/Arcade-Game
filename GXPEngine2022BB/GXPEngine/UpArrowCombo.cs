using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class UpArrowCombo : ArrowCombo
    {
        public UpArrowCombo(ManagerAndStuff.Player playerNumber) : base("Art/ComboKeySprites/Up.png")
        {
            if (playerNumber == ManagerAndStuff.Player.P1)
            {
                this.x = 0 + this.width;
            }
            else
            {
                this.x = game.width - this.width * 2;
            }
        }
    }
}
