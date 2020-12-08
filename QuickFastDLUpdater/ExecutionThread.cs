using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.BZip2;

public static class ExecutionThread
{
    delegate void setStatusTextCallback(Form f, Control ctrl, string text);
    /// <summary>
    /// Set the text property of given control
    /// </summary>
    /// <param name="f">The calling form</param>
    /// <param name="ctrl"></param>
    /// <param name="text"></param>
    public static void setStatusText(Form form, Control ctrl, string text)
    {
        // InvokeRequired required compares the thread ID of the 
        // calling thread to the thread ID of the creating thread. 
        // If these threads are different, it returns true. 
        if (ctrl.InvokeRequired)
        {
            setStatusTextCallback d = new setStatusTextCallback(setStatusText);
            form.Invoke(d, new object[] { form, ctrl, text });
        }
        else
            ctrl.Text = text;
    }

    /// <summary>
    /// Compress (based on compression level) all files in given file array to output path.
    /// </summary>
    /// <param name="fileArray">Array of files that will be compressed.</param>
    /// <param name="outputPath">Output path for compressed files.</param>
    /// <param name="compressionLevel">Level of compression (ranging from 1-9).</param>
    public static void Compress(FileInfo[] fileArray, string outputPath, int compressionLevel)
    {
        foreach (FileInfo file in fileArray) // file: the file that is going to be compressed
        {
            FileInfo compressedFile = new FileInfo(outputPath + file.Name + ".bz2"); // compressedFile: Output, compressed file
            using (FileStream fileStream = file.OpenRead())
            {
                using (FileStream compressedFileStream = compressedFile.Create())
                {
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
        }
    }

    /// <summary>
    /// Compress (based on compression level) files in given file array that match with any given prefix to output path. Updates given label through referenced form.
    /// </summary>
    /// <param name="fileArray">Array of files that will be compressed.</param>
    /// <param name="outputPath">Output path for compressed files.</param>
    /// <param name="compressionLevel">Level of compression (ranging from 1-9).</param>
    /// <param name="prefixArray">Array of prefixes, matching files will be compressed.</param>
    public static void Compress(FileInfo[] fileArray, string outputPath, int compressionLevel, string[] prefixArray)
    {
        foreach (FileInfo file in fileArray) // file: the file that is going to be compressed
            for (int i = 0; i < prefixArray.Length; i++) // Check if current
                if (file.Name.StartsWith(prefixArray[i]))
                {
                    FileInfo compressedFile = new FileInfo(outputPath + file.Name + ".bz2"); // compressedFile: Output, compressed file
                    using (FileStream fileStream = file.OpenRead())
                    {
                        using (FileStream compressedFileStream = compressedFile.Create())
                        {
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
                }
    }

    /// <summary>
    /// Compress (based on compression level) all files in given file array to output path. Updates given label through referenced form.
    /// </summary>
    /// <param name="fileArray">Array of files that will be compressed.</param>
    /// <param name="outputPath">Output path for compressed files.</param>
    /// <param name="compressionLevel">Level of compression (ranging from 1-9).</param>
    /// <param name="statusLabel">Reference to status label.</param>
    /// <param name="form">Reference to the form where statusLabel is located.</param>
    public static void Compress(FileInfo[] fileArray, string outputPath, int compressionLevel, Label statusLabel, Form form)
    {
        foreach (FileInfo file in fileArray) // file: the file that is going to be compressed
        {
            setStatusText(form, statusLabel, "Compressing " + file.Name + "...");
            FileInfo compressedFile = new FileInfo(outputPath + file.Name + ".bz2"); // compressedFile: Output, compressed file
            using (FileStream fileStream = file.OpenRead())
            {
                using (FileStream compressedFileStream = compressedFile.Create())
                {
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
        }
        setStatusText(form, statusLabel, "Ready");
    }

    /// <summary>
    /// Compress (based on compression level) files in given file array that match with any given prefix to output path. Updates given label through referenced form.
    /// </summary>
    /// <param name="fileArray">Array of files that will be compressed.</param>
    /// <param name="outputPath">Output path for compressed files.</param>
    /// <param name="compressionLevel">Level of compression (ranging from 1-9).</param>
    /// <param name="prefixArray">Array of prefixes, matching files will be compressed.</param>
    /// <param name="statusLabel">Reference to status label.</param>
    /// <param name="form">Reference to the form where statusLabel is located.</param>
    public static void Compress(FileInfo[] fileArray, string outputPath, int compressionLevel, string[] prefixArray, Label statusLabel, Form form)
    {
        foreach (FileInfo file in fileArray) // file: the file that is going to be compressed
            for (int i = 0; i < prefixArray.Length; i++) // Check if current
                if (file.Name.StartsWith(prefixArray[i]))
                {
                    setStatusText(form, statusLabel, "Compressing " + file.Name + "...");
                    FileInfo compressedFile = new FileInfo(outputPath + file.Name + ".bz2"); // compressedFile: Output, compressed file
                    using (FileStream fileStream = file.OpenRead())
                    {
                        using (FileStream compressedFileStream = compressedFile.Create())
                        {
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
                }
        setStatusText(form, statusLabel, "Ready");
    }


}
