using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class GameScene : Scene
    {
        Timer timer;

        PlayerKeysCombo playerOne;
        PlayerKeysCombo playerTwo;
        public GameScene(SceneManager.Difficulty difficulty) : base()
        {
            background = new Sprite("Art/Backgrounds/Overlay_Concept.png");
            background.SetXY(0, 0);
            this.AddChild(background);

            playerOne = new PlayerKeysCombo(SceneManager.Player.P1, difficulty);
            playerOne.SetKeys(Settings.P1Left, Settings.P1Up, Settings.P1Right);
            this.AddChild(playerOne);

            playerTwo = new PlayerKeysCombo(SceneManager.Player.P2, difficulty);
            playerTwo.SetKeys(Settings.P2Left, Settings.P2Up, Settings.P2Right);
            this.AddChild(playerTwo);

            timer = new Timer();
            timer.SetXY(0, 0);
            this.AddChild(timer);
        }
    }
}
