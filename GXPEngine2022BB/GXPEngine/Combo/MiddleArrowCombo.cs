namespace GXPEngine
{
    class MiddleArrowCombo : ArrowCombo
    {
        public MiddleArrowCombo(SceneManager.Player playerNumber, SceneManager.Difficulty difficulty, int pozitionInList) : base("Art/ComboKeySprites/Purple_Tile.png", difficulty)
        {
            this.pozitionInList = pozitionInList;
            if (playerNumber == SceneManager.Player.P1)
            {
                this.x = 0 + this.width;
            }
            else
            {
                this.x = game.width - this.width * 2;
            }
        }
    }
}
