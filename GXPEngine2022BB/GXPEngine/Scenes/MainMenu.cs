using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine.Scenes
{
    class MainMenu : Scene
    {
        

        SceneManager sceneManager;

        public MainMenu(SceneManager sceneManager)
        {
            this.sceneManager = sceneManager;
            buttons = new Button[3];

            background = new Sprite("Art/Backgrounds/prototype_background_big.png");
            background.SetXY(0, 0);
            this.AddChild(background);

            buttons[0] = new Button("Art/Buttons/placeholder_button_menu.png", this.sceneManager, SceneManager.Scenes.SongMenu, SFX.Songs.None, true);
            buttons[0].SetOrigin(buttons[0].width / 2, buttons[0].height / 2);
            buttons[0].SetXY(game.width / 2, 300);
            AddChild(buttons[0]);

            buttons[1] = new Button("Art/Buttons/placeholder_button_menu.png", this.sceneManager, SceneManager.Scenes.Settings, SFX.Songs.None, false);
            buttons[1].SetOrigin(buttons[1].width / 2, buttons[1].height / 2);
            buttons[1].SetXY(game.width / 2, 500);
            AddChild(buttons[1]);

            buttons[2] = new Button("Art/Buttons/placeholder_button_menu.png", this.sceneManager, SceneManager.Scenes.HighScore, SFX.Songs.None, false);
            buttons[2].SetOrigin(buttons[2].width / 2, buttons[2].height / 2);
            buttons[2].SetXY(game.width / 2, 700);
            AddChild(buttons[2]);

        }

        
    }
}
