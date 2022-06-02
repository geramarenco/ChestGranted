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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panLoLNotRunning = new System.Windows.Forms.Panel();
            this.lblConnecting = new System.Windows.Forms.Label();
            this.picConnecting = new System.Windows.Forms.PictureBox();
            this.panLoLIsRunning = new System.Windows.Forms.Panel();
            this.panARAMChampSelect = new System.Windows.Forms.Panel();
            this.lblTitleBenchCamps = new System.Windows.Forms.Label();
            this.lstBenchChamps = new System.Windows.Forms.ListView();
            this.imgChamps_60x60 = new System.Windows.Forms.ImageList(this.components);
            this.lblMyChampName = new System.Windows.Forms.Label();
            this.lblTitleMyTeam = new System.Windows.Forms.Label();
            this.lstMyTeamChamps = new System.Windows.Forms.ListView();
            this.imgChamps_120x120 = new System.Windows.Forms.ImageList(this.components);
            this.picSelectedChamp = new System.Windows.Forms.PictureBox();
            this.lblTitleSelectedChamp = new System.Windows.Forms.Label();
            this.tPanSummonerInfo = new System.Windows.Forms.TableLayoutPanel();
            this.picSummonerIcon = new System.Windows.Forms.PictureBox();
            this.panSummonerInfo = new System.Windows.Forms.Panel();
            this.lblNextChestIn = new System.Windows.Forms.Label();
            this.lblChestCount = new System.Windows.Forms.Label();
            this.lblEarnableChest = new System.Windows.Forms.Label();
            this.lblSummonerName = new System.Windows.Forms.Label();
            this.lblTitleChests = new System.Windows.Forms.Label();
            this.panNoChampSalect = new System.Windows.Forms.Panel();
            this.lblTitleWaiting = new System.Windows.Forms.Label();
            this.panLoLNotRunning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConnecting)).BeginInit();
            this.panLoLIsRunning.SuspendLayout();
            this.panARAMChampSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedChamp)).BeginInit();
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
            this.panLoLIsRunning.Controls.Add(this.panARAMChampSelect);
            this.panLoLIsRunning.Controls.Add(this.tPanSummonerInfo);
            this.panLoLIsRunning.Controls.Add(this.panNoChampSalect);
            this.panLoLIsRunning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panLoLIsRunning.Location = new System.Drawing.Point(0, 0);
            this.panLoLIsRunning.Name = "panLoLIsRunning";
            this.panLoLIsRunning.Size = new System.Drawing.Size(800, 450);
            this.panLoLIsRunning.TabIndex = 1;
            this.panLoLIsRunning.Visible = false;
            // 
            // panARAMChampSelect
            // 
            this.panARAMChampSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panARAMChampSelect.Controls.Add(this.lblTitleBenchCamps);
            this.panARAMChampSelect.Controls.Add(this.lstBenchChamps);
            this.panARAMChampSelect.Controls.Add(this.lblMyChampName);
            this.panARAMChampSelect.Controls.Add(this.lblTitleMyTeam);
            this.panARAMChampSelect.Controls.Add(this.lstMyTeamChamps);
            this.panARAMChampSelect.Controls.Add(this.picSelectedChamp);
            this.panARAMChampSelect.Controls.Add(this.lblTitleSelectedChamp);
            this.panARAMChampSelect.Location = new System.Drawing.Point(0, 112);
            this.panARAMChampSelect.Name = "panARAMChampSelect";
            this.panARAMChampSelect.Size = new System.Drawing.Size(797, 338);
            this.panARAMChampSelect.TabIndex = 2;
            this.panARAMChampSelect.Visible = false;
            // 
            // lblTitleBenchCamps
            // 
            this.lblTitleBenchCamps.AutoSize = true;
            this.lblTitleBenchCamps.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitleBenchCamps.Location = new System.Drawing.Point(221, 180);
            this.lblTitleBenchCamps.Name = "lblTitleBenchCamps";
            this.lblTitleBenchCamps.Size = new System.Drawing.Size(173, 32);
            this.lblTitleBenchCamps.TabIndex = 9;
            this.lblTitleBenchCamps.Text = "Bench Champs";
            this.lblTitleBenchCamps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstBenchChamps
            // 
            this.lstBenchChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBenchChamps.BackColor = System.Drawing.SystemColors.Control;
            this.lstBenchChamps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBenchChamps.HideSelection = false;
            this.lstBenchChamps.LargeImageList = this.imgChamps_60x60;
            this.lstBenchChamps.Location = new System.Drawing.Point(221, 215);
            this.lstBenchChamps.Name = "lstBenchChamps";
            this.lstBenchChamps.Size = new System.Drawing.Size(564, 111);
            this.lstBenchChamps.TabIndex = 8;
            this.lstBenchChamps.UseCompatibleStateImageBehavior = false;
            // 
            // imgChamps_60x60
            // 
            this.imgChamps_60x60.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imgChamps_60x60.ImageSize = new System.Drawing.Size(60, 60);
            this.imgChamps_60x60.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lblMyChampName
            // 
            this.lblMyChampName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMyChampName.Location = new System.Drawing.Point(12, 180);
            this.lblMyChampName.Name = "lblMyChampName";
            this.lblMyChampName.Size = new System.Drawing.Size(188, 32);
            this.lblMyChampName.TabIndex = 7;
            this.lblMyChampName.Text = "Nasus";
            this.lblMyChampName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleMyTeam
            // 
            this.lblTitleMyTeam.AutoSize = true;
            this.lblTitleMyTeam.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitleMyTeam.Location = new System.Drawing.Point(221, 3);
            this.lblTitleMyTeam.Name = "lblTitleMyTeam";
            this.lblTitleMyTeam.Size = new System.Drawing.Size(112, 32);
            this.lblTitleMyTeam.TabIndex = 6;
            this.lblTitleMyTeam.Text = "My Team";
            this.lblTitleMyTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstMyTeamChamps
            // 
            this.lstMyTeamChamps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMyTeamChamps.BackColor = System.Drawing.SystemColors.Control;
            this.lstMyTeamChamps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMyTeamChamps.HideSelection = false;
            this.lstMyTeamChamps.LargeImageList = this.imgChamps_60x60;
            this.lstMyTeamChamps.Location = new System.Drawing.Point(221, 38);
            this.lstMyTeamChamps.Name = "lstMyTeamChamps";
            this.lstMyTeamChamps.Size = new System.Drawing.Size(564, 139);
            this.lstMyTeamChamps.TabIndex = 5;
            this.lstMyTeamChamps.UseCompatibleStateImageBehavior = false;
            // 
            // imgChamps_120x120
            // 
            this.imgChamps_120x120.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imgChamps_120x120.ImageSize = new System.Drawing.Size(120, 120);
            this.imgChamps_120x120.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // picSelectedChamp
            // 
            this.picSelectedChamp.Location = new System.Drawing.Point(12, 38);
            this.picSelectedChamp.Name = "picSelectedChamp";
            this.picSelectedChamp.Size = new System.Drawing.Size(188, 139);
            this.picSelectedChamp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picSelectedChamp.TabIndex = 4;
            this.picSelectedChamp.TabStop = false;
            // 
            // lblTitleSelectedChamp
            // 
            this.lblTitleSelectedChamp.AutoSize = true;
            this.lblTitleSelectedChamp.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitleSelectedChamp.Location = new System.Drawing.Point(12, 3);
            this.lblTitleSelectedChamp.Name = "lblTitleSelectedChamp";
            this.lblTitleSelectedChamp.Size = new System.Drawing.Size(188, 32);
            this.lblTitleSelectedChamp.TabIndex = 3;
            this.lblTitleSelectedChamp.Text = "Selected Champ";
            this.lblTitleSelectedChamp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tPanSummonerInfo
            // 
            this.tPanSummonerInfo.ColumnCount = 2;
            this.tPanSummonerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tPanSummonerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tPanSummonerInfo.Controls.Add(this.picSummonerIcon, 0, 0);
            this.tPanSummonerInfo.Controls.Add(this.panSummonerInfo, 1, 0);
            this.tPanSummonerInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.tPanSummonerInfo.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tPanSummonerInfo.Location = new System.Drawing.Point(0, 0);
            this.tPanSummonerInfo.Name = "tPanSummonerInfo";
            this.tPanSummonerInfo.RowCount = 1;
            this.tPanSummonerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tPanSummonerInfo.Size = new System.Drawing.Size(800, 109);
            this.tPanSummonerInfo.TabIndex = 0;
            // 
            // picSummonerIcon
            // 
            this.picSummonerIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSummonerIcon.Location = new System.Drawing.Point(3, 3);
            this.picSummonerIcon.Name = "picSummonerIcon";
            this.picSummonerIcon.Size = new System.Drawing.Size(144, 103);
            this.picSummonerIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picSummonerIcon.TabIndex = 0;
            this.picSummonerIcon.TabStop = false;
            // 
            // panSummonerInfo
            // 
            this.panSummonerInfo.Controls.Add(this.lblNextChestIn);
            this.panSummonerInfo.Controls.Add(this.lblChestCount);
            this.panSummonerInfo.Controls.Add(this.lblEarnableChest);
            this.panSummonerInfo.Controls.Add(this.lblSummonerName);
            this.panSummonerInfo.Controls.Add(this.lblTitleChests);
            this.panSummonerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panSummonerInfo.Location = new System.Drawing.Point(153, 3);
            this.panSummonerInfo.Name = "panSummonerInfo";
            this.panSummonerInfo.Size = new System.Drawing.Size(644, 103);
            this.panSummonerInfo.TabIndex = 1;
            // 
            // lblNextChestIn
            // 
            this.lblNextChestIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNextChestIn.AutoSize = true;
            this.lblNextChestIn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblNextChestIn.Location = new System.Drawing.Point(418, 43);
            this.lblNextChestIn.Name = "lblNextChestIn";
            this.lblNextChestIn.Size = new System.Drawing.Size(217, 32);
            this.lblNextChestIn.TabIndex = 5;
            this.lblNextChestIn.Text = "next chest in 4 days";
            this.lblNextChestIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNextChestIn.Visible = false;
            // 
            // lblChestCount
            // 
            this.lblChestCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChestCount.AutoSize = true;
            this.lblChestCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChestCount.Location = new System.Drawing.Point(373, 12);
            this.lblChestCount.Name = "lblChestCount";
            this.lblChestCount.Size = new System.Drawing.Size(262, 32);
            this.lblChestCount.TabIndex = 4;
            this.lblChestCount.Text = "Earned Chest 888 / 888";
            this.lblChestCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEarnableChest
            // 
            this.lblEarnableChest.AutoSize = true;
            this.lblEarnableChest.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEarnableChest.Location = new System.Drawing.Point(196, 43);
            this.lblEarnableChest.Name = "lblEarnableChest";
            this.lblEarnableChest.Size = new System.Drawing.Size(27, 32);
            this.lblEarnableChest.TabIndex = 3;
            this.lblEarnableChest.Text = "4";
            this.lblEarnableChest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSummonerName
            // 
            this.lblSummonerName.AutoSize = true;
            this.lblSummonerName.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSummonerName.Location = new System.Drawing.Point(3, 6);
            this.lblSummonerName.Name = "lblSummonerName";
            this.lblSummonerName.Size = new System.Drawing.Size(165, 40);
            this.lblSummonerName.TabIndex = 2;
            this.lblSummonerName.Text = "Manmattan";
            this.lblSummonerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblTitleChests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panNoChampSalect
            // 
            this.panNoChampSalect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panNoChampSalect.Controls.Add(this.lblTitleWaiting);
            this.panNoChampSalect.Location = new System.Drawing.Point(0, 112);
            this.panNoChampSalect.Name = "panNoChampSalect";
            this.panNoChampSalect.Size = new System.Drawing.Size(797, 338);
            this.panNoChampSalect.TabIndex = 2;
            // 
            // lblTitleWaiting
            // 
            this.lblTitleWaiting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleWaiting.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitleWaiting.Location = new System.Drawing.Point(0, 108);
            this.lblTitleWaiting.Name = "lblTitleWaiting";
            this.lblTitleWaiting.Size = new System.Drawing.Size(797, 40);
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
            this.Text = "Available Chests";
            this.panLoLNotRunning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picConnecting)).EndInit();
            this.panLoLIsRunning.ResumeLayout(false);
            this.panARAMChampSelect.ResumeLayout(false);
            this.panARAMChampSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedChamp)).EndInit();
            this.tPanSummonerInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSummonerIcon)).EndInit();
            this.panSummonerInfo.ResumeLayout(false);
            this.panSummonerInfo.PerformLayout();
            this.panNoChampSalect.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panARAMChampSelect;
        private System.Windows.Forms.Label lblTitleSelectedChamp;
        private System.Windows.Forms.PictureBox picSelectedChamp;
        private System.Windows.Forms.Label lblTitleMyTeam;
        private System.Windows.Forms.ListView lstMyTeamChamps;
        private System.Windows.Forms.ImageList imgChamps_120x120;
        private System.Windows.Forms.Label lblMyChampName;
        private System.Windows.Forms.Label lblChestCount;
        private System.Windows.Forms.Label lblNextChestIn;
        private System.Windows.Forms.ImageList imgChamps_60x60;
        private System.Windows.Forms.Label lblTitleBenchCamps;
        private System.Windows.Forms.ListView lstBenchChamps;
    }
}