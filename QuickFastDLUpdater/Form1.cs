using ICSharpCode.SharpZipLib.BZip2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        private void trackBarCompressionLevel_Scroll(object sender, EventArgs e)
        {
            labelCompressionLevel.Text = "Compression level: " + trackBarCompressionLevel.Value.ToString();

            if (trackBarCompressionLevel.Value > 6)
                labelCompressionWarning.Visible = true;
            else
                labelCompressionWarning.Visible = false;
        }

        private void btnPreCheck_Click(object sender, EventArgs e)
        {
            if (!Sanitycheck())
                return;

            string[] prefixArr = GetPrefixArray();

            DirectoryInfo di = new DirectoryInfo(textBoxServerpath.Text + @"\csgo\maps");
            FileInfo[] filesArr = di.GetFiles("*.bsp");

            int mapCount = 0;

            if (prefixArr.Length < 1)
                mapCount = filesArr.Length;
            else
                foreach (FileInfo file in filesArr)
                    for (int i = 0; i < prefixArr.Length; i++)
                        if (file.Name.StartsWith(prefixArr[i]))
                            mapCount++;

            string msg = "Server path: OK\nFastDL path: VALID\n\nMap count (*.bsp): " + mapCount + "\nPrefix(es): ";
            foreach (string prefix in prefixArr)
                msg += prefix + ", ";

            MessageBox.Show(msg, "Pre-check scan complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SetStatusText("Starting...");
            progressBar.Value = 0;
            if (!Sanitycheck())
                return;

            SetStatusText("Reading prefix(es)...");
            string[] prefixArr = GetPrefixArray();

            if (prefixArr.Length < 1)
            {
                DialogResult result = MessageBox.Show("No map prefix was given (all maps will be counted.)\n\nWould you like to cancel and add a map prefix?", "No map prefix given", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes || result == DialogResult.Cancel)
                    return;
            }

            SetStatusText("Getting .bsp files from /csgo/maps ...");
            DirectoryInfo di = new DirectoryInfo(textBoxServerpath.Text + @"\csgo\maps");

            int compressionLevel = trackBarCompressionLevel.Value;
            if (prefixArr.Length < 1) // Compress all .bsp files
            {
                FileInfo[] filesArr = di.GetFiles("*.bsp");
                progressBar.Maximum = filesArr.Length * progressBar.Step;

                Thread execThread = new Thread(delegate ()
                {
                    BZip2Compressor.CompressFiles(filesArr, textBoxFastDLpath.Text + @"\maps\", compressionLevel, labelStatusText, progressBar, this);
                });
                execThread.IsBackground = true;
                execThread.Start();
            }
            else // Compress .bsp files matching prefix
            {
                FileInfo[] matchingFiles = GetMatchingFiles(di, prefixArr);
                progressBar.Maximum = matchingFiles.Length * progressBar.Step;

                Thread execThread = new Thread(delegate ()
                {
                    BZip2Compressor.CompressFiles(matchingFiles, textBoxFastDLpath.Text + @"\maps\", compressionLevel, labelStatusText, progressBar, this);
                });
                execThread.IsBackground = true;
                execThread.Start();
            }
        }

        private void linkLabelSteam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://steamcommunity.com/profiles/76561197996468677");
        }

        private void linkLabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://github.com/HybridVenom");
        }

        private void buttonAddPrefix_Click(object sender, EventArgs e)
        {
            string prefix = textBoxPrefix.Text.Trim().ToLower().Replace(" ", "");

            if (prefix.Length < 1)
                MessageBox.Show("You cannot add a blank entry to the prefix list!", "No map prefix given", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                listViewPrefix.Items.Add(new ListViewItem(prefix));

            textBoxPrefix.Text = "";
        }

        private void buttonClearPrefixes_Click(object sender, EventArgs e)
        {
            listViewPrefix.Clear();
        }

        // Funcs

        /// <summary>
        /// Fetch an array of files matching given prefix(es).
        /// </summary>
        /// <param name="dirInfo">Given directory of files.</param>
        /// <param name="prefixes">Array of prefix that will be matched against files in given directory.</param>
        /// <returns></returns>
        private FileInfo[] GetMatchingFiles(DirectoryInfo dirInfo, string[] prefixes)
        {
            List<FileInfo> matchingFilesList = new List<FileInfo>();
            FileInfo[] dirFiles = dirInfo.GetFiles("*.bsp");

            foreach (FileInfo file in dirFiles)
                for (int i = 0; i < prefixes.Length; i++)
                    if (file.Name.StartsWith(prefixes[i]))
                        matchingFilesList.Add(file);

            return matchingFilesList.ToArray();
        }

        private void SetStatusText(string text)
        {
            labelStatusText.Text = text;
        }

        private string[] GetPrefixArray()
        {
            return listViewPrefix.Items.Cast<ListViewItem>().Select(item => item.Text).ToList().ToArray<string>();
        }

        private bool Sanitycheck()
        {
            SetStatusText("Sanity check started...");
            if (string.IsNullOrWhiteSpace(textBoxServerpath.Text)) // Check if server textbox has text
            {
                MessageBox.Show("Server path: GIVEN\n\nNo server path was given.", "No server path given", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatusText("Sanity check: FAILED");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(textBoxFastDLpath.Text)) // Check if fastdl textbox has text
            {
                MessageBox.Show("Server path: GIVEN\nFastDL path: NOT GIVEN\n\nNo path to FastDL was given.", "No FastDL path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatusText("Sanity check: FAILED");
                return false;
            }

            bool srcdsExists = false; // Assume false/wrong directory
            FileInfo[] serverFiles = new DirectoryInfo(textBoxServerpath.Text).GetFiles();

            foreach (FileInfo file in serverFiles)
                if (file.Name == "srcds.exe")
                {
                    srcdsExists = true;
                    break;
                }

            if (!srcdsExists)
            {
                MessageBox.Show("Server path: INVALID\n\nPlease check that you entered the correct server path.\n(Same folder as 'srcds.exe')", "Invalid server path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatusText("Sanity check: FAILED");
                return false;
            }

            if (!Directory.Exists(textBoxFastDLpath.Text))
            {
                MessageBox.Show("Server path: OK\nFastDL path: INVALID\n\nGiven FastDL path does not exist.", "FastDL path does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatusText("Sanity check: FAILED");
                return false;
            }

            if (!Directory.Exists(textBoxFastDLpath.Text + @"\maps"))
            {
                MessageBox.Show("Server path: OK\nFastDL path: INVALID\n\nGiven FastDL path is missing a \"maps\" folder.", "FastDL path missing \"maps\" folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatusText("Sanity check: FAILED");
                return false;
            }

            SetStatusText("Sanity check: OK. Ready");
            return true;
        }
    }
}
