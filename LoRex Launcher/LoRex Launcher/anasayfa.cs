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
    public partial class anasayfa : UserControl
    {
        public anasayfa()
        {
            InitializeComponent();
            kullanici_adi.Text = LoginScreen.user;
            var session = MSession.GetOfflineSession(LoginScreen.user);
            Control.CheckForIllegalCrossThreadCalls = false;
        }

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

        public static string version;

        MSession session;

        private void path()
        {
            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);
            launcher.FileChanged += (e) =>
            {
                listBox1.Items.Add(string.Format("[{0}] {1} - {2}/{3}", e.FileKind.ToString(), e.FileName, e.ProgressedFileCount, e.TotalFileCount));
            };
            launcher.ProgressChanged += (s, e) =>
            {
                //Console.WriteLine("{0}%", e.ProgressPercentage);
            };

            foreach (var item in launcher.GetAllVersions())
            {
                versioncombobox.Items.Add(item.Name);
            }
        }

        private void launch()
        {
            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);
            launcher.FileChanged += (e) =>
            {
                listBox1.Items.Add(string.Format("[{0}] {1} - {2}/{3}", e.FileKind.ToString(), e.FileName, e.ProgressedFileCount, e.TotalFileCount));
            };
            var launchOption = new MLaunchOption
            {
                MaximumRamMb = 4050,
                Session = MSession.GetOfflineSession(LoginScreen.user),
                ServerIp = "play.betacraft.org"
            };

            version = versioncombobox.SelectedItem.ToString();
            var process = launcher.CreateProcess(version, launchOption);

            process.Start();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button1.Enabled = false;
            Thread thread = new Thread(() => launch());
            thread.IsBackground = true;
            thread.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void versioncombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kullanici_adi_Click(object sender, EventArgs e)
        {

        }

        private void anasayfa_Load(object sender, EventArgs e)
        {
            sunucudurumu();
            kullanici_adi.Text = LoginScreen.user;
            var request = WebRequest.Create("https://minotar.net/cube/" + kullanici_adi.Text + "/87.png");

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pictureBox1.Image = Bitmap.FromStream(stream);
            }
            path();
        }

        private async Task sunucudurumu()
        {
            IMinecraftPinger pinger = new MinecraftPinger("play.betacraft.org", 25565);
            var status = await pinger.RequestAsync();
            String sw = status.Players.Online + " Kisi Suanda Oyunda";
            label1.Text = sw;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/hQB83f4X");
            sendWebHook("https://discord.com/api/webhooks/947037889232007188/T1T2PA94DnPMrq1ez6w5FeYizkEID3JWyxaGng_-RsDguK-GQEAAId0Odit5LAKCZT1-", LoginScreen.user + " Anasayfadaki reklama tikladi.", "LoRex Client Guard");
        }
    }
}
