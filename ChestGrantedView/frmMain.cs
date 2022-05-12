using ChestGrantedCore;
using ChestGrantedCore.EventsArgs;
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
            ChestGrantedController eventController = new ChestGrantedController(this);

            InitView();
        }

        private void InitView()
        {
            SetLablesStyle();
        }

        private void SetLablesStyle()
        {
            panLoLNotRunning.BackColor = Colors.BackColor;
            lblConnecting.BackColor = Colors.BackColor;
            lblConnecting.ForeColor = Colors.ForeColor;
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

    }
}
