using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    internal class GoldCoin : PhysicalObject
    {
        //medlemsvariabler
        double timeToDie;

        //konstruktor
        public GoldCoin(Texture2D texture, float X, float Y, GameTime gameTime) : base(texture, X, Y, 0f, 2f)
        {
            timeToDie = gameTime.TotalGameTime.TotalMilliseconds + 5000;
        }

        //update
        public void Update(GameTime gameTime)
        {
            if (timeToDie < gameTime.TotalGameTime.TotalMilliseconds)
            {
                isAlive = false;
            }
        }
    }
}
