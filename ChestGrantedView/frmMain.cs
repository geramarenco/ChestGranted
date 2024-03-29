﻿using ChestGrantedController;
using ChestGrantedRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChestGrantedView
{
    public partial class frmMain : Form, IChestGrantedView
    {
        public frmMain()
        {
            InitializeComponent();
            CGController controller = new CGController(this);
            InitView();
        }

        private void InitView()
        {
            SetColors();
        }

        private void SetColors()
        {
            panLoLNotRunning.BackColor = Colors.BackColor;
            panLoLIsRunning.BackColor = Colors.BackColor;
            panSummonerInfo.BackColor = Colors.BackColor;
            lstMyTeamChamps.BackColor = Colors.BackColor;
            lstBenchChamps.BackColor = Colors.BackColor;

            lblConnecting.ForeColor = Colors.ForeColor;
            lblEarnableChest.ForeColor = Colors.ForeColor;
            lblSummonerName.ForeColor = Colors.ForeColor;
            lblMyChampName.ForeColor = Colors.ForeColor;
            lblChestCount.ForeColor = Colors.ForeColor;
            lblNextChestIn.ForeColor = Colors.ForeColor;

            lblTitleChests.ForeColor = Colors.ForeColor;
            lblTitleWaiting.ForeColor = Colors.ForeColor;
            lblTitleSelectedChamp.ForeColor = Colors.ForeColor;
            lblTitleMyTeam.ForeColor = Colors.ForeColor;
            lblTitleBenchCamps.ForeColor = Colors.ForeColor;

            
        }

        public bool LoLIsRunning
        {
            get => panLoLIsRunning.Visible;
            set
            {
                panLoLIsRunning.Visible = value;
                panLoLNotRunning.Visible = !value;
            }
        }

        public string SummonerName { get => lblSummonerName.Text; set => lblSummonerName.Text = value; }
        public int EarnableChests { get => int.Parse(lblEarnableChest.Text); set => lblEarnableChest.Text = value.ToString(); }

        string _profilePicture = "";
        public string ProfilePicture
        {
            get => _profilePicture;
            set
            {
                try
                {
                    _profilePicture = value;
                    //picSummonerIcon.Image = new Bitmap(_profilePicture);
                    picSummonerIcon.Image = new Bitmap(Helpers.OvalImage(new Bitmap(_profilePicture)), new Size(100, 100));
                }
                catch (Exception ex)
                {
                    picSummonerIcon.Image = Properties.Resources.imgNotFound;
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public bool ChampSelectStageVisible {
            get => panARAMChampSelect.Visible;
            set
            {
                panNoChampSalect.Visible = !value;
                panARAMChampSelect.Visible = value;
            }

        }

        Champion _mySelectedChamp;
        public Champion MySelectedChamp
        { 
            get => _mySelectedChamp;
            set
            {
                _mySelectedChamp = value;
                picSelectedChamp.Image = null;
                lblMyChampName.Text = "";
                
                if (_mySelectedChamp == null) return;
                
                if (!imgChamps_120x120.Images.ContainsKey(_mySelectedChamp.PictureName))
                    imgChamps_120x120.Images.Add(_mySelectedChamp.PictureName, Image.FromFile(_mySelectedChamp.PicturePath));

                if(_mySelectedChamp.ChestEarned)
                    picSelectedChamp.Image = Helpers.MakeGrayscale(imgChamps_120x120.Images[_mySelectedChamp.PictureName]);
                else
                    picSelectedChamp.Image = imgChamps_120x120.Images[_mySelectedChamp.PictureName];
                lblMyChampName.Text = _mySelectedChamp.Name;
            }
        }

        List<Champion> _myTeamChamps;
        public List<Champion> MyTeamChamps
        {
            get => _myTeamChamps;
            set
            {
                _myTeamChamps = value;
                lstMyTeamChamps.Items.Clear();

                if (_myTeamChamps == null) return;

                foreach (var c in _myTeamChamps)
                {
                    if (!imgChamps_60x60.Images.ContainsKey(c.PictureName))
                    {
                        imgChamps_60x60.Images.Add(c.PictureName, Image.FromFile(c.PicturePath));
                        imgChamps_60x60.Images.Add($"Gray{c.PictureName}", Helpers.MakeGrayscale(Image.FromFile(c.PicturePath)));
                    }

                    var item = new ListViewItem()
                    {
                        ForeColor = Colors.ForeColor,
                        ImageKey = c.ChestEarned ? $"Gray{c.PictureName}" : c.PictureName,
                        Text = c.Name,
                    };
                    lstMyTeamChamps.Items.Add(item);
                }
            }
        }

        List<Champion> _benchChamps;
        public List<Champion> BenchChamps
        {
            get => _benchChamps;
            set
            {
                _benchChamps = value;
                lstBenchChamps.Items.Clear();

                if (_benchChamps == null) return;

                foreach (var c in _benchChamps)
                {
                    if (!imgChamps_60x60.Images.ContainsKey(c.PictureName))
                    {
                        imgChamps_60x60.Images.Add(c.PictureName, Image.FromFile(c.PicturePath));
                        imgChamps_60x60.Images.Add($"Gray{c.PictureName}", Helpers.MakeGrayscale(Image.FromFile(c.PicturePath)));
                    }

                    var item = new ListViewItem()
                    {
                        ForeColor = Colors.ForeColor,
                        ImageKey = c.ChestEarned ? $"Gray{c.PictureName}" : c.PictureName,
                        Text = c.Name,
                    };
                    lstBenchChamps.Items.Add(item);
                }
            }
        }

        int _chestCount = 0;
        public int ChestCount
        {
            get => _chestCount;
            set
            {
                _chestCount = value;
                SetTotalChestsText();
            }
        }

        int _earnedChests = 0;
        public int EarnedChests
        {
            get => _earnedChests;
            set 
            {
                _earnedChests = value;
                SetTotalChestsText();
            }
        }

        long _nextChestRechargeTime = 0;
        public long nextChestRechargeTime 
        { 
            get => _nextChestRechargeTime;
            set
            {
                _nextChestRechargeTime = value;
                // TODO first, I need to know the mesure of time for convert the value in days xD
                // lblNextChestIn.Visible = _nextChestRechargeTime != 0;
                string days = _nextChestRechargeTime == 0 ? "" : "s";
                lblNextChestIn.Text = $"next chest in {_nextChestRechargeTime} {days}";
            }
        }

        private void SetTotalChestsText()
        {
            lblChestCount.Visible = _chestCount != 0;
            lblChestCount.Text = $"Earned Chest {_earnedChests} of {_chestCount}";
        }

        public void ShowAlert(string message, string caption = "Alert")
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message, string caption = "Error")
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
