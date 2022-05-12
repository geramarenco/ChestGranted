namespace ChestGrantedView
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panLoLNotRunning = new System.Windows.Forms.Panel();
            this.lblConnecting = new System.Windows.Forms.Label();
            this.picConnecting = new System.Windows.Forms.PictureBox();
            this.panLoLIsRunning = new System.Windows.Forms.Panel();
            this.tPanSummonerInfo = new System.Windows.Forms.TableLayoutPanel();
            this.picSummonerIcon = new System.Windows.Forms.PictureBox();
            this.lblSummonerName = new System.Windows.Forms.Label();
            this.panLoLNotRunning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConnecting)).BeginInit();
            this.panLoLIsRunning.SuspendLayout();
            this.tPanSummonerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSummonerIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panLoLNotRunning
            // 
            this.panLoLNotRunning.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panLoLNotRunning.Controls.Add(this.lblConnecting);
            this.panLoLNotRunning.Controls.Add(this.picConnecting);
            this.panLoLNotRunning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panLoLNotRunning.Location = new System.Drawing.Point(0, 0);
            this.panLoLNotRunning.Name = "panLoLNotRunning";
            this.panLoLNotRunning.Size = new System.Drawing.Size(800, 450);
            this.panLoLNotRunning.TabIndex = 0;
            // 
            // lblConnecting
            // 
            this.lblConnecting.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConnecting.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConnecting.Location = new System.Drawing.Point(0, 0);
            this.lblConnecting.Name = "lblConnecting";
            this.lblConnecting.Size = new System.Drawing.Size(800, 109);
            this.lblConnecting.TabIndex = 1;
            this.lblConnecting.Text = "Connecting to League Client";
            this.lblConnecting.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // picConnecting
            // 
            this.picConnecting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picConnecting.Image = ((System.Drawing.Image)(resources.GetObject("picConnecting.Image")));
            this.picConnecting.Location = new System.Drawing.Point(0, 112);
            this.picConnecting.Name = "picConnecting";
            this.picConnecting.Size = new System.Drawing.Size(800, 338);
            this.picConnecting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picConnecting.TabIndex = 0;
            this.picConnecting.TabStop = false;
            // 
            // panLoLIsRunning
            // 
            this.panLoLIsRunning.Controls.Add(this.tPanSummonerInfo);
            this.panLoLIsRunning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panLoLIsRunning.Location = new System.Drawing.Point(0, 0);
            this.panLoLIsRunning.Name = "panLoLIsRunning";
            this.panLoLIsRunning.Size = new System.Drawing.Size(800, 450);
            this.panLoLIsRunning.TabIndex = 1;
            this.panLoLIsRunning.Visible = false;
            // 
            // tPanSummonerInfo
            // 
            this.tPanSummonerInfo.ColumnCount = 2;
            this.tPanSummonerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.5F));
            this.tPanSummonerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.5F));
            this.tPanSummonerInfo.Controls.Add(this.picSummonerIcon, 0, 0);
            this.tPanSummonerInfo.Controls.Add(this.lblSummonerName, 1, 0);
            this.tPanSummonerInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.tPanSummonerInfo.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tPanSummonerInfo.Location = new System.Drawing.Point(0, 0);
            this.tPanSummonerInfo.Name = "tPanSummonerInfo";
            this.tPanSummonerInfo.RowCount = 1;
            this.tPanSummonerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tPanSummonerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tPanSummonerInfo.Size = new System.Drawing.Size(800, 109);
            this.tPanSummonerInfo.TabIndex = 0;
            // 
            // picSummonerIcon
            // 
            this.picSummonerIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSummonerIcon.Location = new System.Drawing.Point(3, 3);
            this.picSummonerIcon.Name = "picSummonerIcon";
            this.picSummonerIcon.Size = new System.Drawing.Size(110, 103);
            this.picSummonerIcon.TabIndex = 0;
            this.picSummonerIcon.TabStop = false;
            // 
            // lblSummonerName
            // 
            this.lblSummonerName.AutoSize = true;
            this.lblSummonerName.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSummonerName.Location = new System.Drawing.Point(119, 0);
            this.lblSummonerName.Name = "lblSummonerName";
            this.lblSummonerName.Size = new System.Drawing.Size(162, 40);
            this.lblSummonerName.TabIndex = 1;
            this.lblSummonerName.Text = "Summoner:";
            this.lblSummonerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panLoLIsRunning);
            this.Controls.Add(this.panLoLNotRunning);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chest Granted";
            this.panLoLNotRunning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picConnecting)).EndInit();
            this.panLoLIsRunning.ResumeLayout(false);
            this.tPanSummonerInfo.ResumeLayout(false);
            this.tPanSummonerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSummonerIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panLoLNotRunning;
        private System.Windows.Forms.Panel panLoLIsRunning;
        private System.Windows.Forms.PictureBox picConnecting;
        private System.Windows.Forms.Label lblConnecting;
        private System.Windows.Forms.TableLayoutPanel tPanSummonerInfo;
        private System.Windows.Forms.PictureBox picSummonerIcon;
        private System.Windows.Forms.Label lblSummonerName;
    }
}