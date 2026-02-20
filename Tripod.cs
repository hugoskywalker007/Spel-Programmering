using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    internal class Tripod : Enemy
    {
        //konstruktor
        public Tripod(Texture2D texture, float X, float Y) : base(texture, X, Y, 0f, 3f)
        {

        }

        //update
        public override void Update(GameWindow window)
        {
            vector.Y += speed.Y;
            if (vector.Y > window.ClientBounds.Height)
            {
                isAlive = false;
            }
        }
    }
}
