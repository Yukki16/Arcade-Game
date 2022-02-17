namespace GXPEngine
{
    class Character : GameObject
    {
        public enum playerState
        {
            idle,
            attack,
            defence,
            defeated,
            winner
        }

        playerState animationState = playerState.idle;

        AnimationSprite animations;

        bool stopAnimating = false;
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

            if (animationState == playerState.defeated)
            {
                animations.SetCycle(10, 10);
            }

            if (animationState == playerState.winner)
            {
                animations.SetCycle(0, 10);
            }

            if (animations.currentFrame == 29 || animations.currentFrame == 39)
            {
                animationState = playerState.idle;
            }

            if (animations.currentFrame == 19 || animations.currentFrame == 9)
                stopAnimating = true;

            if (!stopAnimating)
                animations.Animate(0.075f);

            // System.Console.WriteLine(animations.currentFrame);
        }

        public void ChangeState(playerState state)
        {
            if (animationState != playerState.defeated)
                animationState = state;
        }
    }
}
