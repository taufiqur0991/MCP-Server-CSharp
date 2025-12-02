using ModelContextProtocol.Server;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;

[McpServerToolType]
public static class PingTools
{
    [McpServerTool(Name = "ping"), Description("Ping to host then back message to the client.")]
    public static string Ping(string host)
    {
        try
        {
            // Tentukan command dan args sesuai OS
            string command;
            string args;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                command = "cmd.exe";
                args = $"/c ping {host}";
            }
            else
            {
                // Linux & macOS
                command = "/bin/bash";
                args = $"-c \"ping -c 4 {host}\"";  // -c 4 = ping 4x
            }

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            if (!string.IsNullOrWhiteSpace(error))
            {
                return $"ERROR: {error}";
            }

            return output; // Hasil ping
        }
        catch (Exception ex)
        {
            return $"Exception: {ex.Message}";
        }
    }
}
