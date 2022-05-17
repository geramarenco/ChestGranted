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
            this.panChampSelect = new System.Windows.Forms.Panel();
            this.lblTitleSelectedChamp = new System.Windows.Forms.Label();
            this.lblTitleMap = new System.Windows.Forms.Label();
            this.tPanSummonerInfo = new System.Windows.Forms.TableLayoutPanel();
            this.picSummonerIcon = new System.Windows.Forms.PictureBox();
            this.panSummonerInfo = new System.Windows.Forms.Panel();
            this.lblEarnableChest = new System.Windows.Forms.Label();
            this.lblSummonerName = new System.Windows.Forms.Label();
            this.lblTitleChests = new System.Windows.Forms.Label();
            this.panNoChampSalect = new System.Windows.Forms.Panel();
            this.lblTitleWaiting = new System.Windows.Forms.Label();
            this.panLoLNotRunning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConnecting)).BeginInit();
            this.panLoLIsRunning.SuspendLayout();
            this.panChampSelect.SuspendLayout();
            this.tPanSummonerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSummonerIcon)).BeginInit();
            this.panSummonerInfo.SuspendLayout();
            this.panNoChampSalect.SuspendLayout();
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
            this.panLoLIsRunning.Controls.Add(this.panChampSelect);
            this.panLoLIsRunning.Controls.Add(this.tPanSummonerInfo);
            this.panLoLIsRunning.Controls.Add(this.panNoChampSalect);
            this.panLoLIsRunning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panLoLIsRunning.Location = new System.Drawing.Point(0, 0);
            this.panLoLIsRunning.Name = "panLoLIsRunning";
            this.panLoLIsRunning.Size = new System.Drawing.Size(800, 450);
            this.panLoLIsRunning.TabIndex = 1;
            this.panLoLIsRunning.Visible = false;
            // 
            // panChampSelect
            // 
            this.panChampSelect.Controls.Add(this.lblTitleSelectedChamp);
            this.panChampSelect.Controls.Add(this.lblTitleMap);
            this.panChampSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panChampSelect.Location = new System.Drawing.Point(0, 109);
            this.panChampSelect.Name = "panChampSelect";
            this.panChampSelect.Size = new System.Drawing.Size(800, 341);
            this.panChampSelect.TabIndex = 2;
            this.panChampSelect.Visible = false;
            // 
            // lblTitleSelectedChamp
            // 
            this.lblTitleSelectedChamp.AutoSize = true;
            this.lblTitleSelectedChamp.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitleSelectedChamp.Location = new System.Drawing.Point(12, 62);
            this.lblTitleSelectedChamp.Name = "lblTitleSelectedChamp";
            this.lblTitleSelectedChamp.Size = new System.Drawing.Size(193, 32);
            this.lblTitleSelectedChamp.TabIndex = 3;
            this.lblTitleSelectedChamp.Text = "Selected Champ:";
            this.lblTitleSelectedChamp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleMap
            // 
            this.lblTitleMap.AutoSize = true;
            this.lblTitleMap.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitleMap.Location = new System.Drawing.Point(12, 14);
            this.lblTitleMap.Name = "lblTitleMap";
            this.lblTitleMap.Size = new System.Drawing.Size(67, 32);
            this.lblTitleMap.TabIndex = 2;
            this.lblTitleMap.Text = "Map:";
            this.lblTitleMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tPanSummonerInfo
            // 
            this.tPanSummonerInfo.ColumnCount = 2;
            this.tPanSummonerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.5F));
            this.tPanSummonerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.5F));
            this.tPanSummonerInfo.Controls.Add(this.picSummonerIcon, 0, 0);
            this.tPanSummonerInfo.Controls.Add(this.panSummonerInfo, 1, 0);
            this.tPanSummonerInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.tPanSummonerInfo.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tPanSummonerInfo.Location = new System.Drawing.Point(0, 0);
            this.tPanSummonerInfo.Name = "tPanSummonerInfo";
            this.tPanSummonerInfo.RowCount = 1;
            this.tPanSummonerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tPanSummonerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 109F));
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
            // panSummonerInfo
            // 
            this.panSummonerInfo.Controls.Add(this.lblEarnableChest);
            this.panSummonerInfo.Controls.Add(this.lblSummonerName);
            this.panSummonerInfo.Controls.Add(this.lblTitleChests);
            this.panSummonerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panSummonerInfo.Location = new System.Drawing.Point(119, 3);
            this.panSummonerInfo.Name = "panSummonerInfo";
            this.panSummonerInfo.Size = new System.Drawing.Size(678, 103);
            this.panSummonerInfo.TabIndex = 1;
            // 
            // lblEarnableChest
            // 
            this.lblEarnableChest.AutoSize = true;
            this.lblEarnableChest.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEarnableChest.Location = new System.Drawing.Point(196, 37);
            this.lblEarnableChest.Name = "lblEarnableChest";
            this.lblEarnableChest.Size = new System.Drawing.Size(0, 40);
            this.lblEarnableChest.TabIndex = 3;
            this.lblEarnableChest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSummonerName
            // 
            this.lblSummonerName.AutoSize = true;
            this.lblSummonerName.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSummonerName.Location = new System.Drawing.Point(3, 6);
            this.lblSummonerName.Name = "lblSummonerName";
            this.lblSummonerName.Size = new System.Drawing.Size(0, 40);
            this.lblSummonerName.TabIndex = 2;
            this.lblSummonerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleChests
            // 
            this.lblTitleChests.AutoSize = true;
            this.lblTitleChests.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitleChests.Location = new System.Drawing.Point(3, 43);
            this.lblTitleChests.Name = "lblTitleChests";
            this.lblTitleChests.Size = new System.Drawing.Size(187, 32);
            this.lblTitleChests.TabIndex = 1;
            this.lblTitleChests.Text = "Earnable Chests:";
            this.lblTitleChests.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panNoChampSalect
            // 
            this.panNoChampSalect.Controls.Add(this.lblTitleWaiting);
            this.panNoChampSalect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panNoChampSalect.Location = new System.Drawing.Point(0, 0);
            this.panNoChampSalect.Name = "panNoChampSalect";
            this.panNoChampSalect.Size = new System.Drawing.Size(800, 450);
            this.panNoChampSalect.TabIndex = 2;
            // 
            // lblTitleWaiting
            // 
            this.lblTitleWaiting.AutoSize = true;
            this.lblTitleWaiting.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitleWaiting.Location = new System.Drawing.Point(172, 241);
            this.lblTitleWaiting.Name = "lblTitleWaiting";
            this.lblTitleWaiting.Size = new System.Drawing.Size(418, 40);
            this.lblTitleWaiting.TabIndex = 3;
            this.lblTitleWaiting.Text = "Waiting for Champ Select stage";
            this.lblTitleWaiting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panChampSelect.ResumeLayout(false);
            this.panChampSelect.PerformLayout();
            this.tPanSummonerInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSummonerIcon)).EndInit();
            this.panSummonerInfo.ResumeLayout(false);
            this.panSummonerInfo.PerformLayout();
            this.panNoChampSalect.ResumeLayout(false);
            this.panNoChampSalect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panLoLNotRunning;
        private System.Windows.Forms.Panel panLoLIsRunning;
        private System.Windows.Forms.PictureBox picConnecting;
        private System.Windows.Forms.Label lblConnecting;
        private System.Windows.Forms.TableLayoutPanel tPanSummonerInfo;
        private System.Windows.Forms.PictureBox picSummonerIcon;
        private System.Windows.Forms.Panel panSummonerInfo;
        private System.Windows.Forms.Label lblTitleChests;
        private System.Windows.Forms.Label lblEarnableChest;
        private System.Windows.Forms.Label lblSummonerName;
        private System.Windows.Forms.Panel panNoChampSalect;
        private System.Windows.Forms.Label lblTitleWaiting;
        private System.Windows.Forms.Panel panChampSelect;
        private System.Windows.Forms.Label lblTitleSelectedChamp;
        private System.Windows.Forms.Label lblTitleMap;
    }
}