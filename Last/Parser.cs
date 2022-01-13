using System.Collections.Generic;
using System.Linq;

namespace Last
{
	public class Parser
	{
		/// <summary>
		/// Parses the plain text data of the last command output
		/// </summary>
		/// <param name="input">Plain text output of last command</param>
		/// <returns>Returns a List of LastEntry records</returns>
		public List<LastEntry> Parse(string input)
		{
			var result = new List<LastEntry>();

			var formattedText = "";
			foreach (var element in input.ToCharArray())
			{
				if (formattedText.Length == 0 
					|| formattedText[formattedText.Length - 1] != element 
					|| element != ' ')
					formattedText = $"{formattedText}{element}";
			}

			foreach (var line in formattedText.Split('\n'))
			{
				if (string.IsNullOrWhiteSpace(line))
					break;

				var entry = new LastEntry();
				var lineToStringList = line.Split(" ").ToList();

				entry.Username = lineToStringList.First();
				lineToStringList.Remove(entry.Username);

				entry.Terminal = lineToStringList.First();
				lineToStringList.Remove(entry.Terminal);

				if (entry.Username == "reboot" && 
					entry.Terminal == "system" && 
					lineToStringList.First() == "boot")
				{
					entry.Terminal = $"{entry.Terminal} {lineToStringList.First()}";
					lineToStringList.Remove(lineToStringList.First());
				}

				entry.Source = lineToStringList.First();
				lineToStringList.Remove(entry.Source);

				entry.DateRange = string.Join(' ', lineToStringList);

				entry.SetDetails();
				result.Add(entry);
			}

			return result;
		}
	}
}
