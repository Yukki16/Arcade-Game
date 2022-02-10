using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class RightArrowCombo : ArrowCombo
    {
        public RightArrowCombo(SceneManager.Player playerNumber, SceneManager.Difficulty difficulty, int pozitionInList) : base("Art/ComboKeySprites/Red_Tile.png", difficulty)
        {
            this.pozitionInList = pozitionInList;
            if (playerNumber == SceneManager.Player.P1)
            {
                this.x = 0 + this.width * 2;
            }
            else
            {
                this.x = game.width - this.width;
            }
        }
    }
}
