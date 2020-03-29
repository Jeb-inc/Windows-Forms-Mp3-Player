using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mp3_Player
{
    public partial class Form1 : Form
    {
        SoundPlayer player;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer();
        }

        private void fileSelectBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "WAV|*.wav", Multiselect = false, ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName.Text = ofd.FileName;
                }
            }
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileName.Text))
            {
                return;
            }

            try
            {
                player.SoundLocation = fileName.Text;
                player.Play();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            player.Stop();
        }
    }
}