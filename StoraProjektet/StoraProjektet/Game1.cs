﻿using System;
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
                    if (Maps.map1[y, x] == 1)
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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        
        //Vektorer:
        Vector2 charPlace = new Vector2(500, 250);
        Vector2 enemyPlace = new Vector2(150, 150);

        //Texturer:
        Texture2D character;
        Texture2D enemy;
        List<Texture2D> tiles = new List<Texture2D>();
        List<Rectangle> collisionTiles = new List<Rectangle>();

        //Variabler
        float speed = 5f;
        int tileWidth = 24;
        int tileHeight = 24;


        /*int[,] map = {
            {1,0,1,0},
            {1,0,1,0},
            {1,0,1,0},
            {1,0,1,0},
            {1,0,1,0},
            {1,0,1,0},
            {1,0,1,0}
                    };*/


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            character = Content.Load<Texture2D>("Capture");
            enemy = Content.Load<Texture2D>("ENAMI");

            tiles.Add(Content.Load<Texture2D>("grass_tile"));
            tiles.Add(Content.Load<Texture2D>("imgres"));
            
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
            Rectangle charBox = new Rectangle(Convert.ToInt32(charPlace.X), Convert.ToInt32(charPlace.Y), character.Width, character.Height);
            Rectangle enemyBox = new Rectangle(Convert.ToInt32(enemyPlace.X), Convert.ToInt32(enemyPlace.Y), enemy.Width, enemy.Height);
            /*if (charBox.Intersects(enemyBox))
                speed = 1f;
            else
                speed = 5f;*/

            for (int i = 0; i < collisionTiles.Count; i++ )
            {
                if (charBox.Intersects(collisionTiles[i]))
                    speed = 0;
            }
            

            int maxX = graphics.GraphicsDevice.Viewport.Width - character.Width;
            int maxY = graphics.GraphicsDevice.Viewport.Height - character.Height;
            int minX = 0;
            int minY = 0;

            if (charPlace.X > maxX){
                speed = 0f;
                charPlace.X = maxX;
            }
            if (charPlace.X < minX)
            {
                speed = 0f;
                charPlace.X = minX;
            }
            if (charPlace.Y > maxY)
            {
                speed = 0f;
                charPlace.Y = maxY;
            }
            if (charPlace.Y < minY)
            {
                speed = 0f;
                charPlace.Y = minY;
            }
            //else
                //speed = 5f;



            updateInput();
            base.Update(gameTime);
        }

        private void updateInput()
        {
            KeyboardState currentState = Keyboard.GetState();

            if (currentState.IsKeyDown(Keys.Right))
                charPlace.X += speed;
            if (currentState.IsKeyDown(Keys.Left))
                charPlace.X -= speed;
            if (currentState.IsKeyDown(Keys.Down))
                charPlace.Y += speed;
            if (currentState.IsKeyDown(Keys.Up))
                charPlace.Y -= speed;
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
                    spriteBatch.Draw(tiles[Maps.map1[y,x]], new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight), Color.White);
                }
            }
            //^Map^
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(character, charPlace, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}