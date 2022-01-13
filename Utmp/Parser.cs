using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Utmp
{
	public class Parser
	{
		/// <summary>
		/// Transforms plain text lines loaded to a list of data objects
		/// </summary>
		/// <param name="fileLines">Content of the dump of utmp/wtmp file</param>
		/// <returns>A list of UtmpEntry objects</returns>
		public List<UtmpEntry> Parse(IEnumerable<string> fileLines)
		{
			var result = new List<UtmpEntry>();
			foreach (var line in fileLines)
			{
				var items = Regex
								.Matches(line, @"\[.*?\]")
									.Select(i => i.Value
													.TrimStart('[')
													.TrimEnd(']')
													.Trim())
									.ToList();

				if (items.Count == 0)
					continue;

				var entry = new UtmpEntry(items);
				result.Add(entry);
			}

			return result;
		}
	}
}
