using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Button : Sprite
    {
        SceneManager.Scenes sceneToLoad;
        SceneManager sceneManager;

        public bool highlighted;

        public SFX.Songs desiredSong;

        public Button(string path, SceneManager sceneManager, SceneManager.Scenes sceneToLoad, SFX.Songs songToPlay, bool highlight) : base(path)
        {
            this.highlighted = highlight;
            this.sceneManager = sceneManager;
            this.sceneToLoad = sceneToLoad;
            this.desiredSong = songToPlay;
        }

        private void Update()
        {
            if (this.highlighted)
            {
                this.SetColor(1, 1, 1);

                if (Input.GetKeyDown(Key.W) || Input.GetKeyDown(Key.UP))
                {
                    sceneManager.LoadScene(sceneToLoad, desiredSong);
                }
            }
            else
            {
                this.SetColor(0.5f, 0.5f, 0.5f);
            }
        }
    }
}
