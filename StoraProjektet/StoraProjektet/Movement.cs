using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace StoraProjektet
{
    public class Movement
    {
        //KeyboardState oldState;

        public static void Update()
        {
            KeyboardState currentState = Keyboard.GetState();

            if (currentState.IsKeyDown(Keys.Right) /*&& !oldState.IsKeyDown(Keys.Right)*/)
                Move("Right");
            if (currentState.IsKeyDown(Keys.Left) /*&& !oldState.IsKeyDown(Keys.Left)*/)
                Move("Left");
            if (currentState.IsKeyDown(Keys.Down) /*&& !oldState.IsKeyDown(Keys.Down)*/)
                Move("Down");
            if (currentState.IsKeyDown(Keys.Up) /*&& !oldState.IsKeyDown(Keys.Up)*/)
                Move("Up");
            //oldState = currentState;
        }

        public static void Move(string direction)
        {
            switch (direction)
            {
                case "Right":
                    if (!Collision.isColliding("Right"))
                        Game1.charPlace.X += Game1.speed;
                    break;
                case "Left":
                    if (!Collision.isColliding("Left"))
                        Game1.charPlace.X -= Game1.speed;
                    break;
                case "Up":
                    if (!Collision.isColliding("Up"))
                        Game1.charPlace.Y -= Game1.speed;
                    break;
                case "Down":
                    if (!Collision.isColliding("Down"))
                        Game1.charPlace.Y += Game1.speed;
                    break;
            }
        }
    }
}
