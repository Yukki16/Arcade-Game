using GXPEngine.Scenes;
using System.Collections.Generic;

namespace GXPEngine
{
    class SceneManager : GameObject // to be renamed
    {
        public enum Player
        {
            P1,
            P2,
            None,
            Null
        }

        public enum Difficulty
        {
            None,
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
            HighScore,
            EndOfTheGame,
            None
        }

        public SFX sfx = new SFX();

        string[] playerOneFilePath;
        string[] playerTwoFilePath;

        public int playerOneFileIndex = 0;
        public int playerTwoFileIndex = 0;
        public SceneManager()
        {
            playerOneFilePath = new string[2];
            playerOneFilePath[0] = "Art/Player/girl_red.png";
            playerOneFilePath[1] = "Art/Player/jackson_red.png";

            playerTwoFilePath = new string[2];
            playerTwoFilePath[0] = "Art/Player/girl_blue.png";
            playerTwoFilePath[1] = "Art/Player/jackson_blue.png";
        }

        public void LoadScene(Scenes sceneToLoad, SFX.Songs songToLoad, Difficulty difficulty = Difficulty.None, int p1Score = 0, int p2Score = 0)
        {
            if (sceneToLoad == Scenes.GameScene)
            {
                CleanOtherScenes();
                this.AddChild(new GameScene(difficulty, playerOneFilePath[playerOneFileIndex], playerTwoFilePath[playerTwoFileIndex], this, songToLoad, this.sfx));
                sfx.PlaySong(songToLoad);
            }

            if (sceneToLoad == Scenes.MainMenu)
            {
                CleanOtherScenes();
                sfx.PlaySong(SFX.Songs.MenuSong);
                this.AddChild(new MainMenu(this));
            }

            if (sceneToLoad == Scenes.SongMenu)
            {
                //Console.WriteLine("loaded");
                CleanOtherScenes();
                this.AddChild(new SelectSongMenu(this, this.sfx));
            }

            if (sceneToLoad == Scenes.DifficultyScene)
            {
                CleanOtherScenes();
                sfx.PlaySong(SFX.Songs.MenuSong);
                this.AddChild(new DifficultyMenu(this, songToLoad));
            }

            if (sceneToLoad == Scenes.Settings)
            {
                CleanOtherScenes();
                sfx.PlaySong(SFX.Songs.MenuSong);
                this.AddChild(new SettingsScene(this, this.sfx));
            }

            if(sceneToLoad == Scenes.EndOfTheGame)
            {
                CleanOtherScenes();
                sfx.PlaySong(songToLoad);
                this.AddChild(new WinScene(p1Score, p2Score, this, this.playerOneFilePath[playerOneFileIndex], this.playerTwoFilePath[playerTwoFileIndex]));
            }
        }

        private void CleanOtherScenes()
        {
            List<GameObject> allScenes = this.GetChildren();
            foreach (GameObject aScenes in allScenes)
            {
                aScenes.Destroy();
            }
        }
    }
}
