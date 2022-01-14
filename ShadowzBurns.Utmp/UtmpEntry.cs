using System;
using System.Collections.Generic;
using System.Linq;

namespace ShadowzBurns.Utmp
{
	public class UtmpEntry
	{
		public int LineType { get; set; }
		public string ProcessId { get; set; }
		public string Interface { get; set; }
		public string Username { get; set; }
		public string Terminal { get; set; }
		public string Source { get; set; }
		public string RemoteIp { get; set; }
		public DateTime RecordDate { get; set; }

		/// <summary>
		/// Generates a UtmpEntry by providing values
		/// </summary>
		/// <param name="lineType"></param>
		/// <param name="processId"></param>
		/// <param name="iface"></param>
		/// <param name="username"></param>
		/// <param name="terminal"></param>
		/// <param name="source"></param>
		/// <param name="remoteIp"></param>
		/// <param name="recordDate"></param>
		public UtmpEntry(int lineType, string processId, string iface, string username, string terminal, string source, string remoteIp, DateTime recordDate)
		{
			LineType = lineType;
			ProcessId = processId;
			Interface = iface;
			Username = username;
			Terminal = terminal;
			Source = source;
			RemoteIp = remoteIp;
			RecordDate = recordDate;
		}

		/// <summary>
		/// Generates a UtmpEntry object by a list of values.
		/// </summary>
		/// <param name="items">List must be ordered as LineType, ProcessId, Interface, Username, Terminal, Source, RemoteIp, RecordDate</param>
		public UtmpEntry(IList<string> items)
		{
			if (items.Count != 8)
				throw new Exception($"Required 8 values, {items.Count} given");

			LineType = Convert.ToInt32(items[0]);
			ProcessId = items[1].Trim();
			Interface = items[2].Trim();
			Username = items[3].Trim();
			Terminal = items[4].Trim();
			Source = items[5].Trim();
			RemoteIp = items[6].Trim();
			RecordDate = DateTime.Parse(items[7].Split(',').First());
		}
	}
}
