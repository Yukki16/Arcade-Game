using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class SFX : GameObject
    {
        public Sound Song_1;
        public SFX()
        {
            
        }

        public void LoadSongs()
        {
            Song_1 = new Sound("Music/demo_1.mp3");
           
        }
    }
}
