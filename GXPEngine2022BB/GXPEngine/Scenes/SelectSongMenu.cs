namespace GXPEngine.Scenes
{
    class SelectSongMenu : Scene
    {
        SFX sfx;

        SceneManager sceneManager;
        public SelectSongMenu(SceneManager sceneManager, SFX sfx)
        {
            this.sceneManager = sceneManager;
            this.sfx = sfx;

            background = new Sprite("Art/Backgrounds/beat_it_background_final_big.png");
            background.SetXY(0, 0);
            AddChild(background);

            buttons = new Button[4];

            buttons[0] = new Button("Art/Buttons/placeholder_button_menu.png", this.sceneManager, SceneManager.Scenes.DifficultyScene, SFX.Songs.Song1, true);
            buttons[0].SetOrigin(buttons[0].width / 2, buttons[0].height / 2);
            buttons[0].SetXY(game.width / 2, game.height / 5);
            AddChild(buttons[0]);

            buttons[1] = new Button("Art/Buttons/placeholder_button_menu.png", this.sceneManager, SceneManager.Scenes.DifficultyScene, SFX.Songs.Song2, false);
            buttons[1].SetOrigin(buttons[1].width / 2, buttons[1].height / 2);
            buttons[1].SetXY(game.width / 2, 2 * game.height / 5);
            AddChild(buttons[1]);

            buttons[2] = new Button("Art/Buttons/placeholder_button_menu.png", this.sceneManager, SceneManager.Scenes.DifficultyScene, SFX.Songs.Song3, false);
            buttons[2].SetOrigin(buttons[2].width / 2, buttons[2].height / 2);
            buttons[2].SetXY(game.width / 2, 3 * game.height / 5);
            AddChild(buttons[2]);

            buttons[3] = new Button("Art/Buttons/placeholder_button_menu.png", this.sceneManager, SceneManager.Scenes.MainMenu, SFX.Songs.MenuSong, false);
            buttons[3].SetOrigin(buttons[3].width / 2, buttons[3].height / 2);
            buttons[3].SetXY(game.width / 2, 4 * game.height / 5);
            AddChild(buttons[3]);

            sfx.PlaySong(buttons[buttonIndex].desiredSong);
        }

        new private void Update()
        {
            if (buttons != null)
            {
                if (Input.GetKeyDown(Key.A) || Input.GetKeyDown(Key.LEFT))
                {
                    if (buttonIndex > 0)
                    {
                        buttons[buttonIndex].highlighted = false;
                        buttonIndex--;
                        buttons[buttonIndex].highlighted = true;
                        sfx.PlaySong(buttons[buttonIndex].desiredSong);
                    }
                }

                if (Input.GetKeyDown(Key.D) || Input.GetKeyDown(Key.RIGHT))
                {
                    if (buttonIndex < buttons.Length)
                    {
                        buttons[buttonIndex].highlighted = false;
                        buttonIndex++;
                        buttons[buttonIndex].highlighted = true;
                        sfx.PlaySong(buttons[buttonIndex].desiredSong);
                    }
                }
            }
        }
    }
}
