using System.Collections.Generic;
using System.Diagnostics;

namespace ShadowzBurns.Utmp
{
	public static class Dump
	{
		/// <summary>
		/// Opens the utmp/wtmp file and retrieves all records
		/// </summary>
		/// <param name="filename">The filename of the utmp/wtmp file, if not path is give the default value is '/var/log/wtmp'</param>
		/// <returns>All the lines as an IEnumerable of strings</returns>
		public static IEnumerable<string> Get(string filename = "/var/log/wtmp")
		{
			var process = new Process();
			// Redirect the output stream of the child process.
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.FileName = "utmpdump"; 
			process.StartInfo.Arguments = filename;
			process.Start();
			// Do not wait for the child process to exit before
			// reading to the end of its redirected stream.
			// p.WaitForExit();
			// Read the output stream first and then wait.
			string output = process.StandardOutput.ReadToEnd();
			
			process.WaitForExit();

			string[] result = output.Split('\n');
			return result;
		}
	}
}
