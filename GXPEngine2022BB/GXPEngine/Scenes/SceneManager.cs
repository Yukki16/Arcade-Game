﻿using GXPEngine.Scenes;
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
            SongMenu,
            HighScore
        }

        public SFX sfx = new SFX();
        public SceneManager()
        {
            
        }

        public void LoadScene(Scenes sceneToLoad, SFX.Songs songToLoad)
        {
            if (sceneToLoad == Scenes.GameScene)
            {
                CleanOtherScenes();
                this.AddChild(new GameScene(Difficulty.Hard));
                sfx.PlaySong(songToLoad);     
            }

            if(sceneToLoad == Scenes.MainMenu)
            {
                CleanOtherScenes();
                this.AddChild(new MainMenu(this));
            }

            if(sceneToLoad == Scenes.SongMenu)
            {
                Console.WriteLine("loaded");
                CleanOtherScenes();
                this.AddChild(new SelectSongMenu(this, this.sfx));
            }
        }

        private void CleanOtherScenes()
        {
            List<GameObject> allScenes = this.GetChildren();
            foreach(GameObject aScenes in allScenes)
            {
                aScenes.Destroy();
            }
        }
    }
}
