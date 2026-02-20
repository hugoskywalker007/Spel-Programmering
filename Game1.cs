using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceShooter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Player player;
        PrintText printText;
        List<Enemy> enemies;
        List<GoldCoin> goldCoins;
        Texture2D goldCoinSprite;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            goldCoins = new List<GoldCoin>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            player =  new Player(Content.Load<Texture2D>("images/player/ship"), 380, 400, 2.5f, 4.5f);
            printText = new PrintText(Content.Load<SpriteFont>("myFont"));

            //skapa fiender
            enemies = new List<Enemy>();
            Random random = new Random();
            Texture2D tmpSprite = Content.Load<Texture2D>("images/enemies/mine");
            for (int i = 0; i < 10; i++)
            {
                int rndX = random.Next(0, Window.ClientBounds.Width - tmpSprite.Width);
                int rndY = random.Next(0, Window.ClientBounds.Height/2);
                Enemy temp = new Enemy(tmpSprite, rndX, rndY);
                enemies.Add(temp);
            }

            goldCoinSprite = Content.Load<Texture2D>("images/powerups/coin");

                _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            player.Update(Window);
            foreach (Enemy e in enemies)
            {
                if (e.IsAlive)
                {
                    if (e.CheckCollision(player))
                    {
                        this.Exit();
                    }
                    e.Update(Window);
                }
                else
                {
                    enemies.Remove(e);
                }
            }

            Random random = new Random();
            int newCoin = random.Next(1, 200);
            if (newCoin == 1)
            {
                int rndX = random.Next(0, Window.ClientBounds.Width - goldCoinSprite.Width);
                int rndY = random.Next(0, Window.ClientBounds.Height - goldCoinSprite.Height);
                goldCoins.Add(new GoldCoin(goldCoinSprite, rndX, rndY, gameTime));
            }
            foreach (GoldCoin gc in goldCoins.ToList())
            {
                if (gc.IsAlive)
                {
                    gc.Update(gameTime);
                    if (gc.CheckCollision(player))
                    {
                        goldCoins.Remove(gc);
                        player.Points++;
                    }
                }
                else
                {
                    goldCoins.Remove(gc);
                }
            }
        }
            

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            player.Draw(_spriteBatch);
            foreach (Enemy e in enemies)
            {
                e.Draw(_spriteBatch);
            }
            //printText.Print("Test Skrift :)", _spriteBatch, 0, 0);
            foreach (GoldCoin gc in goldCoins)
            {
                gc.Draw(_spriteBatch);
                printText.Print("points: " + player.Points, _spriteBatch, 0, 0);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
