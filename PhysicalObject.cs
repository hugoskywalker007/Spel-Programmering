using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SpaceShooter
{
    internal abstract class PhysicalObject : MovingObject
    {
        //medlemsvariabler
        protected bool isAlive = true;

        //konstruktor
        public PhysicalObject(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y, speedX, speedY)
        {

        }

        //kolla kollision
        public bool CheckCollision(PhysicalObject other)
        {
            Rectangle myRect = new Rectangle(Convert.ToInt32(X), Convert.ToInt32(Y), Convert.ToInt32(Width), Convert.ToInt32(Height));
            Rectangle otherRect = new Rectangle(Convert.ToInt32(other.X), Convert.ToInt32(other.Y), Convert.ToInt32(other.Width), Convert.ToInt32(other.Height));
            return myRect.Intersects(otherRect);
        }

        //egenskaper
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }
    }
}
