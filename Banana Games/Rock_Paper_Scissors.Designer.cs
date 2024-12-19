using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Banana_Games
{
    partial class Rock_Paper_Scissors
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rock_Paper_Scissors));
            btnRock = new Button();
            ımageList1 = new ImageList(components);
            btnPaper = new Button();
            btnScissors = new Button();
            btnRules = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            scoreCom = new Label();
            scorePlayer = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelResults = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnRock
            // 
            btnRock.FlatAppearance.BorderSize = 0;
            btnRock.FlatStyle = FlatStyle.Flat;
            btnRock.ImageIndex = 1;
            btnRock.ImageList = ımageList1;
            btnRock.Location = new Point(203, 170);
            btnRock.Name = "btnRock";
            btnRock.Size = new Size(150, 95);
            btnRock.TabIndex = 0;
            btnRock.UseVisualStyleBackColor = true;
            btnRock.Click += btnRock_Click;
            // 
            // ımageList1
            // 
            ımageList1.ColorDepth = ColorDepth.Depth32Bit;
            ımageList1.ImageStream = (ImageListStreamer)resources.GetObject("ımageList1.ImageStream");
            ımageList1.TransparentColor = Color.Transparent;
            ımageList1.Images.SetKeyName(0, "paper.png");
            ımageList1.Images.SetKeyName(1, "rock.png");
            ımageList1.Images.SetKeyName(2, "scissors.png");
            ımageList1.Images.SetKeyName(3, "scissors_541957.png");
            ımageList1.Images.SetKeyName(4, "paper-plane_258977.png");
            ımageList1.Images.SetKeyName(5, "paper-plane_467568.png");
            ımageList1.Images.SetKeyName(6, "Rules.png");
            // 
            // btnPaper
            // 
            btnPaper.FlatAppearance.BorderSize = 0;
            btnPaper.FlatStyle = FlatStyle.Flat;
            btnPaper.ImageIndex = 4;
            btnPaper.ImageList = ımageList1;
            btnPaper.Location = new Point(474, 175);
            btnPaper.Name = "btnPaper";
            btnPaper.Size = new Size(145, 90);
            btnPaper.TabIndex = 1;
            btnPaper.UseVisualStyleBackColor = true;
            btnPaper.Click += btnPaper_Click;
            // 
            // btnScissors
            // 
            btnScissors.FlatAppearance.BorderSize = 0;
            btnScissors.FlatStyle = FlatStyle.Flat;
            btnScissors.ImageIndex = 3;
            btnScissors.ImageList = ımageList1;
            btnScissors.Location = new Point(341, 286);
            btnScissors.Name = "btnScissors";
            btnScissors.Size = new Size(135, 92);
            btnScissors.TabIndex = 2;
            btnScissors.UseVisualStyleBackColor = true;
            btnScissors.Click += btnScissors_Click;
            // 
            // btnRules
            // 
            btnRules.Font = new System.Drawing.Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnRules.Location = new Point(725, 413);
            btnRules.Name = "btnRules";
            btnRules.Size = new Size(118, 54);
            btnRules.TabIndex = 3;
            btnRules.Text = "RULES";
            btnRules.UseVisualStyleBackColor = true;
            btnRules.Click += btnRules_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(98, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(650, 108);
            panel1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(scoreCom);
            panel2.Controls.Add(scorePlayer);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(272, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(335, 108);
            panel2.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlDarkDark;
            panel4.Location = new Point(1, 30);
            panel4.Name = "panel4";
            panel4.Size = new Size(333, 10);
            panel4.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDarkDark;
            panel3.Location = new Point(149, 35);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 73);
            panel3.TabIndex = 5;
            // 
            // scoreCom
            // 
            scoreCom.AutoSize = true;
            scoreCom.Font = new System.Drawing.Font("Segoe Print", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            scoreCom.Location = new Point(219, 72);
            scoreCom.Name = "scoreCom";
            scoreCom.Size = new Size(29, 33);
            scoreCom.TabIndex = 4;
            scoreCom.Text = "0";
            // 
            // scorePlayer
            // 
            scorePlayer.AutoSize = true;
            scorePlayer.Font = new System.Drawing.Font("Segoe Print", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            scorePlayer.Location = new Point(65, 72);
            scorePlayer.Name = "scorePlayer";
            scorePlayer.Size = new Size(29, 33);
            scorePlayer.TabIndex = 3;
            scorePlayer.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe Print", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(183, 39);
            label4.Name = "label4";
            label4.Size = new Size(129, 33);
            label4.TabIndex = 2;
            label4.Text = "COMPUTER";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe Print", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(30, 39);
            label3.Name = "label3";
            label3.Size = new Size(95, 33);
            label3.TabIndex = 1;
            label3.Text = "PLAYER";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(94, 5);
            label2.Name = "label2";
            label2.Size = new Size(120, 22);
            label2.TabIndex = 0;
            label2.Text = "Scoreboard";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(55, 14);
            label1.Name = "label1";
            label1.Size = new Size(92, 72);
            label1.TabIndex = 0;
            label1.Text = "Rock\r\nPaper\r\nScissors";
            // 
            // panelResults
            // 
            panelResults.Location = new Point(203, 175);
            panelResults.Name = "panelResults";
            panelResults.Size = new Size(463, 192);
            panelResults.TabIndex = 5;
            // 
            // Rock_Paper_Scissors
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(885, 540);
            Controls.Add(panelResults);
            Controls.Add(panel1);
            Controls.Add(btnRules);
            Controls.Add(btnScissors);
            Controls.Add(btnPaper);
            Controls.Add(btnRock);
            Name = "Rock_Paper_Scissors";
            Text = "Rock_Paper_Scissors";
            Load += Rock_Paper_Scissors_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnRock;
        private Button btnPaper;
        private Button btnScissors;
        private ImageList ımageList1;
        private Button btnRules;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Label scoreCom;
        private Label scorePlayer;
        private Label label4;
        private Label label3;
        private Panel panel3;
        private Panel panel4;
        private Panel panelResults;
    }
}