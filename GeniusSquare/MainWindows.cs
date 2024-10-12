namespace GeniusSquare
{
    public partial class MainWindows : Form
    {
        public MainWindows()
        {
            InitializeComponent();
        }

        Game gs = new Game();
        int index = 0;

        private void MainWindows_Load(object sender, EventArgs e)
        {
            viewer.CurrentPiece = gs.compoundPieces[index];
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
            viewer.Pieces.Clear();
            foreach (Dice d in gs.dice)
            {
                Location l = d.Roll();
                lstLog.Items.Add(l);

                viewer.Pieces.Add(new Piece()
                {
                    Color = Color.Beige,
                    Location = l
                });
                viewer.Invalidate();
            }
        }

        private void MainWindows_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.S)
            {
                if(viewer.CurrentPiece != null)
                {
                    List<string> combinations = viewer.CurrentPiece.GetAllCombinations();
                    lstLog.Items.Add($"{combinations.Count} unique positions:");
                    foreach (string combination in combinations)
                    {
                        lstLog.Items.Add($" '{combination}'");
                    }   
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                index--;
                if (index < 0) index = gs.compoundPieces.Count - 1;
            }
            if (e.KeyCode == Keys.Right)
            {
                index++;
                if (index > gs.compoundPieces.Count - 1) index = 0;
            }
            if (viewer.CurrentPiece != null)
            {
                if (e.KeyCode == Keys.Up)
                {
                    viewer.CurrentPiece.Direction = Direction.FaceUp;
                }
                if (e.KeyCode == Keys.Down)
                {
                    viewer.CurrentPiece.Direction = Direction.FaceDown;
                }
            }
            viewer.CurrentPiece = gs.compoundPieces[index];
            viewer.Invalidate();
        }
    }
}
