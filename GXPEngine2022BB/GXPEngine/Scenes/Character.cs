using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Character : GameObject
    {
        public enum playerState
        {
            idle,
            attack,
            defence
        }

        playerState animationState = playerState.idle;

        AnimationSprite animations;
        public Character(string characterName, SceneManager.Player playerNumber)
        {
            animations = new AnimationSprite(characterName, 10, 5);
            if (playerNumber == SceneManager.Player.P1)
            {
                animations.SetOrigin(animations.width / 2, animations.height / 2);
                animations.SetXY(game.width / 2.25f, game.height / 1.5f);
                animations.Mirror(true, false);
            }
            else
            {
                animations.SetOrigin(animations.width / 2, animations.height / 2);
                animations.SetXY(game.width / 1.75f, game.height / 1.5f);
                animations.Mirror(false, false);
            }
            AddChild(animations);
        }

        private void Update()
        {

            if (animationState == playerState.idle)
            {
                animations.SetCycle(40, 10);
            }

            if (animationState == playerState.defence)
            {
                animations.SetCycle(20, 10);
            }

            if (animationState == playerState.attack)
            {
                animations.SetCycle(30, 10);
            }
            
            if(animations.currentFrame == 29 || animations.currentFrame == 39)
            {
                animationState = playerState.idle;
            }
            animations.Animate(0.075f);
        }

        public void ChangeState(playerState state)
        {
            animationState = state;
        }
    }
}
