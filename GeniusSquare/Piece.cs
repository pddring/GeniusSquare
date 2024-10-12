using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusSquare
{
    public class Piece
    {
        public Location Location = new Location();
        public Color Color;
    }

    

    public enum Rotation
    {
        NoRotation,
        Rotated90CW,
        Rotated180CW,
        Rotated270CW
    }

    public enum Direction
    {
        FaceUp,
        FaceDown
    }

    public class CompoundPiece: Piece
    {
        public List<Location> AdditionalPieces = new List<Location>();
        public Rotation Rotation;
        public Direction Direction;
        int width;
        int height;

        public void Rotate()
        {
            switch(Rotation)
            {
                case Rotation.NoRotation:
                    Rotation = Rotation.Rotated90CW;
                    break;
                case Rotation.Rotated90CW:
                    Rotation = Rotation.Rotated180CW;
                    break;
                case Rotation.Rotated180CW:
                    Rotation = Rotation.Rotated270CW;
                    break;
                case Rotation.Rotated270CW:
                    Rotation = Rotation.NoRotation;
                    break;
            }
        }

        /// <summary>
        /// Create a new compound piece
        /// </summary>
        /// <param name="c"></param>
        /// <param name="definition">Text description using X, spaces and new lines
        /// to represent pieces e.g. XX| XX for a Z shape</param>
        public CompoundPiece(Color c, string definition)
        {
            Color = c;
            Rotation = Rotation.NoRotation;
            Location = new Location();
            Direction = Direction.FaceUp;
            string[] lines = definition.Split("|");
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    if (lines[y][x] == 'X')
                    {
                        AdditionalPieces.Add(new Location()
                        {
                            Row = y,
                            Column = x
                        });
                        if(x > width)
                        {
                            width = x;
                        }
                        if(y > height)
                        {
                            height = y;
                        }
                    }
                }
            }          
        }
        public List<Location> GetLocations()
        {
            List<Location> locations = new List<Location>();
            foreach (Location location in AdditionalPieces)
            {
                Location l = new Location()
                {
                    Row = location.Row,
                    Column = location.Column
                };
                if(Direction == Direction.FaceDown)
                {
                    // (x,y) becomes (-x,y)
                    l.Column = width - l.Column;
                }
                switch (Rotation)
                {
                    case Rotation.NoRotation:
                        locations.Add(new Location()
                        {
                            Row = l.Row,
                            Column = l.Column
                        });
                        break;
                    case Rotation.Rotated90CW:
                        // (x,y) becomes (y,-x)
                        locations.Add(new Location()
                        {
                            Row = width -l.Column,
                            Column = l.Row
                        });
                        break;
                    case Rotation.Rotated180CW:
                        // (x,y) becomes (-x,-y)
                        locations.Add(new Location()
                        {
                            Row = height - l.Row,
                            Column = width - l.Column
                        });
                        break;
                    case Rotation.Rotated270CW:
                        // (x,y) becomes (-y,x)
                        locations.Add(new Location()
                        {
                            Row = l.Column,
                            Column = height-l.Row
                        });
                        break;
                }
            }
            return locations;
        }

        public List<string> GetAllCombinations()
        {
            List<string> combinations = new List<string>();
            Rotation currentRotation = Rotation;
            Direction currentDirection = Direction;
            foreach (Rotation r in Enum.GetValues(typeof(Rotation))) {
                foreach (Direction d in Enum.GetValues(typeof(Direction)))
                {
                    Rotation = r;
                    Direction = d;
                    if(!combinations.Contains(this.ToString()))
                    {
                        combinations.Add(this.ToString());
                    }
                }
            }
            return combinations;
        }

        public override string ToString()
        {
            List<Location> locations = GetLocations();
            int width = 0;
            int height = 0;

            foreach (Location location in locations)
            {
                if(location.Column > width) width = location.Column;
                if(location.Row > height) height = location.Row;
            }

            bool[,] grid = new bool[height + 1, width + 1];
            foreach(Location location in locations)
            {
                grid[location.Row, location.Column] = true;
            }
            string s = "";
            for (int y = 0; y <= height; y++)
            {
                for (int x = 0; x <= width; x++)
                {
                    s += grid[y, x] ? "X" : " ";
                }
                if (y < height)
                {
                    s += "|";
                }
            }
            return s;
        }
    }
}
