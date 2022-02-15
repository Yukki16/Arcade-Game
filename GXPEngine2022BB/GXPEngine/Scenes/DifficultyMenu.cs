using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine.Scenes
{
    class DifficultyMenu : Scene
    {
        SceneManager sceneManager;
        public DifficultyMenu(SceneManager sceneManager, SFX.Songs songToLoad)
        {
            this.sceneManager = sceneManager;

            background = new Sprite("Art/Backgrounds/prototype_background_big.png");
            background.SetXY(0, 0);
            AddChild(background);

            buttons = new Button[4];

            buttons[0] = new Button("Art/Buttons/placeholder_button_menu.png", this.sceneManager, SceneManager.Scenes.SongMenu, SFX.Songs.None, false);
            buttons[0].SetOrigin(buttons[0].width / 2, buttons[0].height / 2);
            buttons[0].SetXY(0, 0);
            AddChild(buttons[0]);

            buttons[1] = new Button("Art/Buttons/placeholder_button_menu.png", this.sceneManager, SceneManager.Scenes.GameScene, songToLoad, true, SceneManager.Difficulty.Easy);
            buttons[1].SetOrigin(buttons[1].width / 2, buttons[1].height / 2);
            buttons[1].SetXY(game.width / 2, 300);
            AddChild(buttons[1]);

            buttons[2] = new Button("Art/Buttons/placeholder_button_menu.png", this.sceneManager, SceneManager.Scenes.GameScene, songToLoad, false, SceneManager.Difficulty.Medium);
            buttons[2].SetOrigin(buttons[2].width / 2, buttons[2].height / 2);
            buttons[2].SetXY(game.width / 2, 500);
            AddChild(buttons[2]);

            buttons[3] = new Button("Art/Buttons/placeholder_button_menu.png", this.sceneManager, SceneManager.Scenes.GameScene, songToLoad, false, SceneManager.Difficulty.Hard);
            buttons[3].SetOrigin(buttons[3].width / 2, buttons[3].height / 2);
            buttons[3].SetXY(game.width / 2, 700);
            AddChild(buttons[3]);

            buttonIndex = 1;
        }
    }
}
