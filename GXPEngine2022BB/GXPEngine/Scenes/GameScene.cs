using GXPEngine.Scenes;
using System;

namespace GXPEngine
{
    class GameScene : Scene
    {
        Sprite overlay;

        public UI sceneUI;

        public PlayerKeysCombo playerOne;
        public PlayerKeysCombo playerTwo;

        Character playerOneCharacter;
        Character playerTwoCharacter;

        SceneManager sceneManager;
        public SFX sfx;

        PauseMenu pauseMenu;
        public bool addedThePauseMenu = false;

        public GameScene(SceneManager.Difficulty difficulty, string playerOneFile, string playerTwoFile, SceneManager sceneManager, SFX.Songs songPlaying, SFX sfx) : base()
        {
            this.sceneManager = sceneManager;
            this.sfx = sfx;

            background = new Sprite("Art/Backgrounds/beat_it_background_final_big.png");
            background.SetXY(0, 0);
            this.AddChild(background);

            overlay = new Sprite("Art/Backgrounds/Overlay_Concept.png");
            overlay.SetXY(0, 0);
            this.AddChild(overlay);

            //the arrows that fall down
            playerOne = new PlayerKeysCombo(SceneManager.Player.P1, difficulty, this, songPlaying);
            playerOne.SetKeys(Settings.P1Left, Settings.P1Up, Settings.P1Right);
            this.AddChild(playerOne);

            //the character itself
            playerOneCharacter = new Character(playerOneFile, SceneManager.Player.P1);

            this.AddChild(playerOneCharacter);

            //arrows that fall down
            playerTwo = new PlayerKeysCombo(SceneManager.Player.P2, difficulty, this, songPlaying);
            playerTwo.SetKeys(Settings.P2Left, Settings.P2Up, Settings.P2Right);
            this.AddChild(playerTwo);

            //character itself
            playerTwoCharacter = new Character(playerTwoFile, SceneManager.Player.P2);

            this.AddChild(playerTwoCharacter);

            sceneUI = new UI(songPlaying);
            sceneUI.SetXY(0, 0);
            this.AddChild(sceneUI);


            pauseMenu = new PauseMenu(this.sceneManager, this);
        }

        new private void Update()
        {
            if(sceneUI.time == 0)
            {
                sceneManager.LoadScene(SceneManager.Scenes.EndOfTheGame, SFX.Songs.VictorySFX, SceneManager.Difficulty.None, playerOne.score, playerTwo.score);
            }

            if(Input.GetKeyDown(Key.P) && !addedThePauseMenu)
            {
                this.AddChild(pauseMenu);
                pauseMenu.PauseTheGame(true);
                //addedThePauseMenu = true;
            }
        }

        public void InflictDamage(int numberInList) // chechs from other player if he still has the other arrow, if not it changes the players state to dysplay animations
        {
            Console.WriteLine(numberInList);
            bool inflictDamage = true;
            ArrowCombo[] arrowslistPlayerOne = this.FindObjectsOfType<ArrowCombo>();
            //Console.WriteLine("alo" + arrowslistPlayerOne.Length);
            ArrowCombo[] arrowslistPlayerTwo = playerOne.FindObjectsOfType<ArrowCombo>();

            //Console.WriteLine(arrowslistPlayerOne.Length);

            foreach (ArrowCombo arrows in arrowslistPlayerOne)
            {
                //Console.WriteLine(arrows.pozitionInList);
                if (arrows.pozitionInList == numberInList)
                {
                    //Console.WriteLine("got here");
                    inflictDamage = false;
                    break;
                }
            }

            foreach (ArrowCombo arrows in arrowslistPlayerTwo)
            {
                if (arrows.pozitionInList == numberInList)
                {
                    inflictDamage = false;
                    break;
                }
            }

            if (inflictDamage)
            {
                Console.WriteLine("triggered");
                int tempComboScoreP1 = playerOne.comboScore;
                int tempComboScoreP2 = playerTwo.comboScore;

                if (tempComboScoreP1 == tempComboScoreP2)
                {
                    playerOneCharacter.ChangeState(Character.playerState.defence);
                    playerTwoCharacter.ChangeState(Character.playerState.defence);
                }
                else if (tempComboScoreP1 > tempComboScoreP2)
                {
                    playerOneCharacter.ChangeState(Character.playerState.attack);
                    playerTwoCharacter.ChangeState(Character.playerState.defence);
                    sceneUI.playerTwoHp--;
                }
                else
                {
                    playerOneCharacter.ChangeState(Character.playerState.defence);
                    playerTwoCharacter.ChangeState(Character.playerState.attack);
                    sceneUI.playerOneHp--;
                }

                playerOne.comboScore = 0;
                playerTwo.comboScore = 0;
                sceneUI.UpdateHealth();

                if (sceneUI.playerOneHp == 0)
                {
                    playerOneCharacter.ChangeState(Character.playerState.defeated);
                    playerOne.dead = true;
                }
                if (sceneUI.playerTwoHp == 0)
                {
                    playerTwoCharacter.ChangeState(Character.playerState.defeated);
                    playerTwo.dead = true;
                }
            }
            //inflictDamage = true;

        }
        public void UpdateComboUI()
        {
            sceneUI.UpdateCombo(playerOne.comboHit, playerTwo.comboHit);
        }
    }
}
