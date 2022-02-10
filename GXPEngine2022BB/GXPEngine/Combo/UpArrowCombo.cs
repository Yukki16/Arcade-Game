using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class UpArrowCombo : ArrowCombo
    {
        public UpArrowCombo(SceneManager.Player playerNumber, SceneManager.Difficulty difficulty) : base("Art/ComboKeySprites/Purple_Tile.png", difficulty)
        {
            if (playerNumber == SceneManager.Player.P1)
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
