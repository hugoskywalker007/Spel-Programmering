using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //medlemsvariabler
        Texture2D ship_texture; //skeppets texture
        Vector2 ship_vector; //skeppets kordinater
        Vector2 ship_speed; //skeppets hastighet

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ship_vector.X = 0;
            ship_vector.Y = 0;
            ship_speed.X = 2.5f;
            ship_speed.Y = 4.5f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            ship_texture = Content.Load<Texture2D>("images/player/ship");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyboardSate = Keyboard.GetState();

            
            if (ship_vector.X <= Window.ClientBounds.Width - ship_texture.Width && ship_vector.X >= 0)
            {
                if (keyboardSate.IsKeyDown(Keys.Right))
                {
                    ship_vector.X += ship_speed.X;
                }
                if (keyboardSate.IsKeyDown(Keys.Left))
                {
                    ship_vector.X -= ship_speed.X;
                }
            }
            
            if (ship_vector.Y <= Window.ClientBounds.Height - ship_texture.Height && ship_vector.Y >= 0)
            {
                if (keyboardSate.IsKeyDown(Keys.Down))
                {
                    ship_vector.Y += ship_speed.Y;
                    ship_vector.Normalize();
                }
                if (keyboardSate.IsKeyDown(Keys.Up))
                {
                    ship_vector.Y -= ship_speed.Y;
                }
            }

            if (ship_vector.X < 0)
            {
                ship_vector.X = 0;
            }
            if (ship_vector.X > Window.ClientBounds.Width - ship_texture.Width)
            {
                ship_vector.X = Window.ClientBounds.Width - ship_texture.Width;
            }

            if (ship_vector.Y < 0)
            {
                ship_vector.Y = 0;
            }
            if (ship_vector.Y > Window.ClientBounds.Height - ship_texture.Height)
            {
                ship_vector.Y = Window.ClientBounds.Height - ship_texture.Height;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(ship_texture, ship_vector, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);

        }
    }
}
