using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SpaceShooter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //Player player;
        //PrintText printText;
        //List<Enemy> enemies;
        //List<GoldCoin> goldCoins;
        //Texture2D goldCoinSprite;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GameElements.currentState = GameElements.State.Menu;
            GameElements.Initialize();
            //goldCoins = new List<GoldCoin>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            //player =  new Player(Content.Load<Texture2D>("images/player/ship"), 380, 400, 2.5f, 4.5f, Content.Load<Texture2D>("images/player/bullet"));
            //printText = new PrintText(Content.Load<SpriteFont>("myFont"));

            ////skapa fiender
            //enemies = new List<Enemy>();
            //Random random = new Random();
            //Texture2D tmpSprite = Content.Load<Texture2D>("images/enemies/mine");
            //for (int i = 0; i < 10; i++)
            //{
            //    int rndX = random.Next(0, Window.ClientBounds.Width - tmpSprite.Width);
            //    int rndY = random.Next(0, Window.ClientBounds.Height/2);
            //    Mine temp = new Mine(tmpSprite, rndX, rndY);
            //    enemies.Add(temp);
            //}
            //tmpSprite = Content.Load<Texture2D>("images/enemies/tripod");
            //for (int i = 0; i < 5; i++)
            //{
            //    int rndX = random.Next(0, Window.ClientBounds.Width - tmpSprite.Width);
            //    int rndY = random.Next(0, Window.ClientBounds.Height / 2);
            //    Tripod temp = new Tripod(tmpSprite, rndX, rndY);
            //    enemies.Add(temp);
            //}

            //goldCoinSprite = Content.Load<Texture2D>("images/powerups/coin");

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            GameElements.LoadContent(Content, Window);
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                Exit();
            }

            switch (GameElements.currentState)
            {
                case GameElements.State.Run:
                    {
                        GameElements.currentState = GameElements.RunUpdate(Content, Window, gameTime);
                        break;
                    }
                case GameElements.State.HighScore:
                    {
                        GameElements.currentState = GameElements.HighScoreUpdate();
                        break;
                    }
                case GameElements.State.Quit:
                    {
                        this.Exit();
                        break;
                    }
                default:
                    {
                        GameElements.currentState = GameElements.MenuUpdate(gameTime);
                        break;
                    }
            }
            base.Update(gameTime);
            //player.Update(Window, gameTime);
            //foreach (Enemy e in enemies.ToList())
            //{
            //    foreach (Bullet b in player.Bullets)
            //    {
            //        if (e.CheckCollision(b))
            //        {
            //            e.IsAlive = false;
            //            b.IsAlive = false;
            //            player.Points++;
            //        }
            //    }
            //    if (e.IsAlive)
            //    {
            //        if (e.CheckCollision(player))
            //        {
            //            this.Exit();
            //        }
            //        e.Update(Window);
            //    }
            //    else
            //    {
            //        enemies.Remove(e);
            //    }
            //}

            //Random random = new Random();
            //int newCoin = random.Next(1, 200);
            //if (newCoin == 1)
            //{
            //    int rndX = random.Next(0, Window.ClientBounds.Width - goldCoinSprite.Width);
            //    int rndY = random.Next(0, Window.ClientBounds.Height - goldCoinSprite.Height);
            //    goldCoins.Add(new GoldCoin(goldCoinSprite, rndX, rndY, gameTime));
            //}
            //foreach (GoldCoin gc in goldCoins.ToList())
            //{
            //    if (gc.IsAlive)
            //    {
            //        gc.Update(gameTime);
            //        if (gc.CheckCollision(player))
            //        {
            //            goldCoins.Remove(gc);
            //            player.Points++;
            //        }
            //    }
            //    else
            //    {
            //        goldCoins.Remove(gc);
            //    }
            //}
        }
            

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);
            _spriteBatch.Begin();

            //player.Draw(_spriteBatch);
            //foreach (Enemy e in enemies)
            //{
            //    e.Draw(_spriteBatch);
            //}
            ////printText.Print("Test Skrift :)", _spriteBatch, 0, 0);
            //foreach (GoldCoin gc in goldCoins)
            //{
            //    gc.Draw(_spriteBatch);
            //    printText.Print("points: " + player.Points, _spriteBatch, 0, 0);
            //}

            switch (GameElements.currentState)
            {
                case GameElements.State.Run:
                    {
                        GameElements.RunDraw(_spriteBatch);
                        break;
                    }
                case GameElements.State.HighScore:
                    {
                        GameElements.HighScoreDraw(_spriteBatch);
                        break;
                    }
                case GameElements.State.Quit:
                    {
                        this.Exit();
                        break;
                    }
                default:
                    {
                        GameElements.menuDraw(_spriteBatch);
                        break;
                    }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
