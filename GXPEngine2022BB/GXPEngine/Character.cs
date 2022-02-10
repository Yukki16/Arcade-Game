using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Character : GameObject
    {
        private enum playerState
        {
            idle,
            attack,
            defence
        }
        AnimationSprite idleAnimation;
        public Character(string characterName, SceneManager.Player playerNumber)
        {
            idleAnimation = new AnimationSprite(characterName, 5, 2);
            if (playerNumber == SceneManager.Player.P1)
            {
                idleAnimation.SetOrigin(idleAnimation.width / 2, idleAnimation.height / 2);
                idleAnimation.SetXY(game.width / 3f, game.height / 1.5f);
                idleAnimation.Mirror(true, false);
            }else
            {
                idleAnimation.SetOrigin(idleAnimation.width / 2, idleAnimation.height / 2);
                idleAnimation.SetXY(game.width / 1.5f, game.height / 1.5f);
                idleAnimation.Mirror(false, false);
            }
            AddChild(idleAnimation);
        }

        private void Update()
        {
            idleAnimation.Animate(0.075f);
        }

        public void ChangeState()
        {

        }
    }
}
