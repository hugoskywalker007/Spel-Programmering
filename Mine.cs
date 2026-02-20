using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    internal class Mine : Enemy
    {
        //konstruktor
        public Mine(Texture2D texture, float X, float Y) : base(texture, X, Y, 6f, 0.3f)
        {

        }

        //update
        public override void Update(GameWindow window)
        {
            vector.X += speed.X;
            if (vector.X > window.ClientBounds.Width - texture.Width || vector.X < 0)
            {
                speed.X *= -1;
            }
            if (vector.Y > window.ClientBounds.Height)
            {
                isAlive = false;
            }
        }
    }
}
