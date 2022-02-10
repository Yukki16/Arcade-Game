using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class SceneManager : GameObject // to be renamed
    {
        public enum Player
        {
            P1,
            P2
        }

        public enum Difficulty
        {
            Easy,
            Medium,
            Hard
        }
        public enum Scenes
        {
            GameScene,
            MainMenu,
            Settings,
            DifficultyScene,
            PlayerMenu,
            SongMenu
        }
        public SceneManager(Scenes sceneToLoad)
        {
            if(sceneToLoad == Scenes.GameScene)
            {
                this.AddChild(new GameScene(Difficulty.Easy));
            }
        }
    }
}
