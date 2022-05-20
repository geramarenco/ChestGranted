using ChestGrantedController;
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

            lblConnecting.ForeColor = Colors.ForeColor;
            lblEarnableChest.ForeColor = Colors.ForeColor;
            lblSummonerName.ForeColor = Colors.ForeColor;
            lblMyChampName.ForeColor = Colors.ForeColor;

            lblTitleChests.ForeColor = Colors.ForeColor;
            lblTitleWaiting.ForeColor = Colors.ForeColor;
            lblTitleSelectedChamp.ForeColor = Colors.ForeColor;
            lblTitlePoolOfChamps.ForeColor = Colors.ForeColor;
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
                
                if (!imgChamps.Images.ContainsKey(_mySelectedChamp.PictureName))
                    imgChamps.Images.Add(_mySelectedChamp.PictureName, Image.FromFile(_mySelectedChamp.PicturePath));

                picSelectedChamp.Image = imgChamps.Images[_mySelectedChamp.PictureName];
                lblMyChampName.Text = _mySelectedChamp.Name;
            }
        }

        List<Champion> _myTeamChamps;
        public List<Champion> MyTeamChamps {
            get => _myTeamChamps;
            set
            {
                _myTeamChamps = value;
                lstMyTeamChamps.Items.Clear();

                if (_myTeamChamps == null) return;

                foreach (var c in _myTeamChamps)
                {
                    if (!imgChamps.Images.ContainsKey(c.PictureName))
                        imgChamps.Images.Add(c.PictureName, Image.FromFile(c.PicturePath));

                    var item = new ListViewItem()
                    {
                        ForeColor = Colors.ForeColor,
                        ImageKey = c.PictureName,
                        Text = c.Name,
                    };
                    lstMyTeamChamps.Items.Add(item);
                }

            }
        }
    }
}
