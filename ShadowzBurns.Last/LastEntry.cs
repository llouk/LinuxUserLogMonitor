using System;
using System.Globalization;
using System.Linq;

namespace ShadowzBurns.Last
{
	public class LastEntry
	{
		public string Username { get; set; }
		public string Terminal { get; set; }
		public string Source { get; set; }
		public string DateRange { get; set; }

		public DateTime DateFrom { get; private set; }
		public DateTime? DateTo { get; private set; }

		public string Detail { get; private set; }

		public void SetDetails()
		{
			SetDateFrom();
			SetDateTo();
		}

		private void SetDateFrom()
		{
			var list = DateRange.Split(" ").ToList();
			list.Remove(list.First());
			//list.RemoveRange(list.Count - 3, 3);
			list.RemoveRange(4, list.Count - 4);
			var s = string.Join(' ', list);
			DateTime.TryParseExact(s, "MMM d HH:mm:ss yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out var dt);

			DateFrom = dt;
		}

		private void SetDateTo()
		{
			var list = DateRange.Split("-").ToList();

			if (DateRange.Contains("still logged in"))
			{
				Detail = "still logged in";
				DateTo = null;
				return;
			}
			if (DateRange.Contains("still running"))
			{
				Detail = "still running";
				DateTo = null;
				return;

			}
			if (DateRange.Contains("gone - no logout"))
			{
				Detail = "gone - no logout";
				DateTo = null;
				return;
			}
			if (DateRange.Contains("crash"))
			{
				Detail = "crash";
				DateTo = null;
				return;
			}

			list.Remove(list.First());
			var endDateAsText = list.First();
			var endDateAsList = endDateAsText.Split(' ').Where(i => !string.IsNullOrWhiteSpace(i)).ToList();
			endDateAsList.Remove(endDateAsList.First());
			endDateAsList.Remove(endDateAsList.Last());
			var s = string.Join(' ', endDateAsList);
			DateTime.TryParseExact(s, "MMM d HH:mm:ss yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out var dt);

			DateTo = dt;
		}
	}
}
