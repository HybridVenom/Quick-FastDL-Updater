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

    public static void Compress(FileInfo[] fileArray, string outputPath, Label statusLabel, Form form)
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
                        BZip2.Compress(fileStream, compressedFileStream, true, 4096);
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

    public static void Compress(FileInfo[] fileArray, string outputPath, Label statusLabel, Form form, string[] prefixArray)
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
                                BZip2.Compress(fileStream, compressedFileStream, true, 4096);
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
