using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class GameScene : Scene
    {
        Sprite overlay;

        UI sceneUI;

        PlayerKeysCombo playerOne;
        PlayerKeysCombo playerTwo;

        Character playerOneCharacter;
        Character playerTwoCharacter;



        public GameScene(SceneManager.Difficulty difficulty) : base()
        {
            background = new Sprite("Art/Backgrounds/prototype_background_big.png");
            background.SetXY(0, 0);
            this.AddChild(background);

            overlay = new Sprite("Art/Backgrounds/Overlay_Concept.png");
            overlay.SetXY(0, 0);
            this.AddChild(overlay);

            
            playerOne = new PlayerKeysCombo(SceneManager.Player.P1, difficulty, this);
            playerOne.SetKeys(Settings.P1Left, Settings.P1Up, Settings.P1Right);
            this.AddChild(playerOne);

            playerOneCharacter = new Character("Art/Player/char1_idle_sheet.png", SceneManager.Player.P1);

            this.AddChild(playerOneCharacter);

            playerTwo = new PlayerKeysCombo(SceneManager.Player.P2, difficulty, this);
            playerTwo.SetKeys(Settings.P2Left, Settings.P2Up, Settings.P2Right);
            this.AddChild(playerTwo);

            playerTwoCharacter = new Character("Art/Player/char1_idle_sheet.png", SceneManager.Player.P2);

            this.AddChild(playerTwoCharacter);

            sceneUI = new UI();
            sceneUI.SetXY(0, 0);
            this.AddChild(sceneUI);
        }

        public void InflictDamage()
        {
           
                int tempComboScoreP1 = playerOne.ReturnComboScore();
                int tempComboScoreP2 = playerTwo.ReturnComboScore();

                if (tempComboScoreP1 == tempComboScoreP2)
                {
                    playerOneCharacter.ChangeState();
                    playerTwoCharacter.ChangeState();
                }
                else if (tempComboScoreP1 > tempComboScoreP2)
                {
                    playerOneCharacter.ChangeState();
                    playerTwoCharacter.ChangeState();
                    sceneUI.playerTwoHp--;
                }
                else
                {
                    playerOneCharacter.ChangeState();
                    playerTwoCharacter.ChangeState();
                    sceneUI.playerOneHp--;
                }
                sceneUI.UpdateHealth();
            
        }
    }
}
