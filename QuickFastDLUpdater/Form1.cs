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
            using (var fbd = new FolderBrowserDialog())
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

        private void btnPreCheck_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxServerpath.Text)) // Check if server textbox has text
            {
                MessageBox.Show("Please check that you entered the correct server path.\n(Same folder as 'srcds.exe')", "Invalid server path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBoxFastDLpath.Text)) // Check if fastdl textbox has text
            {
                MessageBox.Show("Please check if you entered a correct path to the FastDL folder.", "Invalid FastDL path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fullMapPrefix = textBoxPrefix.Text;
            string[] prefixArr = null;
            if (string.IsNullOrWhiteSpace(textBoxPrefix.Text))
            {
                DialogResult result = MessageBox.Show("No map prefix was given (all maps will be added to FastDL.)\n\nWould you like to cancel and add a map prefix?", "No map prefix", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    return;
                else
                    fullMapPrefix = null;
            }

            if (fullMapPrefix != null)
                prefixArr = fullMapPrefix.Split('/');

            DirectoryInfo di;
            FileInfo[] filesArr;
            DirectoryInfo[] directoryArr;

            // .\csgo\maps
            int mapCount = 0;

            di = new DirectoryInfo(textBoxServerpath.Text + "\\csgo\\maps");
            filesArr = di.GetFiles("*.bsp");

            if (fullMapPrefix == null)
                mapCount = filesArr.Length;
            else if (prefixArr != null)
                foreach (FileInfo file in filesArr)
                    for (int i = 0; i < prefixArr.Length; i++)
                        if (file.Name.StartsWith(prefixArr[i]))
                            mapCount++;

            // .\materials + iterate each folder
            // skip "panorama" & "allow1024.txt"
            int materialFolderCount;
            int materialCount;

            di = new DirectoryInfo(textBoxServerpath.Text + @"\csgo\materials");
            directoryArr = di.GetDirectories();

            materialFolderCount = directoryArr.Length;

            // .\sound + iterate each folder
            int soundFolderCount;
            int soundCount;

            //di = new DirectoryInfo(@"");





            MessageBox.Show("Map count (*.bsp): " + mapCount + "\nMaterial dirs.: " + materialFolderCount + "\nMaterials: ");
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
