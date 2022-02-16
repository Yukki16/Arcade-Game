﻿using System;
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

            playerOneCharacter = new Character("Art/Player/character_spritesheet.png", SceneManager.Player.P1);

            this.AddChild(playerOneCharacter);

            playerTwo = new PlayerKeysCombo(SceneManager.Player.P2, difficulty, this);
            playerTwo.SetKeys(Settings.P2Left, Settings.P2Up, Settings.P2Right);
            this.AddChild(playerTwo);

            playerTwoCharacter = new Character("Art/Player/character_spritesheet.png", SceneManager.Player.P2);

            this.AddChild(playerTwoCharacter);

            sceneUI = new UI();
            sceneUI.SetXY(0, 0);
            this.AddChild(sceneUI);
        }

        public void InflictDamage(int numberInList)
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
                if(arrows.pozitionInList == numberInList)
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
            }
            //inflictDamage = true;

        }
        public void UpdateComboUI()
        {
            sceneUI.UpdateCombo(playerOne.comboHit, playerTwo.comboHit);
        }
    }
}
