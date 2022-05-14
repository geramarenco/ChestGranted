using ChestGrantedController;
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

            lblConnecting.BackColor = Colors.BackColor;
            lblConnecting.ForeColor = Colors.ForeColor;
            lblChests.BackColor = Colors.BackColor;
            lblChests.ForeColor = Colors.ForeColor;
            lblEarnableChest.BackColor = Colors.BackColor;
            lblEarnableChest.ForeColor = Colors.ForeColor;
            lblSummonerName.BackColor = Colors.BackColor;
            lblSummonerName.ForeColor = Colors.ForeColor;
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
    }
}
