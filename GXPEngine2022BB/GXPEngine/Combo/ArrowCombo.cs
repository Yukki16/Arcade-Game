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
        public int pozitionInList;
        public ArrowCombo(string texturePath, SceneManager.Difficulty difficulty) : base(texturePath)
        {
            if(difficulty == SceneManager.Difficulty.Easy)
            {
                speed = 2;
            }
            else if (difficulty == SceneManager.Difficulty.Medium)
            {
                speed = 2.5f;
            }else
            {
                speed = 3;
            }
            //this.endOfCombo = endOfCombo;
            y = this.height;
        }
        public void Update()
        {
            y+=speed;
        }

        public void DestroyArrow()
        {
            //Console.WriteLine("done for");
            this.Destroy();
        }
    }
}
