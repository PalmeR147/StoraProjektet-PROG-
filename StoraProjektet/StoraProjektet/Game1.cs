using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace StoraProjektet
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public Game1()
        {
            IsMouseVisible = true;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            for (int y = 0; y < Maps.map1.GetLength(0); y++)
            {
                for (int x = 0; x < Maps.map1.GetLength(1); x++)
                {
                    if (Maps.map1[y, x] == 0 || Maps.map1[y,x] == 2)
                    {
                        collisionTiles.Add(new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight));
                    }
                }
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            oldState = Keyboard.GetState();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>

        public static int gameSize = 16;
        //Vektorer:
        public static Vector2 charPlace = new Vector2(gameSize, 0);
        //Vector2 walkBoxP = new Vector2(256, 256);
        Vector2 enemyPlace = new Vector2(150, 150);

        //Texturer & rektanglar:
        public static Texture2D character;
        Texture2D enemy;
        Texture2D test;
        Texture2D tileSet;
        List<Texture2D> tiles = new List<Texture2D>();
        public static List<Rectangle> collisionTiles = new List<Rectangle>();

        //Variabler
        public static float speed = gameSize;
        public static int charWidth = Convert.ToInt32(0.125 * gameSize);
        public static int charHeight = Convert.ToInt32(0.125 * gameSize);
        int tileWidth = gameSize;
        int tileHeight = gameSize;

        //Övrigt
        KeyboardState oldState;


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            character = Content.Load<Texture2D>("Textures/Char");
            enemy = Content.Load<Texture2D>("ENAMI");
            test = Content.Load<Texture2D>("Textures/Namnlös");

            tileSet = Content.Load<Texture2D>("Textures/TileSets/tileset");

            tiles.Add(Content.Load<Texture2D>("grass_tile"));
            tiles.Add(Content.Load<Texture2D>("imgres"));
            tiles.Add(Content.Load<Texture2D>("Textures/water"));

            Player p1 = new Player(150, 150);
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            // TODO: Add your update logic here
            //Rektanglar / Hitboxes
            //Rectangle walkBox = new Rectangle(Convert.ToInt32(charPlace.X), Convert.ToInt32(charPlace.Y), character.Width, character.Height);
            Rectangle charBox = new Rectangle(Convert.ToInt32(charPlace.X), Convert.ToInt32(charPlace.Y), character.Width, character.Height);
            Rectangle enemyBox = new Rectangle(Convert.ToInt32(enemyPlace.X), Convert.ToInt32(enemyPlace.Y), enemy.Width, enemy.Height);
            
            int maxX = graphics.GraphicsDevice.Viewport.Width - charWidth;
            int maxY = graphics.GraphicsDevice.Viewport.Height - charHeight;
            int minX = 0;
            int minY = 0;

            if (charPlace.X > maxX){
                //speed = 0f;
                charPlace.X = maxX;
            }
            if (charPlace.X < minX)
            {
                //speed = 0f;
                charPlace.X = minX;
            }
            if (charPlace.Y > maxY)
            {
                //speed = 0f;
                charPlace.Y = maxY;
            }
            if (charPlace.Y < minY)
            {
                //speed = 0f;
                charPlace.Y = minY;
            }
            //else
                //speed = 5f;



            Movement.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            //spriteBatch.Draw(enemy, enemyPlace, Color.White);

            //Map'en
            for (int y = 0; y < Maps.map1.GetLength(0); y++)
            {
                for (int x = 0; x < Maps.map1.GetLength(1); x++)
                {
                    //spriteBatch.Draw(tiles[Maps.map1[y,x]], new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight), new Rectangle(5,5,25,25), Color.White);
                    spriteBatch.Draw(tileSet, new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight), new Rectangle(Maps.map1[y,x]*48, 0, 48, 48), Color.White);
                }
            }
            //^Map^


            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            /*for (int i = 0; i < collisionTiles.Count; i++)
            {
                spriteBatch.Draw(test, collisionTiles[i], Color.White);
            }*/
            spriteBatch.Draw(character, new Rectangle(Convert.ToInt32(charPlace.X) + charWidth, Convert.ToInt32(charPlace.Y) + charHeight, Convert.ToInt32((0.75 * gameSize)), Convert.ToInt32((0.75 * gameSize))), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
            
        }
    }
}
