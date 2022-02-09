using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class ArrowCombo : Sprite
    {
        private float speed = 1;
        public ArrowCombo(string texturePath) : base(texturePath)
        {
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
