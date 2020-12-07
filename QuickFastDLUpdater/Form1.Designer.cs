
namespace QuickFastDLUpdater
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelStatusText = new System.Windows.Forms.Label();
            this.labelFastDLPath = new System.Windows.Forms.Label();
            this.labelCSGOPath = new System.Windows.Forms.Label();
            this.linkLabelGitHub = new System.Windows.Forms.LinkLabel();
            this.linkLabelSteam = new System.Windows.Forms.LinkLabel();
            this.textBoxServerpath = new System.Windows.Forms.TextBox();
            this.textBoxFastDLpath = new System.Windows.Forms.TextBox();
            this.btnBrowseServer = new System.Windows.Forms.Button();
            this.btnBrowseFastDL = new System.Windows.Forms.Button();
            this.btnPreCheck = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.textBoxPrefix = new System.Windows.Forms.TextBox();
            this.labelPrefix = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // labelStatusText
            // 
            this.labelStatusText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelStatusText.Location = new System.Drawing.Point(0, 429);
            this.labelStatusText.Name = "labelStatusText";
            this.labelStatusText.Size = new System.Drawing.Size(384, 21);
            this.labelStatusText.TabIndex = 0;
            this.labelStatusText.Text = "Ready";
            this.labelStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFastDLPath
            // 
            this.labelFastDLPath.AutoSize = true;
            this.labelFastDLPath.Location = new System.Drawing.Point(9, 62);
            this.labelFastDLPath.Name = "labelFastDLPath";
            this.labelFastDLPath.Size = new System.Drawing.Size(132, 13);
            this.labelFastDLPath.TabIndex = 1;
            this.labelFastDLPath.Text = "FastDL path / Output path";
            // 
            // labelCSGOPath
            // 
            this.labelCSGOPath.AutoSize = true;
            this.labelCSGOPath.Location = new System.Drawing.Point(9, 9);
            this.labelCSGOPath.Name = "labelCSGOPath";
            this.labelCSGOPath.Size = new System.Drawing.Size(98, 13);
            this.labelCSGOPath.TabIndex = 2;
            this.labelCSGOPath.Text = "CS:GO Server path";
            // 
            // linkLabelGitHub
            // 
            this.linkLabelGitHub.AutoSize = true;
            this.linkLabelGitHub.Location = new System.Drawing.Point(332, 387);
            this.linkLabelGitHub.Name = "linkLabelGitHub";
            this.linkLabelGitHub.Size = new System.Drawing.Size(40, 13);
            this.linkLabelGitHub.TabIndex = 101;
            this.linkLabelGitHub.TabStop = true;
            this.linkLabelGitHub.Text = "GitHub";
            this.linkLabelGitHub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelGitHub.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkLabelGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGitHub_LinkClicked);
            // 
            // linkLabelSteam
            // 
            this.linkLabelSteam.AutoSize = true;
            this.linkLabelSteam.Location = new System.Drawing.Point(289, 387);
            this.linkLabelSteam.Name = "linkLabelSteam";
            this.linkLabelSteam.Size = new System.Drawing.Size(37, 13);
            this.linkLabelSteam.TabIndex = 100;
            this.linkLabelSteam.TabStop = true;
            this.linkLabelSteam.Text = "Steam";
            this.linkLabelSteam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelSteam.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkLabelSteam.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSteam_LinkClicked);
            // 
            // textBoxServerpath
            // 
            this.textBoxServerpath.Location = new System.Drawing.Point(12, 25);
            this.textBoxServerpath.Name = "textBoxServerpath";
            this.textBoxServerpath.Size = new System.Drawing.Size(281, 20);
            this.textBoxServerpath.TabIndex = 0;
            this.textBoxServerpath.Text = "D:\\Program Files (x86)\\CSGO Server";
            // 
            // textBoxFastDLpath
            // 
            this.textBoxFastDLpath.Location = new System.Drawing.Point(12, 78);
            this.textBoxFastDLpath.Name = "textBoxFastDLpath";
            this.textBoxFastDLpath.Size = new System.Drawing.Size(281, 20);
            this.textBoxFastDLpath.TabIndex = 2;
            this.textBoxFastDLpath.Text = "C:\\Users\\alexa\\Desktop\\XD";
            // 
            // btnBrowseServer
            // 
            this.btnBrowseServer.Location = new System.Drawing.Point(299, 25);
            this.btnBrowseServer.Name = "btnBrowseServer";
            this.btnBrowseServer.Size = new System.Drawing.Size(75, 20);
            this.btnBrowseServer.TabIndex = 1;
            this.btnBrowseServer.Text = "Browse";
            this.btnBrowseServer.UseVisualStyleBackColor = true;
            this.btnBrowseServer.Click += new System.EventHandler(this.btnBrowseServer_Click);
            // 
            // btnBrowseFastDL
            // 
            this.btnBrowseFastDL.Location = new System.Drawing.Point(299, 78);
            this.btnBrowseFastDL.Name = "btnBrowseFastDL";
            this.btnBrowseFastDL.Size = new System.Drawing.Size(75, 20);
            this.btnBrowseFastDL.TabIndex = 3;
            this.btnBrowseFastDL.Text = "Browse";
            this.btnBrowseFastDL.UseVisualStyleBackColor = true;
            this.btnBrowseFastDL.Click += new System.EventHandler(this.btnBrowseFastDL_Click);
            // 
            // btnPreCheck
            // 
            this.btnPreCheck.Location = new System.Drawing.Point(155, 198);
            this.btnPreCheck.Name = "btnPreCheck";
            this.btnPreCheck.Size = new System.Drawing.Size(75, 20);
            this.btnPreCheck.TabIndex = 5;
            this.btnPreCheck.Text = "Pre-check";
            this.btnPreCheck.UseVisualStyleBackColor = true;
            this.btnPreCheck.Click += new System.EventHandler(this.btnPreCheck_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(155, 246);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 20);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBoxPrefix
            // 
            this.textBoxPrefix.Location = new System.Drawing.Point(155, 151);
            this.textBoxPrefix.Name = "textBoxPrefix";
            this.textBoxPrefix.Size = new System.Drawing.Size(77, 20);
            this.textBoxPrefix.TabIndex = 4;
            // 
            // labelPrefix
            // 
            this.labelPrefix.AutoSize = true;
            this.labelPrefix.Location = new System.Drawing.Point(157, 135);
            this.labelPrefix.Name = "labelPrefix";
            this.labelPrefix.Size = new System.Drawing.Size(73, 13);
            this.labelPrefix.TabIndex = 15;
            this.labelPrefix.Text = "Map prefix(es)";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 403);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(360, 23);
            this.progressBar1.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelPrefix);
            this.Controls.Add(this.textBoxPrefix);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnPreCheck);
            this.Controls.Add(this.btnBrowseFastDL);
            this.Controls.Add(this.btnBrowseServer);
            this.Controls.Add(this.textBoxFastDLpath);
            this.Controls.Add(this.textBoxServerpath);
            this.Controls.Add(this.linkLabelSteam);
            this.Controls.Add(this.linkLabelGitHub);
            this.Controls.Add(this.labelCSGOPath);
            this.Controls.Add(this.labelFastDLPath);
            this.Controls.Add(this.labelStatusText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Quick FastDL Updater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStatusText;
        private System.Windows.Forms.Label labelFastDLPath;
        private System.Windows.Forms.Label labelCSGOPath;
        private System.Windows.Forms.LinkLabel linkLabelGitHub;
        private System.Windows.Forms.LinkLabel linkLabelSteam;
        private System.Windows.Forms.TextBox textBoxServerpath;
        private System.Windows.Forms.TextBox textBoxFastDLpath;
        private System.Windows.Forms.Button btnBrowseServer;
        private System.Windows.Forms.Button btnBrowseFastDL;
        private System.Windows.Forms.Button btnPreCheck;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBoxPrefix;
        private System.Windows.Forms.Label labelPrefix;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

