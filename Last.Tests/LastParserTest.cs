using NUnit.Framework;
using System.IO;

namespace Last.Tests
{
	public class LastParserTest
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void FileLoad()
		{
			var fileLines = File.ReadAllText("LastTemplate.txt");

			var lastParser = new Last.Parser();
			var data = lastParser.Parse(fileLines);

			if (data.Count > 0)
				Assert.Pass();

			Assert.Fail();
		}
	}
}