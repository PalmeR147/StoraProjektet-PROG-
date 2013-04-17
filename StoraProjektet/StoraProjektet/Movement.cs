using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoraProjektet
{
    public class Movement
    {
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
