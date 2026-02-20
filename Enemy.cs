using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    internal abstract class Enemy : PhysicalObject
    {
        //medlemsvariabler

        //konstruktor
        public Enemy(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X , Y, speedX, speedY)
        {

        }

        //update
        public abstract void Update(GameWindow window);

        //egenskaper
    }
}
