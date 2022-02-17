using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine.Scenes
{
    class PauseMenu : Scene
    {
        SceneManager sceneManager;
        GameScene gameScene;
        public PauseMenu(SceneManager sceneManager, GameScene gameScene)
        {
            this.sceneManager = sceneManager;
            this.gameScene = gameScene;

            buttons = new Button[2];

            buttons[0] = new Button("Art/Buttons/menu_button.png", this.sceneManager, SceneManager.Scenes.MainMenu, SFX.Songs.MenuSong, true);
            buttons[0].SetOrigin(buttons[0].width / 2, buttons[0].height / 2);
            buttons[0].SetXY(game.width / 2, game.height / 3);
            AddChild(buttons[0]);
            
            buttons[1] = new Button("Art/Buttons/back_button.png", false, this);
            buttons[1].SetOrigin(buttons[1].width / 2, buttons[1].height / 2);
            buttons[1].SetXY(game.width / 2, 2 * game.height / 3);
            AddChild(buttons[1]);
        }

        public void PauseTheGame(bool pause)
        {
            gameScene.playerOne.paused = pause;
            gameScene.playerOne.PauseComboTiles();

            gameScene.playerTwo.paused = pause;
            gameScene.playerTwo.PauseComboTiles();

            gameScene.sceneUI.paused = pause;

            gameScene.sfx.PauseSong(pause);

            gameScene.addedThePauseMenu = pause;
        }
    }
}
