namespace Cards
{
    partial class Form1
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
            this.Player2 = new System.Windows.Forms.Panel();
            this.Player1 = new System.Windows.Forms.Panel();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.Player3 = new System.Windows.Forms.Panel();
            this.DrawPlatform = new System.Windows.Forms.Panel();
            this.PreviousDraw = new System.Windows.Forms.Panel();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.Player4 = new System.Windows.Forms.Panel();
            this.lblDraw = new System.Windows.Forms.Label();
            this.lblPrevious = new System.Windows.Forms.Label();
            this.lblInstruct = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.lblPlayer3 = new System.Windows.Forms.Label();
            this.lblPlayer4 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Player2
            // 
            this.Player2.BackColor = System.Drawing.SystemColors.Desktop;
            this.Player2.Location = new System.Drawing.Point(23, 164);
            this.Player2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(1339, 138);
            this.Player2.TabIndex = 10;
            // 
            // Player1
            // 
            this.Player1.BackColor = System.Drawing.SystemColors.Desktop;
            this.Player1.Location = new System.Drawing.Point(23, 16);
            this.Player1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(1339, 126);
            this.Player1.TabIndex = 8;
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnNewGame.BackgroundImage = global::Cards.Properties.Resources.q02th1;
            this.btnNewGame.Font = new System.Drawing.Font("Stencil", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNewGame.Location = new System.Drawing.Point(1626, 16);
            this.btnNewGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(108, 62);
            this.btnNewGame.TabIndex = 9;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // Player3
            // 
            this.Player3.BackColor = System.Drawing.SystemColors.Desktop;
            this.Player3.Location = new System.Drawing.Point(20, 689);
            this.Player3.Name = "Player3";
            this.Player3.Size = new System.Drawing.Size(1342, 133);
            this.Player3.TabIndex = 0;
            // 
            // DrawPlatform
            // 
            this.DrawPlatform.BackColor = System.Drawing.Color.Brown;
            this.DrawPlatform.Location = new System.Drawing.Point(23, 321);
            this.DrawPlatform.Name = "DrawPlatform";
            this.DrawPlatform.Size = new System.Drawing.Size(1339, 154);
            this.DrawPlatform.TabIndex = 14;
            // 
            // PreviousDraw
            // 
            this.PreviousDraw.BackColor = System.Drawing.Color.IndianRed;
            this.PreviousDraw.Location = new System.Drawing.Point(20, 493);
            this.PreviousDraw.Name = "PreviousDraw";
            this.PreviousDraw.Size = new System.Drawing.Size(1342, 168);
            this.PreviousDraw.TabIndex = 15;
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.BackColor = System.Drawing.Color.OliveDrab;
            this.lblPlayer1.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1.ForeColor = System.Drawing.Color.Coral;
            this.lblPlayer1.Location = new System.Drawing.Point(1416, 56);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(133, 22);
            this.lblPlayer1.TabIndex = 17;
            this.lblPlayer1.Text = "Player 1";
            // 
            // Player4
            // 
            this.Player4.BackColor = System.Drawing.SystemColors.Desktop;
            this.Player4.Location = new System.Drawing.Point(12, 847);
            this.Player4.Name = "Player4";
            this.Player4.Size = new System.Drawing.Size(1350, 141);
            this.Player4.TabIndex = 1;
            // 
            // lblDraw
            // 
            this.lblDraw.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.lblDraw.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDraw.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblDraw.Location = new System.Drawing.Point(1413, 368);
            this.lblDraw.Name = "lblDraw";
            this.lblDraw.Size = new System.Drawing.Size(136, 22);
            this.lblDraw.TabIndex = 21;
            this.lblDraw.Text = "The Draw Card(s)";
            // 
            // lblPrevious
            // 
            this.lblPrevious.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.lblPrevious.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrevious.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblPrevious.Location = new System.Drawing.Point(1413, 550);
            this.lblPrevious.Name = "lblPrevious";
            this.lblPrevious.Size = new System.Drawing.Size(160, 24);
            this.lblPrevious.TabIndex = 22;
            this.lblPrevious.Text = "The Previous Card(s)";
            // 
            // lblInstruct
            // 
            this.lblInstruct.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruct.Location = new System.Drawing.Point(1623, 263);
            this.lblInstruct.Name = "lblInstruct";
            this.lblInstruct.Size = new System.Drawing.Size(270, 666);
            this.lblInstruct.TabIndex = 24;
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.BackColor = System.Drawing.Color.OliveDrab;
            this.lblPlayer2.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2.ForeColor = System.Drawing.Color.Coral;
            this.lblPlayer2.Location = new System.Drawing.Point(1413, 181);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(136, 22);
            this.lblPlayer2.TabIndex = 25;
            this.lblPlayer2.Text = "Player 2";
            // 
            // lblPlayer3
            // 
            this.lblPlayer3.BackColor = System.Drawing.Color.OliveDrab;
            this.lblPlayer3.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer3.ForeColor = System.Drawing.Color.Coral;
            this.lblPlayer3.Location = new System.Drawing.Point(1413, 752);
            this.lblPlayer3.Name = "lblPlayer3";
            this.lblPlayer3.Size = new System.Drawing.Size(147, 22);
            this.lblPlayer3.TabIndex = 26;
            this.lblPlayer3.Text = "Player 3";
            // 
            // lblPlayer4
            // 
            this.lblPlayer4.BackColor = System.Drawing.Color.OliveDrab;
            this.lblPlayer4.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer4.ForeColor = System.Drawing.Color.Coral;
            this.lblPlayer4.Location = new System.Drawing.Point(1413, 892);
            this.lblPlayer4.Name = "lblPlayer4";
            this.lblPlayer4.Size = new System.Drawing.Size(147, 22);
            this.lblPlayer4.TabIndex = 27;
            this.lblPlayer4.Text = "Player 4";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnStart.BackgroundImage = global::Cards.Properties.Resources.q02th1;
            this.btnStart.Font = new System.Drawing.Font("Stencil", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStart.Location = new System.Drawing.Point(1754, 16);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(106, 62);
            this.btnStart.TabIndex = 28;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnContinue.BackgroundImage = global::Cards.Properties.Resources.q02th1;
            this.btnContinue.Font = new System.Drawing.Font("Stencil", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnContinue.Location = new System.Drawing.Point(1626, 101);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(108, 59);
            this.btnContinue.TabIndex = 29;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.BtnContinue_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnReset.BackgroundImage = global::Cards.Properties.Resources.q02th1;
            this.btnReset.Font = new System.Drawing.Font("Stencil", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReset.Location = new System.Drawing.Point(1754, 101);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(106, 59);
            this.btnReset.TabIndex = 30;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnEnd.BackgroundImage = global::Cards.Properties.Resources.q02th1;
            this.btnEnd.Font = new System.Drawing.Font("Stencil", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEnd.Location = new System.Drawing.Point(1626, 181);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(108, 59);
            this.btnEnd.TabIndex = 31;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.BtnEnd_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnExit.BackgroundImage = global::Cards.Properties.Resources.q02th1;
            this.btnExit.Font = new System.Drawing.Font("Stencil", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExit.Location = new System.Drawing.Point(1754, 181);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(108, 59);
            this.btnExit.TabIndex = 32;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cards.Properties.Resources.q02th;
            this.ClientSize = new System.Drawing.Size(1920, 1055);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblPlayer4);
            this.Controls.Add(this.lblPlayer3);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblInstruct);
            this.Controls.Add(this.lblPrevious);
            this.Controls.Add(this.lblDraw);
            this.Controls.Add(this.Player4);
            this.Controls.Add(this.lblPlayer1);
            this.Controls.Add(this.PreviousDraw);
            this.Controls.Add(this.DrawPlatform);
            this.Controls.Add(this.Player3);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.btnNewGame);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "KILLER 13";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Panel Player2;
        internal System.Windows.Forms.Panel Player1;
        internal System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Panel Player3;
        private System.Windows.Forms.Panel DrawPlatform;
        private System.Windows.Forms.Panel PreviousDraw;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Panel Player4;
        private System.Windows.Forms.Label lblDraw;
        private System.Windows.Forms.Label lblPrevious;
        private System.Windows.Forms.Label lblInstruct;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label lblPlayer3;
        private System.Windows.Forms.Label lblPlayer4;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Button btnContinue;
        internal System.Windows.Forms.Button btnReset;
        internal System.Windows.Forms.Button btnEnd;
        internal System.Windows.Forms.Button btnExit;
    }
}