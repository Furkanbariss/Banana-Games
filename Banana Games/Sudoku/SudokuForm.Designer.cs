﻿
namespace Banana_Games.Sudoku
{
    partial class SudokuForm
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
            btnGenerate = new Button();
            btnSolve = new Button();
            btnReset = new Button();
            lblTimer = new Label();
            timer = new System.Windows.Forms.Timer(components);
            cmbBoxMode = new ComboBox();
            cmbBoxGrid = new ComboBox();
            lblMode = new Label();
            lblGrid = new Label();
            lblStatus = new Label();
            gridView = new DataGridView();
            btnValidate = new Button();
            messageTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            SuspendLayout();
            // 
            // btnGenerate
            // 
            btnGenerate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnGenerate.BackColor = Color.DarkSlateBlue;
            btnGenerate.Cursor = Cursors.Hand;
            btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnGenerate.ForeColor = Color.White;
            btnGenerate.Location = new Point(886, 318);
            btnGenerate.Margin = new Padding(4, 5, 4, 5);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(107, 38);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += BtnGenerate_Click;
            // 
            // btnSolve
            // 
            btnSolve.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSolve.BackColor = Color.Green;
            btnSolve.Cursor = Cursors.Hand;
            btnSolve.FlatAppearance.BorderSize = 0;
            btnSolve.FlatStyle = FlatStyle.Flat;
            btnSolve.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnSolve.ForeColor = Color.White;
            btnSolve.Location = new Point(886, 462);
            btnSolve.Margin = new Padding(4, 5, 4, 5);
            btnSolve.Name = "btnSolve";
            btnSolve.Size = new Size(107, 38);
            btnSolve.TabIndex = 2;
            btnSolve.Text = "Solve";
            btnSolve.UseVisualStyleBackColor = false;
            btnSolve.Click += BtnSolve_Click;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnReset.BackColor = Color.Silver;
            btnReset.Cursor = Cursors.Hand;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnReset.ForeColor = Color.Black;
            btnReset.Location = new Point(886, 535);
            btnReset.Margin = new Padding(4, 5, 4, 5);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(107, 38);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += BtnReset_Click;
            // 
            // lblTimer
            // 
            lblTimer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTimer.AutoSize = true;
            lblTimer.FlatStyle = FlatStyle.Flat;
            lblTimer.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
            lblTimer.ForeColor = Color.White;
            lblTimer.Location = new Point(411, 10);
            lblTimer.Margin = new Padding(4, 0, 4, 0);
            lblTimer.Name = "lblTimer";
            lblTimer.Padding = new Padding(29, 25, 29, 25);
            lblTimer.Size = new Size(246, 97);
            lblTimer.TabIndex = 7;
            lblTimer.Text = "00:00:00";
            lblTimer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            // 
            // cmbBoxMode
            // 
            cmbBoxMode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbBoxMode.Cursor = Cursors.Hand;
            cmbBoxMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxMode.FlatStyle = FlatStyle.Flat;
            cmbBoxMode.Font = new Font("Microsoft Sans Serif", 9.75F);
            cmbBoxMode.FormattingEnabled = true;
            cmbBoxMode.Items.AddRange(new object[] { "Easy", "Medium", "Hard" });
            cmbBoxMode.Location = new Point(41, 80);
            cmbBoxMode.Margin = new Padding(4, 5, 4, 5);
            cmbBoxMode.Name = "cmbBoxMode";
            cmbBoxMode.Size = new Size(171, 33);
            cmbBoxMode.TabIndex = 4;
            cmbBoxMode.SelectedIndexChanged += CmbBoxMode_SelectedIndexChanged;
            // 
            // cmbBoxGrid
            // 
            cmbBoxGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbBoxGrid.Cursor = Cursors.Hand;
            cmbBoxGrid.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxGrid.FlatStyle = FlatStyle.Flat;
            cmbBoxGrid.Font = new Font("Microsoft Sans Serif", 9.75F);
            cmbBoxGrid.FormattingEnabled = true;
            cmbBoxGrid.Items.AddRange(new object[] { "4 X 4", "9 X 9" });
            cmbBoxGrid.Location = new Point(41, 162);
            cmbBoxGrid.Margin = new Padding(4, 5, 4, 5);
            cmbBoxGrid.Name = "cmbBoxGrid";
            cmbBoxGrid.Size = new Size(171, 33);
            cmbBoxGrid.TabIndex = 5;
            cmbBoxGrid.SelectedIndexChanged += CmbBoxGrid_SelectedIndexChanged;
            // 
            // lblMode
            // 
            lblMode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblMode.AutoSize = true;
            lblMode.FlatStyle = FlatStyle.Flat;
            lblMode.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblMode.ForeColor = Color.White;
            lblMode.Location = new Point(41, 48);
            lblMode.Margin = new Padding(4, 0, 4, 0);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(62, 25);
            lblMode.TabIndex = 6;
            lblMode.Text = "Mode";
            // 
            // lblGrid
            // 
            lblGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblGrid.AutoSize = true;
            lblGrid.FlatStyle = FlatStyle.Flat;
            lblGrid.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblGrid.ForeColor = Color.White;
            lblGrid.Location = new Point(41, 130);
            lblGrid.Margin = new Padding(4, 0, 4, 0);
            lblGrid.Name = "lblGrid";
            lblGrid.Size = new Size(48, 25);
            lblGrid.TabIndex = 7;
            lblGrid.Text = "Grid";
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.AutoSize = true;
            lblStatus.FlatStyle = FlatStyle.Flat;
            lblStatus.Font = new Font("Microsoft Sans Serif", 11.25F);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(239, 118);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.MinimumSize = new Size(616, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(616, 29);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Start Solving Sudoku";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gridView
            // 
            gridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gridView.BackgroundColor = Color.Gray;
            gridView.BorderStyle = BorderStyle.None;
            gridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.GridColor = Color.White;
            gridView.Location = new Point(266, 165);
            gridView.Margin = new Padding(4, 5, 4, 5);
            gridView.Name = "gridView";
            gridView.RowHeadersWidth = 62;
            gridView.RowTemplate.Height = 25;
            gridView.ScrollBars = ScrollBars.None;
            gridView.Size = new Size(554, 647);
            gridView.TabIndex = 6;
            // 
            // btnValidate
            // 
            btnValidate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnValidate.BackColor = Color.SteelBlue;
            btnValidate.Cursor = Cursors.Hand;
            btnValidate.FlatAppearance.BorderSize = 0;
            btnValidate.FlatStyle = FlatStyle.Flat;
            btnValidate.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnValidate.ForeColor = Color.White;
            btnValidate.Location = new Point(886, 390);
            btnValidate.Margin = new Padding(4, 5, 4, 5);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(107, 38);
            btnValidate.TabIndex = 1;
            btnValidate.Text = "Validate";
            btnValidate.UseVisualStyleBackColor = false;
            btnValidate.Click += BtnValidate_Click;
            // 
            // messageTimer
            // 
            messageTimer.Enabled = true;
            messageTimer.Interval = 5000;
            messageTimer.Tick += MessageTimer_Tick;
            // 
            // SudokuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 47, 47);
            ClientSize = new Size(1143, 750);
            Controls.Add(btnValidate);
            Controls.Add(gridView);
            Controls.Add(lblStatus);
            Controls.Add(lblGrid);
            Controls.Add(lblMode);
            Controls.Add(cmbBoxGrid);
            Controls.Add(cmbBoxMode);
            Controls.Add(lblTimer);
            Controls.Add(btnReset);
            Controls.Add(btnSolve);
            Controls.Add(btnGenerate);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "SudokuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sudoku";
            Load += SudokuForm_Load;
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnSolve_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CmbBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CmbBoxGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnValidate_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        //degisecek 17.35
        private void SudokuForm_Load(object sender, EventArgs e) => throw new NotImplementedException();

        //private void SudokuForm_Load(object sender, EventArgs e)
        //{ }
        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ComboBox cmbBoxMode;
        private System.Windows.Forms.ComboBox cmbBoxGrid;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblGrid;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Timer messageTimer;
    }
}