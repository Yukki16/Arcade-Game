﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class LeftArrowCombo : ArrowCombo
    {
        
        public LeftArrowCombo(SceneManager.Player playerNumber, SceneManager.Difficulty difficulty) : base("Art/ComboKeySprites/Pink_Tile.png", difficulty)
        {
            if(playerNumber == SceneManager.Player.P1)
            {
                this.x = 0;
            }
            else
            {
                this.x = game.width - this.width * 3;
            }
        }
    }
}