using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class PlayerKeysCombo : GameObject
    {
        Random random = new Random();
        float timer = 0f;

        //the sprites which will check the combo
        Sprite leftComboArrow;
        Sprite rightComboArrow;
        Sprite upComboArrow;

        ManagerAndStuff.Player playerNumeber;

        int perfect, half, whiff;

        int keyLeft, keyUp, keyRight; //the custom keys for the input of the player (will be read from Settings)
        public PlayerKeysCombo(ManagerAndStuff.Player playerNumber)
        {
            this.playerNumeber = playerNumber;

            leftComboArrow = new Sprite("Art/ComboKeySprites/Left.png");
            upComboArrow = new Sprite("Art/ComboKeySprites/Up.png");
            rightComboArrow = new Sprite("Art/ComboKeySprites/Right.png");

            if (playerNumber == ManagerAndStuff.Player.P1)
            {
                leftComboArrow.SetXY(0, game.height / 2); //- leftComboArrow.height);
                upComboArrow.SetXY(upComboArrow.width, game.height / 2);//- upComboArrow.height);
                rightComboArrow.SetXY(rightComboArrow.width * 2, game.height / 2); //- rightComboArrow.height);
            }
            else
            {
                leftComboArrow.SetXY(game.width - 3 *leftComboArrow.width, game.height - leftComboArrow.height);
                upComboArrow.SetXY(game.width - 2 * upComboArrow.width, game.height - upComboArrow.height);
                rightComboArrow.SetXY(game.width - rightComboArrow.width, game.height - rightComboArrow.height);
            }

            AddChild(leftComboArrow);
            AddChild(upComboArrow);
            AddChild(rightComboArrow);
        }

        public void SetKeys(int left, int up, int right)
        {
            keyLeft = left;
            keyRight = right;
            keyUp = up;
        }

        void Update()
        {
            this.Combo();
            randomArrows();
            ClearArrows();
        }

        private void Combo() // checks if the player hit the combo when pressing the input
        {                                       //later to be added: Combo perfection
            GameObject[] leftArrows = this.FindObjectsOfType<LeftArrowCombo>();
            GameObject[] upArrows = this.FindObjectsOfType<UpArrowCombo>();
            GameObject[] rightArrows = this.FindObjectsOfType<RightArrowCombo>();
            if (Input.GetKeyDown(keyUp))
            {
                foreach(ArrowCombo upA in upArrows)
                    if (upComboArrow.HitTest(upA))
                    {
                        if (upA.y - upA.height / 2 == upComboArrow.y - upComboArrow.height / 2)
                        {
                            perfect++;
                        }
                        else if((upA.y - upA.height / 2 >= upComboArrow.y && upA.y - upA.height / 2 < upComboArrow.y - upComboArrow.height / 2) || (upA.y - upA.height / 2 >= upComboArrow.y - upComboArrow.height && upA.y - upA.height / 2 > upComboArrow.y - upComboArrow.height / 2))
                        {
                            half++;
                        }
                        else
                        {
                            whiff++;
                        }
                        Console.WriteLine("hitU");
                        upA.DestroyArrow();

                        Console.WriteLine("perfect: " + perfect);
                        Console.WriteLine("half: " + half);
                        Console.WriteLine("whiff: " + whiff);
                    }
            }
            if (Input.GetKeyDown(keyLeft))
            {
                foreach (ArrowCombo leftA in leftArrows)
                    if (leftComboArrow.HitTest(leftA))
                    {
                        if (leftA.y - leftA.height / 2 == upComboArrow.y - upComboArrow.height / 2)
                        {
                            perfect++;
                        }
                        else if ((leftA.y - leftA.height / 2 >= upComboArrow.y && leftA.y - leftA.height / 2 < upComboArrow.y - upComboArrow.height / 2) || (leftA.y - leftA.height / 2 >= upComboArrow.y - upComboArrow.height && leftA.y - leftA.height / 2 > upComboArrow.y - upComboArrow.height / 2))
                        {
                            half++;
                        }
                        else
                        {
                            whiff++;
                        }
                        Console.WriteLine("hitU");
                        leftA.DestroyArrow();

                        Console.WriteLine("perfect: " + perfect);
                        Console.WriteLine("half: " + half);
                        Console.WriteLine("whiff: " + whiff);
                        Console.WriteLine("hitL");
                        leftA.DestroyArrow();
                    }
            }
            if (Input.GetKeyDown(keyRight))
            {
                foreach (ArrowCombo rightA in rightArrows)
                    if (rightComboArrow.HitTest(rightA)) 
                    {
                        if (rightA.y - rightA.height / 2 == upComboArrow.y - upComboArrow.height / 2)
                        {
                            perfect++;
                        }
                        else if ((rightA.y - rightA.height / 2 >= upComboArrow.y && rightA.y - rightA.height / 2 < upComboArrow.y - upComboArrow.height / 2) || (rightA.y - rightA.height / 2 >= upComboArrow.y - upComboArrow.height && rightA.y - rightA.height / 2 > upComboArrow.y - upComboArrow.height / 2))
                        {
                            half++;
                        }
                        else
                        {
                            whiff++;
                        }
                        Console.WriteLine("hitU");
                        rightA.DestroyArrow();

                        Console.WriteLine("perfect: " + perfect);
                        Console.WriteLine("half: " + half);
                        Console.WriteLine("whiff: " + whiff);
                        Console.WriteLine("hitR");
                        rightA.DestroyArrow();
                        Console.WriteLine(rightArrows.Length);
                    }
                //Console.WriteLine(rightArrows.Length);
            }
            
        }

        private void randomArrows()  //used for now, I will change later to read from a file all the arrows that corespond to the song
        {
            if (Time.time - timer > 1000) //for now spawns a random arrow every 1 second
            {
                timer = Time.time;
                int copy = random.Next(1, 4);
                if (copy == 1)
                {
                    AddChild(new LeftArrowCombo(playerNumeber));
                }
                else if (copy == 2)
                {
                    AddChild(new UpArrowCombo(playerNumeber));
                }
                else
                {
                    AddChild(new RightArrowCombo(playerNumeber));
                }
            }
        }

        private void ClearArrows() //clears the arrows that are out of the screen
        {
            List<GameObject> gameObjects = this.GetChildren();
            foreach(GameObject child in gameObjects)
            {
                if (child.y > game.height)
                    child.Remove();
            }
            //Console.WriteLine(this.GetChildCount());
        }
    }
}
