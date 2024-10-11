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

    public class CompoundPiece: Piece
    {
        public List<Location> AdditionalPieces = new List<Location>();
        public Rotation Rotation;
    }
}
