using System;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.BZip2;

public static class BZip2Compressor
{
    #region Stackoverflow author: Thunder (/users/232687/thunder)
    delegate void setStatusTextCallback(Form f, Control ctrl, string text);
    /// <summary>
    /// Set the text property of given control.
    /// </summary>
    /// <param name="f">The calling form</param>
    /// <param name="ctrl">Reference to given control/item in the calling form.</param>
    /// <param name="text"></param>
    public static void SetStatusText(Form form, Control ctrl, string text)
    {
        // InvokeRequired required compares the thread ID of the 
        // calling thread to the thread ID of the creating thread. 
        // If these threads are different, it returns true. 
        if (ctrl.InvokeRequired)
        {
            setStatusTextCallback d = new setStatusTextCallback(SetStatusText);
            form.Invoke(d, new object[] { form, ctrl, text });
        }
        else
            ctrl.Text = text;
    }
    #endregion

    delegate void performStepProgressBarCallback(Form form, ProgressBar progressBar);

    public static void PerformStepProgressBar(Form form, ProgressBar progressBar)
    {
        if (progressBar.InvokeRequired)
        {
            performStepProgressBarCallback callback = new performStepProgressBarCallback(PerformStepProgressBar);
            form.Invoke(callback, new object[] { form, progressBar });
        }
        else
            progressBar.PerformStep();
    }

    /// <summary>
    /// Compress (based on compression level) all files in given file array to output path.
    /// </summary>
    /// <param name="fileArray">Array of files that will be compressed.</param>
    /// <param name="outputPath">Output path for compressed files.</param>
    /// <param name="compressionLevel">Level of compression (ranging from 1-9).</param>
    public static void CompressFiles(FileInfo[] fileArray, string outputPath, int compressionLevel)
    {
        foreach (FileInfo file in fileArray) // file: the file that is going to be compressed
        {
            FileInfo compressedFile = new FileInfo(outputPath + file.Name + ".bz2"); // compressedFile: Output, compressed file
            using (FileStream fileStream = file.OpenRead())
            using (FileStream compressedFileStream = compressedFile.Create())
                try
                {
                    BZip2.Compress(fileStream, compressedFileStream, true, compressionLevel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed @ BZip2.Compress(...)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
        }
    }

    /// <summary>
    /// Compress (based on compression level) all files in given file array to output path. Updates given label and progressbar through referenced form.
    /// </summary>
    /// <param name="fileArray">Array of files that will be compressed.</param>
    /// <param name="outputPath">Output path for compressed files.</param>
    /// <param name="compressionLevel">Level of compression (ranging from 1-9).</param>
    /// <param name="statusLabel">Reference to status label. Can be null.</param>
    /// <param name="progressBar">Reference to progress bar. Can be null.</param>
    /// <param name="form">Reference to the form where statusLabel is located.</param>
    public static void CompressFiles(FileInfo[] fileArray, string outputPath, int compressionLevel, Label statusLabel, ProgressBar progressBar, Form form)
    {
        foreach (FileInfo file in fileArray) // file: the file that is going to be compressed
        {
            if (statusLabel != null)
                SetStatusText(form, statusLabel, "Compressing " + file.Name + "...");
            FileInfo compressedFile = new FileInfo(outputPath + file.Name + ".bz2"); // compressedFile: Output, compressed file
            using (FileStream fileStream = file.OpenRead())
            using (FileStream compressedFileStream = compressedFile.Create())
                try
                {
                    BZip2.Compress(fileStream, compressedFileStream, true, compressionLevel);
                    if (progressBar != null)
                        PerformStepProgressBar(form, progressBar);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed @ BZip2.Compress(...)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetStatusText(form, statusLabel, "Failed on " + file.Name + "!");
                    return;
                }
        }
        if (statusLabel != null)
            SetStatusText(form, statusLabel, "Done!");
    }
}
