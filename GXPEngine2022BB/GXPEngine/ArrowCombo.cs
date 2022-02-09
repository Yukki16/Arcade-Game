using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class ArrowCombo : Sprite
    {
        
        public ArrowCombo(string texturePath) : base(texturePath)
        {
            y = 0;
        }
        private void Update()
        {
            y+=5;
        }
    }
}
