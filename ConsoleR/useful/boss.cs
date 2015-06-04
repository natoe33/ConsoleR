using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleR.useful
{
    class boss
    {
        public static void BossMode()
        {
            Console.Title = @"C:\WINDOWS\System32\cmd.exe";
            var boss = new Process {StartInfo = new ProcessStartInfo("cmd.exe")};
            boss.StartInfo.CreateNoWindow = boss.StartInfo.RedirectStandardOutput = boss.StartInfo.RedirectStandardInput = true;
            boss.StartInfo.UseShellExecute = false;
            boss.Start();
            var reader = new StreamReader(boss.StandardOutput.BaseStream);
            var writer = new StreamWriter(boss.StandardInput.BaseStream);
            writer.WriteLine("C:");
            writer.Flush();
            writer.WriteLine("cd \\Windows");
            writer.Flush();
            writer.WriteLine("dir C:\\Windows");
            writer.Close();
            writer.Dispose();
            Console.Write(reader.ReadToEnd());
            reader.Close();
            reader.Dispose();
        }
    }
}
