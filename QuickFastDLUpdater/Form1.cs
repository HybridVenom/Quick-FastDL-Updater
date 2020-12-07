using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickFastDLUpdater
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        // _Click
        private void btnBrowseServer_Click(object sender, EventArgs e)
        {
            using(var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBoxServerpath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnBrowseFastDL_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBoxFastDLpath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            // Check if server textbox has text
            if (string.IsNullOrWhiteSpace(textBoxServerpath.Text))
            {
                MessageBox.Show("Please check that you entered the correct server path.\n(Same folder as 'srcds.exe')", "Invalid server path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if fastdl textbox has text
            if (string.IsNullOrWhiteSpace(textBoxFastDLpath.Text))
            {
                MessageBox.Show("Please check if you entered a correct path to the FastDL folder.", "Invalid FastDL path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelSteam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://steamcommunity.com/profiles/76561197996468677");
        }

        private void linkLabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://github.com/HybridVenom");
        }
    }
}
