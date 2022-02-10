using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    abstract class ArrowCombo : Sprite
    {
        private float speed = 1;
        public ArrowCombo(string texturePath, SceneManager.Difficulty difficulty) : base(texturePath)
        {
            if(difficulty == SceneManager.Difficulty.Easy)
            {
                speed = 1;
            }
            else if (difficulty == SceneManager.Difficulty.Medium)
            {
                speed = 2;
            }else
            {
                speed = 3;
            }
            y = 0;
        }
        public void Update()
        {
            y+=speed;
        }

        public void DestroyArrow()
        {
            this.Destroy();
        }
    }
}
