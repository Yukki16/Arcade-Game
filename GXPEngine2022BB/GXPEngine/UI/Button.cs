using GXPEngine.Scenes;

namespace GXPEngine
{
    class Button : Sprite
    {
        SceneManager.Scenes sceneToLoad = SceneManager.Scenes.None;
        SceneManager.Player player;
        SceneManager sceneManager;

        public bool highlighted;

        public SFX.Songs desiredSong;
        private SceneManager.Difficulty difficulty;

        

        public int increment;

        SettingsScene settingsScene;

        public Button(string path, SceneManager sceneManager, SceneManager.Scenes sceneToLoad, SFX.Songs songToPlay, bool highlight, SceneManager.Difficulty difficulty = SceneManager.Difficulty.None) : base(path)
        {
            this.highlighted = highlight;
            this.sceneManager = sceneManager;
            this.sceneToLoad = sceneToLoad;
            this.desiredSong = songToPlay;
            this.difficulty = difficulty;
        }

        public Button(string path, bool highlight, SettingsScene settingsScene, int increment, SceneManager.Player player) : base(path)
        {
            this.highlighted = highlight;
            this.settingsScene = settingsScene;
            this.increment = increment;
            this.player = player;

            
        }

        private void Update()
        {
            if (this.highlighted)
            {
                this.SetColor(1, 1, 1);

                if (Input.GetKeyDown(Key.W) || Input.GetKeyDown(Key.UP))
                {
                    if (sceneToLoad != SceneManager.Scenes.None)
                        sceneManager.LoadScene(sceneToLoad, desiredSong, difficulty);

                    if (settingsScene != null)
                    {
                        settingsScene.UpdateUI(player);
                    }
                }
            }
            else
            {
                this.SetColor(0.5f, 0.5f, 0.5f);
            }
        }
    }
}
