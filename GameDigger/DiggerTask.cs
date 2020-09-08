using System;
using System.Windows.Forms;


namespace Digger
{
    //Напишите здесь классы Player, Terrain и другие.
    public class Terrain : ICreature
    {
        public string GetImageFileName()
        {
            return "Terrain.png";
        }

        public int GetDrawingPriority()
        {
            return 5;
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Player;
        }
    }

    public class Player : ICreature
    {

        public string GetImageFileName()
        {
            return "Digger.png";
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public CreatureCommand Act(int x, int y)
        {
            var deltaX = 0;
            var deltaY = 0;

            switch (Game.KeyPressed)
            {
                case Keys.Left when x != 0 
                                    && !(Game.Map[x-1, y] is Sack):
                    deltaX -= 1;
                    break;
                case Keys.Right when x != Game.MapWidth - 1 
                                     && !(Game.Map[x + 1, y] is Sack):
                    deltaX += 1;
                    break;
                case Keys.Up when y != 0 
                                  && !(Game.Map[x, y - 1] is Sack):
                    deltaY -= 1;
                    break;
                case Keys.Down when y != Game.MapHeight - 1 
                                    && !(Game.Map[x, y + 1] is Sack):
                    deltaY += 1;
                    break;
            }

            {
                return new CreatureCommand
                {
                    DeltaX = deltaX,
                    DeltaY = deltaY
                };
            }
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Sack || conflictedObject is Monster)
            {
                Game.IsOver = true;
                return true;
            }
            return false;
        }
    }

    public class Sack : ICreature
    {
        public int MaxSectorsToDrop;
        public string GetImageFileName()
        {
            return "Sack.png";
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public CreatureCommand Act(int x, int y)
        {
            if (AllowToFallDown(x, y, 1))
            {
                MaxSectorsToDrop++;
                Act(x, y - 1);
            }
            else
            {
                if (MaxSectorsToDrop > 1)
                    return new CreatureCommand { TransformTo = new Gold() };
                if (MaxSectorsToDrop == 1 && (y+1 == Game.MapHeight || Game.Map[x,y+1] is Terrain)) 
                    MaxSectorsToDrop = 0;
                return new CreatureCommand();
            }

            return new CreatureCommand {DeltaY = 1};

        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public bool AllowToFallDown(int x, int y, int delta)
        {
            if (delta <= 0 || y + delta == Game.MapHeight) return false;
            var bottomCreature = Game.Map[x, y + delta];
            if ((bottomCreature is Player && MaxSectorsToDrop > 0) 
                || bottomCreature is Monster && MaxSectorsToDrop > 0
                )
                return true;
            return bottomCreature is null;
        }
    }

    public class Gold : ICreature
    {
        public string GetImageFileName()
        {
            return "Gold.png";
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Player)
            {
                Game.Scores += 10;
                return true;
            }
            return conflictedObject is Monster;
        }
    }

    public class Monster : ICreature
    {
        public string GetImageFileName()
        {
            return "Monster.png";
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public CreatureCommand Act(int x, int y)
        {
            var playerCoords = FindDigger();
            var playerX = playerCoords[0];
            var playerY = playerCoords[1];
            // расстояние до диггера
            var dX = x - playerX;
            var dY = y - playerY;
            // направление движения
            var moveX = DirectionToMove(dX);
            var moveY = DirectionToMove(dY);

            //if (!AnyControlKeyPressed())return new CreatureCommand();
            if (Math.Abs(dX) > Math.Abs(dY))
            { // двигаться по X
                if (AllowToMove(x,y, moveX, 0))
                    return new CreatureCommand {DeltaX = moveX };
            } 
            return AllowToMove(x,y,0, moveY) ? new CreatureCommand {DeltaY = moveY } : new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Sack || conflictedObject is Monster;
        }
        
        public int DirectionToMove(int delta)
        {
            if (delta > 0)
                return -1;
            if (delta < 0)
                return 1;
            return 0;
        }

        public bool AllowToMove(int x, int y, int dX, int dY)
        {
            var newX = x + dX;
            var newY = y + dY;
            var result = false;
            if (dY == 0)
                result = !(newX < 0 || 
                           newX >= Game.MapWidth || 
                           Game.Map[newX, y] is Sack ||
                           Game.Map[newX, y] is Terrain ||
                           Game.Map[newX, y] is Monster ||
                           Game.IsOver == true);
            if (dX == 0)
                result = !(newY < 0 ||
                           newY >= Game.MapHeight ||
                           Game.Map[x, newY] is Sack ||
                           Game.Map[x, newY] is Terrain ||
                           Game.Map[x, newY] is Monster ||
                           Game.IsOver == true);
            return result;
        }

        public int[] FindDigger()
        {
            var diggerCoords = new int[2] {0, 0};
            for (int i = 0; i < Game.Map.GetLength(0); i++)
            {
                for (int j = 0; j < Game.Map.GetLength(1); j++)
                {
                    if (Game.Map[i, j] is Player)
                    {
                        diggerCoords[0] = i;
                        diggerCoords[1] = j;
                        break;
                    }
                }
            }

            return diggerCoords;
        }

        //public bool AnyControlKeyPressed ()
        //{
        //    return true;
        //    //return Game.KeyPressed >= Keys.Left && Game.KeyPressed <= Keys.Down;
            
        //    //var allPossibleKeys = Enum.GetValues(typeof(Key));
        //    //bool results = false;
        //    //foreach (var currentKey in allPossibleKeys)
        //    //{
        //    //    Key key = (Key)currentKey;
        //    //    if (key != Key.None)
        //    //        if (Keyboard.IsKeyDown((Key)currentKey)) { results = true; break; }
        //    //}
        //    //return results;
        //}
    }
}
