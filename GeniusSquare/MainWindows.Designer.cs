namespace GeniusSquare
{
    partial class MainWindows
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            viewer = new GeniusSquareView();
            lstLog = new ListBox();
            btnRoll = new Button();
            SuspendLayout();
            // 
            // viewer
            // 
            viewer.Cols = 8;
            viewer.Location = new Point(12, 21);
            viewer.Name = "viewer";
            viewer.Rows = 8;
            viewer.Size = new Size(338, 376);
            viewer.TabIndex = 0;
            // 
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 15;
            lstLog.Location = new Point(419, 45);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(369, 304);
            lstLog.TabIndex = 1;
            // 
            // btnRoll
            // 
            btnRoll.Location = new Point(419, 374);
            btnRoll.Name = "btnRoll";
            btnRoll.Size = new Size(75, 23);
            btnRoll.TabIndex = 2;
            btnRoll.Text = "Roll";
            btnRoll.UseVisualStyleBackColor = true;
            btnRoll.Click += btnRoll_Click;
            // 
            // MainWindows
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRoll);
            Controls.Add(lstLog);
            Controls.Add(viewer);
            KeyPreview = true;
            Name = "MainWindows";
            Text = "GeniusSquare";
            Load += MainWindows_Load;
            KeyDown += MainWindows_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private GeniusSquareView viewer;
        private ListBox lstLog;
        private Button btnRoll;
    }
}
