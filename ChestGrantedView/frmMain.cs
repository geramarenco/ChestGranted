using ChestGrantedController;
using ChestGrantedController.Class;
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

            lblConnecting.ForeColor = Colors.ForeColor;
            lblEarnableChest.ForeColor = Colors.ForeColor;
            lblSummonerName.ForeColor = Colors.ForeColor;

            lblTitleChests.ForeColor = Colors.ForeColor;
            lblTitleWaiting.ForeColor = Colors.ForeColor;
            lblTitleMap.ForeColor = Colors.ForeColor;
            lblTitleSelectedChamp.ForeColor = Colors.ForeColor;
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
                    picSummonerIcon.Image = new Bitmap(_profilePicture);
                }
                catch (Exception ex)
                {
                    picSummonerIcon.Image = ChestGrantedView.Properties.Resources.imgNotFound;
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public bool ChampSelectStageVisible {
            get => panChampSelect.Visible;
            set
            {
                panNoChampSalect.Visible = !value;
                panChampSelect.Visible = value;
            }

        }

        SelectedChampion _mySelectedChamp;
        public SelectedChampion MySelectedChamp { 
            get => _mySelectedChamp;
            set => _mySelectedChamp = value;
        }

        List<SelectedChampion> _myTeamChamps;
        public List<SelectedChampion> MyTeamChamps {
            get => _myTeamChamps;
            set => _myTeamChamps = value;
        }
    }
}
