using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    static class GameElements
    {
        //medlemsvariabler
        //static Texture2D menuSprite;
        //static Vector2 menuPos;
        static Player player;
        static List<Enemy> enemies;
        static List<GoldCoin> goldCoins;
        static Texture2D goldCoinSprite;
        static PrintText printText;

        //olika gamestates
        public enum State { Menu, Run, HighScore, Quit };
        public static State currentState;

        //initialize
        public static void Initialize()
        {
            goldCoins = new List<GoldCoin>();
        }
        
        //background
        static Background background;

        //menu
        static Menu menu;

        //load
        public static void LoadContent(ContentManager content, GameWindow window)
        {
            //menuSprite = content.Load<Texture2D>("images/menu/menu");
            //menuPos.X = window.ClientBounds.Width / 2 - menuSprite.Width / 2;
            //menuPos.Y = window.ClientBounds.Height / 2 - menuSprite.Height / 2;
            player = new Player(content.Load<Texture2D>("images/player/ship"), 380, 400, 2.5f, 4.5f, content.Load<Texture2D>("images/player/bullet"));

            //skapa fiender
            enemies = new List<Enemy>();
            Random random = new Random();
            Texture2D tmpSprite = content.Load<Texture2D>("images/enemies/mine");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpSprite.Width);
                int rndY = random.Next(0, window.ClientBounds.Height / 2);
                Mine temp = new Mine(tmpSprite, rndX, rndY);
                enemies.Add(temp);
            }
            tmpSprite = content.Load<Texture2D>("images/enemies/tripod");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpSprite.Width);
                int rndY = random.Next(0, window.ClientBounds.Height / 2);
                Tripod temp = new Tripod(tmpSprite, rndX, rndY);
                enemies.Add(temp);
            }

            goldCoinSprite = content.Load<Texture2D>("images/powerups/coin");
            printText = new PrintText(content.Load<SpriteFont>("myFont"));

            background = new Background(content.Load<Texture2D>("images/background/background"), window);

            menu = new Menu((int)State.Menu);
            menu.AddItem(content.Load<Texture2D>("images/menu/start"), (int)State.Run);
            menu.AddItem(content.Load<Texture2D>("images/menu/highscore"), (int)State.HighScore);
            menu.AddItem(content.Load<Texture2D>("images/menu/exit"), (int)State.Quit);

            
        }

        //menu update
        public static State MenuUpdate(GameTime gameTime)
        {
            return (State)menu.Update(gameTime);

            //KeyboardState keyBoardState = Keyboard.GetState();
            //if (keyBoardState.IsKeyDown(Keys.S))
            //{
            //    return State.Run;
            //}
            //if (keyBoardState.IsKeyDown(Keys.H))
            //{
            //    return State.HighScore;
            //}
            //if (keyBoardState.IsKeyDown(Keys.A))
            //{
            //    return State.Quit;
            //}

            //return State.Menu;
        }

        //menu draw
        public static void menuDraw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            menu.Draw(spriteBatch);

            //spriteBatch.Draw(menuSprite, menuPos, Color.White);
        }

        //run update
        public static State RunUpdate(ContentManager content, GameWindow window, GameTime gameTime)
        {
            background.Update(window);

            player.Update(window, gameTime);
            foreach (Enemy e in enemies.ToList())
            {
                foreach (Bullet b in player.Bullets)
                {
                    if (e.CheckCollision(b))
                    {
                        e.IsAlive = false;
                        player.Points++;
                    }
                }
                if (e.IsAlive)
                {
                    if (e.CheckCollision(player))
                    {
                        player.IsAlive = false;
                    }
                    e.Update(window);
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
                int rndX = random.Next(0, window.ClientBounds.Width - goldCoinSprite.Width);
                int rndY = random.Next(0, window.ClientBounds.Height - goldCoinSprite.Height);
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

            if (!player.IsAlive)
            {
                Reset(window, content);
                return State.Menu;
            }
            return State.Run;
        } 

        //run draw
        public static void RunDraw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            player.Draw(spriteBatch);
            foreach (Enemy e in enemies)
            {
                e.Draw(spriteBatch);
            }
            foreach (GoldCoin gc in goldCoins)
            {
                gc.Draw(spriteBatch);
            }
            printText.Print("Points: " + player.Points, spriteBatch, 0, 0);

           
        }

        //highscore update
        public static State HighScoreUpdate()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                return State.Menu;
            }
            return State.HighScore;
        }

        //highscore draw
        public static void HighScoreDraw(SpriteBatch spriteBatch)
        {
            //Rita ut highscore-Listan:
        }

        private static void Reset(GameWindow window, ContentManager content)
        {
            player.Reset(380, 400, 2.5f, 4.5f);
            enemies.Clear();
            Random random = new Random();
            Texture2D tmpSprite = content.Load<Texture2D>("images/enemies/mine");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpSprite.Width);
                int rndY = random.Next(0, window.ClientBounds.Height / 2);
                Mine temp = new Mine(tmpSprite, rndX, rndY);
                enemies.Add(temp);
            }
            tmpSprite = content.Load<Texture2D>("images/enemies/tripod");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpSprite.Width);
                int rndY = random.Next(0, window.ClientBounds.Height / 2);
                Tripod temp = new Tripod(tmpSprite, rndX, rndY);
                enemies.Add(temp);  
            }
        }
    }
}
