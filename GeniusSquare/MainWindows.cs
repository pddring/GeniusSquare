namespace GeniusSquare
{
    public partial class MainWindows : Form
    {
        public MainWindows()
        {
            InitializeComponent();
        }

        Game gs = new Game();

        private void MainWindows_Load(object sender, EventArgs e)
        {
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

    }
}
