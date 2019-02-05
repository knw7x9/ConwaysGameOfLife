namespace ConwaysGameOfLife {
    partial class frmConwaysGameOfLife {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.msOptions = new System.Windows.Forms.MenuStrip();
            this.tsStartingShapes = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbStartingShapes = new System.Windows.Forms.ToolStripComboBox();
            this.gameControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miStartGame = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSize = new System.Windows.Forms.ToolStripTextBox();
            this.txtSizeInput = new System.Windows.Forms.ToolStripTextBox();
            this.txtTurnsToPlay = new System.Windows.Forms.ToolStripTextBox();
            this.txtTurnsToPlayInput = new System.Windows.Forms.ToolStripTextBox();
            this.miClear = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTurns = new System.Windows.Forms.Label();
            this.lblTurnsOutput = new System.Windows.Forms.Label();
            this.lblGameBoard = new System.Windows.Forms.Label();
            this.msOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // msOptions
            // 
            this.msOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStartingShapes,
            this.gameControlsToolStripMenuItem});
            this.msOptions.Location = new System.Drawing.Point(0, 0);
            this.msOptions.Name = "msOptions";
            this.msOptions.Size = new System.Drawing.Size(516, 24);
            this.msOptions.TabIndex = 1;
            this.msOptions.Text = "menuStrip1";
            // 
            // tsStartingShapes
            // 
            this.tsStartingShapes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbStartingShapes});
            this.tsStartingShapes.Name = "tsStartingShapes";
            this.tsStartingShapes.Size = new System.Drawing.Size(100, 20);
            this.tsStartingShapes.Text = "Starting Shapes";
            // 
            // cmbStartingShapes
            // 
            this.cmbStartingShapes.Items.AddRange(new object[] {
            "Random",
            "Horizonal Lines",
            "Vertical Lines",
            "Diamond",
            "Square"});
            this.cmbStartingShapes.Name = "cmbStartingShapes";
            this.cmbStartingShapes.Size = new System.Drawing.Size(121, 23);
            // 
            // gameControlsToolStripMenuItem
            // 
            this.gameControlsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miStartGame,
            this.txtSize,
            this.txtSizeInput,
            this.txtTurnsToPlay,
            this.txtTurnsToPlayInput,
            this.miClear,
            this.miExit});
            this.gameControlsToolStripMenuItem.Name = "gameControlsToolStripMenuItem";
            this.gameControlsToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.gameControlsToolStripMenuItem.Text = "Game Controls";
            // 
            // miStartGame
            // 
            this.miStartGame.Name = "miStartGame";
            this.miStartGame.Size = new System.Drawing.Size(160, 22);
            this.miStartGame.Text = "Start Game";
            this.miStartGame.Click += new System.EventHandler(this.miStartGame_Click);
            // 
            // txtSize
            // 
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            this.txtSize.Size = new System.Drawing.Size(100, 23);
            this.txtSize.Text = "Size";
            // 
            // txtSizeInput
            // 
            this.txtSizeInput.Name = "txtSizeInput";
            this.txtSizeInput.Size = new System.Drawing.Size(100, 23);
            this.txtSizeInput.Text = "50";
            // 
            // txtTurnsToPlay
            // 
            this.txtTurnsToPlay.Name = "txtTurnsToPlay";
            this.txtTurnsToPlay.ReadOnly = true;
            this.txtTurnsToPlay.Size = new System.Drawing.Size(100, 23);
            this.txtTurnsToPlay.Text = "Turns to play";
            // 
            // txtTurnsToPlayInput
            // 
            this.txtTurnsToPlayInput.Name = "txtTurnsToPlayInput";
            this.txtTurnsToPlayInput.Size = new System.Drawing.Size(100, 23);
            this.txtTurnsToPlayInput.Text = "100";
            // 
            // miClear
            // 
            this.miClear.Name = "miClear";
            this.miClear.Size = new System.Drawing.Size(160, 22);
            this.miClear.Text = "Clear";
            this.miClear.Click += new System.EventHandler(this.miClear_Click);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(160, 22);
            this.miExit.Text = "Exit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // lblTurns
            // 
            this.lblTurns.AutoSize = true;
            this.lblTurns.Location = new System.Drawing.Point(417, 9);
            this.lblTurns.Name = "lblTurns";
            this.lblTurns.Size = new System.Drawing.Size(39, 13);
            this.lblTurns.TabIndex = 3;
            this.lblTurns.Text = "Turn #";
            // 
            // lblTurnsOutput
            // 
            this.lblTurnsOutput.AutoSize = true;
            this.lblTurnsOutput.Location = new System.Drawing.Point(462, 9);
            this.lblTurnsOutput.Name = "lblTurnsOutput";
            this.lblTurnsOutput.Size = new System.Drawing.Size(0, 13);
            this.lblTurnsOutput.TabIndex = 4;
            // 
            // lblGameBoard
            // 
            this.lblGameBoard.AutoSize = true;
            this.lblGameBoard.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameBoard.Location = new System.Drawing.Point(13, 28);
            this.lblGameBoard.Name = "lblGameBoard";
            this.lblGameBoard.Size = new System.Drawing.Size(0, 13);
            this.lblGameBoard.TabIndex = 5;
            // 
            // frmConwaysGameOfLife
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(516, 556);
            this.Controls.Add(this.lblGameBoard);
            this.Controls.Add(this.lblTurnsOutput);
            this.Controls.Add(this.lblTurns);
            this.Controls.Add(this.msOptions);
            this.MainMenuStrip = this.msOptions;
            this.Name = "frmConwaysGameOfLife";
            this.Text = "Petri Dish";
            this.msOptions.ResumeLayout(false);
            this.msOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msOptions;
        private System.Windows.Forms.ToolStripMenuItem tsStartingShapes;
        private System.Windows.Forms.ToolStripComboBox cmbStartingShapes;
        private System.Windows.Forms.ToolStripMenuItem gameControlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miStartGame;
        private System.Windows.Forms.ToolStripTextBox txtSize;
        private System.Windows.Forms.ToolStripTextBox txtSizeInput;
        private System.Windows.Forms.ToolStripTextBox txtTurnsToPlay;
        private System.Windows.Forms.ToolStripTextBox txtTurnsToPlayInput;
        private System.Windows.Forms.ToolStripMenuItem miClear;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.Label lblTurns;
        private System.Windows.Forms.Label lblTurnsOutput;
        private System.Windows.Forms.Label lblGameBoard;
    }
}

