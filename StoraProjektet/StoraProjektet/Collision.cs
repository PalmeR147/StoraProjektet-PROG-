using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace StoraProjektet
{
    public class Collision
    {
        public static bool isColliding(string direction)
        {
            int testCharX = Convert.ToInt32(Game1.charPlace.X);
            int testCharY = Convert.ToInt32(Game1.charPlace.Y);
            int col = 0;
            Rectangle testCol;
            switch (direction)
            {

                case "Right":
                    testCharX += Convert.ToInt32(Game1.speed);
                    testCol = new Rectangle(testCharX, testCharY, Game1.charWidth, Game1.charHeight);
                    for (int i = 0; i < Game1.collisionTiles.Count; i++)
                    {
                        if (testCol.Intersects(Game1.collisionTiles[i]))
                            col++;
                    }
                    if (col > 0)
                        return true;
                    else
                        return false;

                case "Left":
                    testCharX -= Convert.ToInt32(Game1.speed);
                    testCol = new Rectangle(testCharX, testCharY, Game1.charWidth, Game1.charHeight);
                    for (int i = 0; i < Game1.collisionTiles.Count; i++)
                    {
                        if (testCol.Intersects(Game1.collisionTiles[i]))
                            col++;
                    }
                    if (col > 0)
                        return true;
                    else
                        return false;

                case "Down":
                    testCharY += Convert.ToInt32(Game1.speed);
                    testCol = new Rectangle(testCharX, testCharY, Game1.charWidth, Game1.charHeight);
                    for (int i = 0; i < Game1.collisionTiles.Count; i++)
                    {
                        if (testCol.Intersects(Game1.collisionTiles[i]))
                            col++;
                    }
                    if (col > 0)
                        return true;
                    else
                        return false;

                case "Up":
                    testCharY -= Convert.ToInt32(Game1.speed);
                    testCol = new Rectangle(testCharX, testCharY, Game1.charWidth, Game1.charHeight);
                    for (int i = 0; i < Game1.collisionTiles.Count; i++)
                    {
                        if (testCol.Intersects(Game1.collisionTiles[i]))
                            col++;
                    }
                    if (col > 0)
                        return true;
                    else
                        return false;
            }

            return false;
        }
    }

}
