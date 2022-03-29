using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoRex_Launcher
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        public static string user;
        public static void sendWebHook(string url, string msg, string username)
        {
            http.Post(url, new System.Collections.Specialized.NameValueCollection()
            {
                {
                    "username",
                    username
                },
                {
                    "content",
                    msg
                }
            });
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            user = btn_kullanici_adi.Text;
            sendWebHook("https://discord.com/api/webhooks/947044792825679882/0trQteBgpxgelfoycXhrad-agqcIhzB1WckJy9zQNHiWXxtokDuemVxxdb32xQn1yzFN", btn_kullanici_adi.Text + " Giris yapti Moderatorler tarafindan inceleniyor...", "LoRex Client Guard");
            MainPage mp = new MainPage();
            mp.Show();
            Hide();
        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/hQB83f4X");
        }
    }
}
