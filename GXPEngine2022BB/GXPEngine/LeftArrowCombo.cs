using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class LeftArrowCombo : ArrowCombo
    {
        
        public LeftArrowCombo(MyGame.Player playerNumber) : base("Art/ComboKeySprites/Left.png")
        {
            if(playerNumber == MyGame.Player.P1)
            {
                this.x = 0;
            }
            else
            {
                this.x = game.width - this.width * 3;
            }
        }

        public void Update()
        {
            y += 3;
        }
    }
}
