using System.Collections.Generic;

namespace GXPEngine
{
    class PlayerKeysCombo : GameObject
    {
        GameScene theParent;

        public ReadComboFiles readComboFiles;
        public int pozitionInList = 0; // to be renamed :/

        float timer = 0f;

        bool destroiedOne = false;

        public int score;
        public int comboScore;
        public int comboHit;

        //the sprites which will check the combo
        Sprite leftComboArrow;
        Sprite rightComboArrow;
        Sprite upComboArrow;

        SceneManager.Player playerNumeber;
        SceneManager.Difficulty difficulty;

        int spawnTime;
        int numberOfTiles;

        public bool dead = false;
        public bool paused = false;

        //int perfect, half, whiff;

        int keyLeft, keyUp, keyRight; //the custom keys for the input of the player (will be read from Settings)
        public PlayerKeysCombo(SceneManager.Player playerNumber, SceneManager.Difficulty difficulty, GameScene gameScene, SFX.Songs song)
        {
            this.theParent = gameScene;

            string difficultyFile;

            if(difficulty == SceneManager.Difficulty.Easy)
            {
                difficultyFile = "easy";
            }
            else
            {
                difficultyFile = "medium_hard";
            }

            if (song == SFX.Songs.Song1)
            {
                readComboFiles = new ReadComboFiles("MusicCombos/Song_1_" + difficultyFile + ".csv");
            }
            else if(song == SFX.Songs.Song2)
            {
                readComboFiles = new ReadComboFiles("MusicCombos/Song_2_" + difficultyFile + ".csv");
            }
            else if(song == SFX.Songs.Song3)
            {
                readComboFiles = new ReadComboFiles("MusicCombos/Song_3_" + difficultyFile + ".csv");
            }

            this.difficulty = difficulty;
            this.playerNumeber = playerNumber;

            leftComboArrow = new Sprite("Art/ComboKeySprites/The_Tile.png");
            upComboArrow = new Sprite("Art/ComboKeySprites/The_Tile.png");
            rightComboArrow = new Sprite("Art/ComboKeySprites/The_Tile.png");

            if (playerNumber == SceneManager.Player.P1)
            {
                leftComboArrow.SetXY(0, game.height - leftComboArrow.height);
                upComboArrow.SetXY(upComboArrow.width, game.height - upComboArrow.height);
                rightComboArrow.SetXY(rightComboArrow.width * 2, game.height - rightComboArrow.height);
            }
            else
            {
                leftComboArrow.SetXY(game.width - 3 * leftComboArrow.width, game.height - leftComboArrow.height);
                upComboArrow.SetXY(game.width - 2 * upComboArrow.width, game.height - upComboArrow.height);
                rightComboArrow.SetXY(game.width - rightComboArrow.width, game.height - rightComboArrow.height);
            }

            AddChild(leftComboArrow);
            AddChild(upComboArrow);
            AddChild(rightComboArrow);

            if (difficulty == SceneManager.Difficulty.Easy)
            {
                spawnTime = 750;
            }
            else
            {
                spawnTime = 500;
            }
                numberOfTiles = readComboFiles.leftArrows.Count;
        }

        public void SetKeys(int left, int up, int right)
        {
            keyLeft = left;
            keyRight = right;
            keyUp = up;
        }

        private void Update()
        {
            if (dead)
                return;
            if(paused)
            {
                //PauseComboTiles();
                return;
            }
            this.Combo();
            SpawnArrows();
            ClearArrows();

        }

        private void Combo() // checks if the player hit the combo when pressing the input
        {                                       //later to be added: Combo perfection

            GameObject[] leftArrows = this.FindObjectsOfType<LeftArrowCombo>();
            GameObject[] middleArrows = this.FindObjectsOfType<MiddleArrowCombo>();
            GameObject[] rightArrows = this.FindObjectsOfType<RightArrowCombo>();

            //bool inflictDamage = false;

            if (Input.GetKeyDown(keyUp))
            {
                foreach (ArrowCombo middleA in middleArrows)
                {
                    if (destroiedOne)
                        break;


                    if (upComboArrow.HitTest(middleA))
                    {
                        if (middleA.y - middleA.height / 2 == upComboArrow.y - upComboArrow.height / 2)
                        {
                            //perfect++;
                            comboScore += 1000;
                            score += 1000;
                        }
                        else if ((middleA.y - middleA.height / 2 >= upComboArrow.y && middleA.y - middleA.height / 2 < upComboArrow.y - upComboArrow.height / 2) || (middleA.y - middleA.height / 2 >= upComboArrow.y - upComboArrow.height && middleA.y - middleA.height / 2 > upComboArrow.y - upComboArrow.height / 2))
                        {
                            //half++;
                            comboScore += 700;
                            score += 700;
                        }
                        else
                        {
                            //whiff++;
                            comboScore += 500;
                            score += 500;
                        }

                        destroiedOne = true;

                        middleA.DestroyArrow();
                        if (readComboFiles.endCombo[middleA.pozitionInList + 1].Contains("1"))
                            theParent.InflictDamage(middleA.pozitionInList);

                        comboHit++;
                    }
                    else
                    {
                        comboHit = 0;
                        comboScore -= 200;
                    }
                }
            }
            if (Input.GetKeyDown(keyLeft))
            {
                foreach (ArrowCombo leftA in leftArrows)
                {
                    if (destroiedOne)
                        break;


                    if (leftComboArrow.HitTest(leftA))
                    {
                        if (leftA.y - leftA.height / 2 == upComboArrow.y - upComboArrow.height / 2)
                        {
                            //perfect++;
                            comboScore += 1000;
                            score += 1000;
                        }
                        else if ((leftA.y - leftA.height / 2 >= upComboArrow.y && leftA.y - leftA.height / 2 < upComboArrow.y - upComboArrow.height / 2) || (leftA.y - leftA.height / 2 >= upComboArrow.y - upComboArrow.height && leftA.y - leftA.height / 2 > upComboArrow.y - upComboArrow.height / 2))
                        {
                            //half++;
                            comboScore += 700;
                            score += 700;
                        }
                        else
                        {
                            //whiff++;
                            comboScore += 500;
                            score += 500;
                        }
                        destroiedOne = true;

                        leftA.DestroyArrow();
                        if (readComboFiles.endCombo[leftA.pozitionInList + 1].Contains("1"))
                            theParent.InflictDamage(leftA.pozitionInList);

                        comboHit++;
                    }
                    else
                    {
                        comboHit = 0;
                        comboScore -= 200;
                    }
                }
            }
            if (Input.GetKeyDown(keyRight))
            {
                foreach (ArrowCombo rightA in rightArrows)
                {
                    if (destroiedOne)
                        break;


                    if (rightComboArrow.HitTest(rightA))
                    {
                        if (rightA.y - rightA.height / 2 == upComboArrow.y - upComboArrow.height / 2)
                        {
                            //perfect++;
                            comboScore += 1000;
                            score += 1000;
                        }
                        else if ((rightA.y - rightA.height / 2 >= upComboArrow.y && rightA.y - rightA.height / 2 < upComboArrow.y - upComboArrow.height / 2) || (rightA.y - rightA.height / 2 >= upComboArrow.y - upComboArrow.height && rightA.y - rightA.height / 2 > upComboArrow.y - upComboArrow.height / 2))
                        {
                            //half++;
                            comboScore += 700;
                            score += 700;
                        }
                        else
                        {
                            //whiff++;
                            comboScore += 500;
                            score += 500;
                        }

                        destroiedOne = true;

                        rightA.DestroyArrow();
                        if (readComboFiles.endCombo[rightA.pozitionInList + 1].Contains("1"))
                            theParent.InflictDamage(rightA.pozitionInList);

                        comboHit++;
                    }
                    else
                    {
                        comboHit = 0;
                        comboScore -= 200;
                    }
                }
                //Console.WriteLine(rightArrows.Length);
            }


            destroiedOne = false;
            theParent.UpdateComboUI();
        }


        private void SpawnArrows()  //used for now, I will change later to read from a file all the arrows that corespond to the song //// Done
        {
            if (Time.time - timer > spawnTime) //for now spawns an arrow every 1 second from .cvs file
            {
                timer = Time.time;

                if (pozitionInList < numberOfTiles)
                {
                    if (readComboFiles.leftArrows[pozitionInList].Contains("1"))
                    {
                        AddChild(new LeftArrowCombo(playerNumeber, difficulty, pozitionInList));
                    }
                    if (readComboFiles.middleArrows[pozitionInList].Contains("1"))
                    {
                        AddChild(new MiddleArrowCombo(playerNumeber, difficulty, pozitionInList));
                    }
                    if (readComboFiles.rightArrows[pozitionInList].Contains("1"))
                    {
                        AddChild(new RightArrowCombo(playerNumeber, difficulty, pozitionInList));
                    }


                    pozitionInList++;
                }

            }
        }

        private void ClearArrows() //clears the arrows that are out of the screen
        {
            List<GameObject> gameObjects = this.GetChildren();
            foreach (GameObject child in gameObjects)
            {

                if (child.y > game.height)
                {
                    child.Destroy();
                    if (child is ArrowCombo a)
                    {
                        if (readComboFiles.endCombo[a.pozitionInList + 1] == "1")
                            theParent.InflictDamage(a.pozitionInList);
                        //Console.WriteLine(a.pozitionInList);
                    }
                    comboHit = 0;
                    comboScore -= 200;
                    theParent.UpdateComboUI();
                }
            }
            //Console.WriteLine(this.GetChildCount());
        }

        public void PauseComboTiles()
        {
            ArrowCombo[] arrowCombo = this.FindObjectsOfType<ArrowCombo>();
            foreach(ArrowCombo arrow in arrowCombo)
            {
                arrow.paused = this.paused;
            }
        }
    }
}
