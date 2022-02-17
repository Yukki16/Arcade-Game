namespace GXPEngine
{
    class LeftArrowCombo : ArrowCombo
    {

        public LeftArrowCombo(SceneManager.Player playerNumber, SceneManager.Difficulty difficulty, int pozitionInList) : base("Art/ComboKeySprites/Pink_Tile.png", difficulty)
        {
            this.pozitionInList = pozitionInList;
            if (playerNumber == SceneManager.Player.P1)
            {
                this.x = 0;
            }
            else
            {
                this.x = game.width - this.width * 3;
            }
        }
    }
}
