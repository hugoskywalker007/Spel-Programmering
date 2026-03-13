using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    internal class MenuItem
    {
        Texture2D texture;
        Vector2 position;
        int currentState;

        //konstruktor
        public MenuItem(Texture2D texture, Vector2 position, int CurrentState)
        {
            this.texture = texture;
            this.position = position;
            this.currentState = CurrentState;
        }

        //egenskaper
        public Texture2D Texture { get { return texture; } }
        public Vector2 Position { get { return position; } }
        public int CurrentState { get { return currentState; } }
    }
}
