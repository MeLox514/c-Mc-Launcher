using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using CmlLib.Core;
using CmlLib.Core.Auth;
using System.Threading;
using MCServerStatus;

namespace LoRex_Launcher
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            anasayfa1.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            profil1.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ayarlar1.BringToFront();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            anasayfa1.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            reklam1.BringToFront();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            magaza1.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            LoginScreen ls = new LoginScreen();
            ls.Show();
            Hide();
        }
    }
}
