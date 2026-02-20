using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    internal class MovingObject : GameObject
    {
        //medlemsvariabler
        protected Vector2 speed; 
        
        //konstruktor
        public MovingObject(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y)
        {
            this.speed.X = speedX;
            this.speed.Y = speedY;
        }
    }
}
