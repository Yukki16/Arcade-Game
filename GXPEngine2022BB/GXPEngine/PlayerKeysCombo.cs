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

        MyGame.Player playerNumeber;

        int keyLeft, keyUp, keyRight; //the custom keys for the input of the player (will be read from Settings)
        public PlayerKeysCombo(MyGame.Player playerNumber)
        {
            this.playerNumeber = playerNumber;

            leftComboArrow = new Sprite("Art/ComboKeySprites/Left.png");
            upComboArrow = new Sprite("Art/ComboKeySprites/Up.png");
            rightComboArrow = new Sprite("Art/ComboKeySprites/Right.png");

            if (playerNumber == MyGame.Player.P1)
            {
                leftComboArrow.SetXY(0, game.height - leftComboArrow.height);
                upComboArrow.SetXY(upComboArrow.width, game.height - upComboArrow.height);
                rightComboArrow.SetXY(rightComboArrow.width * 2, game.height - rightComboArrow.height);
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
            if (Input.GetKey(keyUp))
            {
                if (upArrows[0] != null)
                    if (upArrows[0].y - leftComboArrow.height >= upComboArrow.y)
                    {
                        Console.WriteLine("hitU");
                        upArrows[0].Remove();
                    }
            }
            if (Input.GetKey(keyLeft))
            {
                if (leftArrows[0] != null)
                    if (leftArrows[0].y - leftComboArrow.height >= leftComboArrow.y)
                    {
                        Console.WriteLine("hitL");
                        leftArrows[0].Remove();
                    }
            }
            if (Input.GetKey(keyRight))
            {
                if (rightArrows[0] != null)
                    if (rightArrows[0].y - leftComboArrow.height >= rightComboArrow.y)
                    {
                        Console.WriteLine("hitR");
                        rightArrows[0].Remove();
                    }
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
