using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusSquare
{
    public class Game
    {
        public List<Dice> dice = new List<Dice>();
        public List<CompoundPiece> compoundPieces = new List<CompoundPiece>();


        public Game() {
            // create dice
            dice.Add(new Dice(new string[] { "A6", "A6", "A6", "F1", "F1", "F1" }));
            dice.Add(new Dice(new string[] { "D3", "B4", "C3", "C4", "E3", "D4" }));
            dice.Add(new Dice(new string[] { "D1", "D2", "F3", "A1", "E2", "C1"}));
            dice.Add(new Dice(new string[] { "B1", "B2", "B3", "A2", "A3", "C2" }));
            dice.Add(new Dice(new string[] { "E4", "E5", "F5", "E6", "D5", "F4" }));
            dice.Add(new Dice(new string[] { "B5", "C5", "F6", "D6", "A4", "C6" }));
            dice.Add(new Dice(new string[] { "A5", "F2", "A5", "F2", "B6", "E1" }));

            // create coloured pieces
            compoundPieces.Add(new CompoundPiece(Color.Red, "XX| XX"));
            compoundPieces.Add(new CompoundPiece(Color.Green, "XX|XX"));
            compoundPieces.Add(new CompoundPiece(Color.Yellow, "XXX| X"));
            compoundPieces.Add(new CompoundPiece(Color.Orange, "X|X|X"));
            compoundPieces.Add(new CompoundPiece(Color.Brown, "X|X"));
            compoundPieces.Add(new CompoundPiece(Color.Blue, "X|X|XX"));
            compoundPieces.Add(new CompoundPiece(Color.DarkBlue, "X"));
            compoundPieces.Add(new CompoundPiece(Color.Purple, " X|XX"));
            compoundPieces.Add(new CompoundPiece(Color.Gray, "XXXX"));
        }

    }
}
