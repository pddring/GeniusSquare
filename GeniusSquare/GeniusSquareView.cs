using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeniusSquare
{
    public partial class GeniusSquareView : UserControl
    {
        private int rows = 8;
        [Browsable(true)]
        public int Rows
        {
            get
            {
                return rows;
            }
            set
            {
                rows = value;
                if (rows > 9) rows = 9;
                if (rows < 1) rows = 1;
                blockHeight = (Height - (border * 2)) / (Rows + 1);
            }
        }

        private int cols = 8;
        [Browsable(true)]
        public int Cols
        {
            get
            {
                return cols;
            }
            set
            {
                cols = value;
                if (cols > 9) cols = 9;
                if (cols < 1) cols = 1;
                blockWidth = (Width - (border * 2)) / (Cols + 1);

            }
        }
        public GeniusSquareView()
        {
            Rows = 8;
            Cols = 8;
            InitializeComponent();
            blockWidth = (Width - (border * 2)) / (Cols + 1);
            blockHeight = (Height - (border * 2)) / (Rows + 1);
        }

        public List<Piece> Pieces = new List<Piece>();

        protected int GetX(int Col)
        {
            return border + (1 + Col) * blockWidth;
        }

        public bool HitTest(int x, int y)
        {
            return x > GetX(0) && x < GetY(Cols)
                && y > GetY(0) && y < GetY(Rows);
        }

        Location? LocationFromXY(int x, int y)
        {
            if(HitTest(x, y))
            {
                Location l = new Location();
                l.Column = ((x - border) / blockWidth) - 1;
                l.Row = ((y - border) / blockHeight) - 1;
                return l;
            }
            return null;
        }

        protected int GetY(int Row)
        {
            return border + (1 + Row) * blockHeight;
        }
        public int border = 5;

        int blockWidth;
        int blockHeight;

        private void GeniusSquareView_Paint(object sender, PaintEventArgs e)
        {
            if (Rows < 1) Rows = 1;
            if (Cols < 1) Cols = 1;

            Pen p = new Pen(Color.Black);

            e.Graphics.Clear(Color.White);
            // draw vertical lines
            for (int x = 0; x <= Cols; x++)
            {
                e.Graphics.DrawLine(p,
                    GetX(x), GetY(0),
                    GetX(x), GetY(Rows));
            }

            // draw horizontal lines
            for (int y = 0; y <= Rows; y++)
            {
                e.Graphics.DrawLine(p,
                    GetX(0), GetY(y),
                    GetX(Cols), GetY(y));
            }


            Font font = new Font("Arial", 24);
            Brush brush = new SolidBrush(Color.Black);
            StringFormat stringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // draw column labels
            for (int x = 0; x < Cols; x++)
            {
                Rectangle r = new Rectangle(GetX(x), GetY(-1),
                    blockWidth, blockHeight);
                e.Graphics.DrawString($"{x + 1}", font, brush, r, stringFormat);
            }

            // draw row labels
            for (int y = 0; y < Cols; y++)
            {
                char label = (char)('A' + y);
                Rectangle r = new Rectangle(GetX(-1), GetY(y),
                    blockWidth, blockHeight);
                e.Graphics.DrawString($"{label}", font, brush, r, stringFormat);
            }

            // draw pieces
            foreach (Piece piece in Pieces)
            {
                Rectangle r = new Rectangle(GetX(piece.Location.Column) + 1, GetY(piece.Location.Row) + 1,
                    blockWidth - 2, blockHeight - 2);
                e.Graphics.FillRectangle(new SolidBrush(piece.Color), r);
            }

            // draw selection
            if(selectedLocation != null)
            {
                Rectangle r = new Rectangle(GetX(selectedLocation.Column) + 2, GetY(selectedLocation.Row) + 2,
                    blockWidth - 4, blockHeight - 4);
                e.Graphics.FillRectangle(new SolidBrush(Color.Bisque), r);
            }
        }

        private void GeniusSquareView_SizeChanged(object sender, EventArgs e)
        {
            blockWidth = (Width - (border * 2)) / (Cols + 1);
            blockHeight = (Height - (border * 2)) / (Rows + 1);
        }

        Location? selectedLocation = null;

        private void GeniusSquareView_MouseMove(object sender, MouseEventArgs e)
        {
            Location? previousLocation = selectedLocation;
            selectedLocation = LocationFromXY(e.X, e.Y);

            if(selectedLocation == null || previousLocation == null)
            {
                
            } else

            if(selectedLocation.ToString() != previousLocation.ToString() )
            {
                Invalidate();                
            }
            
        }
    }
}
