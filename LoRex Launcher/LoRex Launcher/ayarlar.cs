﻿using System;
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
    public partial class ayarlar : UserControl
    {
        public ayarlar()
        {
            InitializeComponent();
        }

        private void ayarlar_Load(object sender, EventArgs e)
        {
            kullanici_adi.Text = LoginScreen.user;
            var request = WebRequest.Create("https://minotar.net/cube/" + kullanici_adi.Text + "/87.png");

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pictureBox1.Image = Bitmap.FromStream(stream);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/hQB83f4X");
        }
    }
}
