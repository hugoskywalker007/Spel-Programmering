using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SpaceShooter
{
    class Player : PhysicalObject
    {
        //medlemsvariabler
        int points = 0;
        //konstruktor
        public Player(Texture2D ship_texture, float X,  float Y, float speedX, float speedY) : base(ship_texture, X, Y, speedX, speedY)
        {
            
        }

        //update
        public void Update(GameWindow Window)
        {
            KeyboardState keyboardSate = Keyboard.GetState();

            if (vector.X <= Window.ClientBounds.Width - texture.Width && vector.X >= 0)
            {
                if (keyboardSate.IsKeyDown(Keys.Right))
                {
                    vector.X += speed.X;
                }
                if (keyboardSate.IsKeyDown(Keys.Left))
                {
                    vector.X -= speed.X;
                }
            }

            if (vector.Y <= Window.ClientBounds.Height - texture.Height && vector.Y >= 0)
            {
                if (keyboardSate.IsKeyDown(Keys.Down))
                {
                    vector.Y += speed.Y;
                }
                if (keyboardSate.IsKeyDown(Keys.Up))
                {
                    vector.Y -= speed.Y;
                }
            }

            if (vector.X < 0)
            {
                vector.X = 0;
            }
            if (vector.X > Window.ClientBounds.Width - texture.Width)
            {
                vector.X = Window.ClientBounds.Width - texture.Width;
            }

            if (vector.Y < 0)
            {
                vector.Y = 0;
            }
            if (vector.Y > Window.ClientBounds.Height - texture.Height)
            {
                vector.Y = Window.ClientBounds.Height - texture.Height;
            }
        }

        //egenskaper
        public int Points { get { return points; } set { points = value; } }
    }
}
