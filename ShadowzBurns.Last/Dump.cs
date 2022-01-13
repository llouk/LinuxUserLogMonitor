using System.Collections.Generic;
using System.Diagnostics;

namespace ShadowzBurns.Last
{
	public static class Dump
	{
		/// <summary>
		/// Runs last and retrieves all records
		/// </summary>
		/// <returns>All the lines as an IEnumerable of strings</returns>
		public static IEnumerable<string> Get(string arguments = "-F")
		{
			var process = new Process();
			// Redirect the output stream of the child process.
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.FileName = "last";
			process.StartInfo.Arguments = arguments;
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
