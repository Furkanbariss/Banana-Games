namespace Banana_Games
{
    partial class Login
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
            button1 = new Button();
            contactButton = new Button();
            exitButton = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            button7 = new Button();
            chessButton = new Button();
            button5 = new Button();
            xoxButton = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 0;
            button1.Text = "PLAY";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // contactButton
            // 
            contactButton.Location = new Point(3, 46);
            contactButton.Margin = new Padding(3, 2, 3, 2);
            contactButton.Name = "contactButton";
            contactButton.Size = new Size(82, 22);
            contactButton.TabIndex = 1;
            contactButton.Text = "CONTACT";
            contactButton.UseVisualStyleBackColor = true;
            contactButton.Click += contactButton_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(3, 91);
            exitButton.Margin = new Padding(3, 2, 3, 2);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(82, 22);
            exitButton.TabIndex = 2;
            exitButton.Text = "EXİT";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(contactButton);
            panel1.Controls.Add(exitButton);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(268, 143);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(88, 117);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(button7);
            panel2.Controls.Add(chessButton);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(xoxButton);
            panel2.Location = new Point(134, 38);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(425, 249);
            panel2.TabIndex = 4;
            // 
            // button7
            // 
            button7.Location = new Point(228, 136);
            button7.Margin = new Padding(3, 2, 3, 2);
            button7.Name = "button7";
            button7.Size = new Size(161, 56);
            button7.TabIndex = 3;
            button7.Text = "Sudoku";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // chessButton
            // 
            chessButton.Location = new Point(45, 136);
            chessButton.Margin = new Padding(3, 2, 3, 2);
            chessButton.Name = "chessButton";
            chessButton.Size = new Size(155, 56);
            chessButton.TabIndex = 2;
            chessButton.Text = "Chess";
            chessButton.UseVisualStyleBackColor = true;
            chessButton.Click += chessButton_Click;
            // 
            // button5
            // 
            button5.Location = new Point(228, 46);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(161, 60);
            button5.TabIndex = 1;
            button5.Text = "ROCK-PAPER-SCISSORS";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // xoxButton
            // 
            xoxButton.Location = new Point(45, 46);
            xoxButton.Margin = new Padding(3, 2, 3, 2);
            xoxButton.Name = "xoxButton";
            xoxButton.Size = new Size(155, 60);
            xoxButton.TabIndex = 0;
            xoxButton.Text = "X-O-X";
            xoxButton.UseVisualStyleBackColor = true;
            xoxButton.Click += button4_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Login";
            Text = "Banana Games";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button contactButton;
        private Button exitButton;
        private Panel panel1;
        private Panel panel2;
        private Button button7;
        private Button chessButton;
        private Button button5;
        private Button xoxButton;
    }
}
