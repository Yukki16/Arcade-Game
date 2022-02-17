using GXPEngine.Scenes;
using System.Collections.Generic;

namespace GXPEngine
{
    class Button : Sprite
    {
        SceneManager.Scenes sceneToLoad = SceneManager.Scenes.None;
        SceneManager.Player player;
        SceneManager sceneManager;

        public bool highlighted;
        private bool dontShowBorder = false;
        private bool addedBorder = false;

        public SFX.Songs desiredSong;
        private SceneManager.Difficulty difficulty;

        PauseMenu pauseMenu;

        public int increment;

        SettingsScene settingsScene;

        Sprite border = new Sprite("Art/Buttons/button_triangle_highlight.png");

        public Button(string path, SceneManager sceneManager, SceneManager.Scenes sceneToLoad, SFX.Songs songToPlay, bool highlight, SceneManager.Difficulty difficulty = SceneManager.Difficulty.None) : base(path)
        {
            if (path == "Art/Buttons/arrow_highlight.png" || path == "Art/Buttons/arrow_right_highlight.png")
                dontShowBorder = true;

            this.highlighted = highlight;
            this.sceneManager = sceneManager;
            this.sceneToLoad = sceneToLoad;
            this.desiredSong = songToPlay;
            this.difficulty = difficulty;
        }

        public Button(string path, bool highlight, SettingsScene settingsScene, int increment, SceneManager.Player player) : base(path)
        {
            if (path == "Art/Buttons/arrow_highlight.png" || path == "Art/Buttons/arrow_right_highlight.png")
                dontShowBorder = true;

            this.highlighted = highlight;
            this.settingsScene = settingsScene;
            this.increment = increment;
            this.player = player;         
        }

        public Button(string path, bool highlight, PauseMenu pauseMenu) : base(path)
        {
            if (path == "Art/Buttons/arrow_highlight.png" || path == "Art/Buttons/arrow_right_highlight.png")
                dontShowBorder = true;

            this.highlighted = highlight;
            this.pauseMenu = pauseMenu;
        }

        private void Update()
        {
            if (this.highlighted)
            {
                this.SetColor(1, 1, 1);
                if(!dontShowBorder && !addedBorder)
                {
                    addedBorder = true;
                    AddBorder();
                }

                if (Input.GetKeyDown(Key.W) || Input.GetKeyDown(Key.UP))
                {
                    if (sceneToLoad != SceneManager.Scenes.None)
                        sceneManager.LoadScene(sceneToLoad, desiredSong, difficulty);

                    if (settingsScene != null)
                    {
                        settingsScene.UpdateUI(player);
                    }

                    if (pauseMenu != null)
                    {
                        pauseMenu.PauseTheGame(false);
                        pauseMenu.Remove();
                    }
                }
            }
            else
            {
                this.SetColor(0.5f, 0.5f, 0.5f);
                addedBorder = false;
                this.RemoveChild(border);  
            }
        }

        private void AddBorder()
        {
            border.SetOrigin(border.width/2, border.height/2);
            border.SetXY(0, 0);
            this.AddChild(border);
        }
    }
}
