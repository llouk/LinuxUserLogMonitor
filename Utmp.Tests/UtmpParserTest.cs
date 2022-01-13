using NUnit.Framework;
using System.IO;

namespace Utmp.Tests
{
	public class UtmpParserTest
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void FileLoad()
		{
			var fileLines = File.ReadAllLines("UtmpDumpTemplate.txt");

			var utmpParser = new Utmp.Parser();
			var data = utmpParser.Parse(fileLines);

			if (data.Count > 0)
				Assert.Pass();

			Assert.Fail();
		}
	}
}