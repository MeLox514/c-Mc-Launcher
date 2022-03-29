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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DiscordRPC.EventHandlers handlers;
        private DiscordRPC.RichPresence presence;
        void RPC()
        {
            this.handlers = default(DiscordRPC.EventHandlers);
            DiscordRPC.Initialize("945034522888638534", ref this.handlers, true, null);
            this.presence.details = "LoRex";
            this.presence.state = "Client";
            this.presence.largeImageKey = "ay";
            this.presence.largeImageText = "LoRexClient";
            this.presence.startTimestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            DiscordRPC.UpdatePresence(ref this.presence);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 1;
            if (panel2.Width >= 300)
            {
                timer1.Stop();
                LoginScreen m = new LoginScreen();
                m.Show();
                Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RPC();
        }
    }
}
