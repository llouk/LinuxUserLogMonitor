using System.Collections.Generic;
using System.Text.Json;

namespace ShadowzBurns.Utmp
{
	public class Converter
	{
		/// <summary>
		/// Serialize the data to json format
		/// </summary>
		/// <param name="data">List of UtmpEntry objects</param>
		/// <returns>Returns the json representation of tha data supplied</returns>
		public string ToJson(List<UtmpEntry> data)
		{
			string dataAsText = JsonSerializer.Serialize(data);
			return dataAsText;
		}
	}
}
