using System.Collections.Generic;
using System.Text.Json;

namespace ShadowzBurns.Last
{
	public class Converter
	{
		/// <summary>
		/// Serialize the data to json format
		/// </summary>
		/// <param name="data">List of LastEntry objects</param>
		/// <returns>Returns the json representation of tha data supplied</returns>
		public string ToJson(List<LastEntry> data)
		{
			string dataAsText = JsonSerializer.Serialize(data);
			return dataAsText;
		}
	}
}
