using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeniusSquare
{
    public partial class GeniusSquareView : UserControl
    {
        [Browsable(true)]
        [DefaultValue(8)]
        public int Rows
        {
            get; set;
        }

        [Browsable(true)]
        [DefaultValue(8)]
        public int Cols
        {
            get; set;
        }
        public GeniusSquareView()
        {
            InitializeComponent();
        }

        private void GeniusSquareView_Paint(object sender, PaintEventArgs e)
        {
            if (Rows < 1) Rows = 1;
            if (Cols < 1) Cols = 1;

            Pen p = new Pen(Color.Black);
            int border = 5;
            int blockWidth = (Width - (border * 2)) / (Cols + 1);
            int blockHeight = (Height - (border * 2)) / (Rows + 1);


            e.Graphics.Clear(Color.White);
            // draw vertical lines
            for (int x = 1; x <= Cols + 1; x++)
            {
                e.Graphics.DrawLine(p,
                    border + (x * blockWidth), border + blockHeight,
                    border + (x * blockWidth), border + (blockHeight * (Rows + 1)));
            }

            // draw horizontal lines
            for (int y = 1; y <= Rows + 1; y++)
            {
                e.Graphics.DrawLine(p,
                    border + blockWidth, border + (y * blockHeight),
                    border + (blockWidth * (Cols + 1)), border + (y * blockHeight));
            }


            Font font = new Font("Arial", 24);
            Brush brush = new SolidBrush(Color.Black);
            StringFormat stringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // draw column labels
            for(int x = 0; x < Cols; x++)
            {
                Rectangle r = new Rectangle(border + ((x + 1) * blockWidth), border,
                    blockWidth, blockHeight);
                e.Graphics.DrawString($"{x + 1}", font, brush, r, stringFormat);
            }

            // draw row labels
            for (int y = 0; y < Cols; y++)
            {
                char label = (char)('A' + y);
                Rectangle r = new Rectangle(border, border + ((y + 1) * blockHeight),
                    blockWidth, blockHeight);
                e.Graphics.DrawString($"{label}", font, brush, r, stringFormat);
            }
        }
    }
}
