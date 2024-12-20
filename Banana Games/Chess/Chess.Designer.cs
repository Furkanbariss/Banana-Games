namespace Banana_Games.Chess
{
    partial class Chess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chess));
            panel145 = new Panel();
            label145 = new Label();
            label146 = new Label();
            label147 = new Label();
            label148 = new Label();
            playerTurn = new Label();
            pieceselect = new Label();
            selectX = new Label();
            selectY = new Label();
            SuspendLayout();
            // 
            // panel145
            // 
            panel145.Cursor = Cursors.Hand;
            panel145.Location = new Point(200, 55);
            panel145.Name = "panel145";
            panel145.Size = new Size(565, 584);
            panel145.TabIndex = 0;
            panel145.Paint += panel1_Paint;
            panel145.MouseClick += Chess_MouseClick;
            // 
            // label145
            // 
            label145.AutoSize = true;
            label145.Font = new Font("Arial Nova", 9F, FontStyle.Italic);
            label145.Location = new Point(12, 66);
            label145.Name = "label145";
            label145.Size = new Size(85, 18);
            label145.TabIndex = 1;
            label145.Text = "Player Turn:";
            label145.Click += label1_Click;
            // 
            // label146
            // 
            label146.AutoSize = true;
            label146.Font = new Font("Arial Nova", 9F, FontStyle.Italic);
            label146.Location = new Point(12, 111);
            label146.Name = "label146";
            label146.Size = new Size(110, 18);
            label146.TabIndex = 2;
            label146.Text = "Piece Selected:";
            // 
            // label147
            // 
            label147.AutoSize = true;
            label147.Font = new Font("Arial Nova", 9F, FontStyle.Italic);
            label147.Location = new Point(792, 66);
            label147.Name = "label147";
            label147.Size = new Size(26, 18);
            label147.TabIndex = 3;
            label147.Text = "X :";
            label147.Click += label1_Click_1;
            // 
            // label148
            // 
            label148.AutoSize = true;
            label148.Font = new Font("Arial Nova", 9F, FontStyle.Italic);
            label148.Location = new Point(792, 111);
            label148.Name = "label148";
            label148.Size = new Size(26, 18);
            label148.TabIndex = 4;
            label148.Text = "Y :";
            // 
            // playerTurn
            // 
            playerTurn.AutoSize = true;
            playerTurn.Font = new Font("Arial Nova", 9F, FontStyle.Italic);
            playerTurn.Location = new Point(103, 66);
            playerTurn.Name = "playerTurn";
            playerTurn.Size = new Size(30, 18);
            playerTurn.TabIndex = 5;
            playerTurn.Text = "null";
            // 
            // pieceselect
            // 
            pieceselect.AutoSize = true;
            pieceselect.Font = new Font("Arial Nova", 9F, FontStyle.Italic);
            pieceselect.Location = new Point(126, 111);
            pieceselect.Name = "pieceselect";
            pieceselect.Size = new Size(30, 18);
            pieceselect.TabIndex = 6;
            pieceselect.Text = "null";
            // 
            // selectX
            // 
            selectX.AutoSize = true;
            selectX.Font = new Font("Arial Nova", 9F, FontStyle.Italic);
            selectX.Location = new Point(832, 66);
            selectX.Name = "selectX";
            selectX.Size = new Size(30, 18);
            selectX.TabIndex = 7;
            selectX.Text = "null";
            // 
            // selectY
            // 
            selectY.AutoSize = true;
            selectY.Font = new Font("Arial Nova", 9F, FontStyle.Italic);
            selectY.Location = new Point(832, 111);
            selectY.Name = "selectY";
            selectY.Size = new Size(30, 18);
            selectY.TabIndex = 8;
            selectY.Text = "null";
            // 
            // Chess
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 699);
            Controls.Add(selectY);
            Controls.Add(selectX);
            Controls.Add(pieceselect);
            Controls.Add(playerTurn);
            Controls.Add(label148);
            Controls.Add(label147);
            Controls.Add(label146);
            Controls.Add(label145);
            Controls.Add(panel145);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Chess";
            Text = "Chess";
            Load += Chess_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel145;
        private Label label145;
        private Label label146;
        private Label label147;
        private Label label148;
        private Label playerTurn;
        private Label pieceselect;
        private Label selectX;
        private Label selectY;
    }
}