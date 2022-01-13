using NUnit.Framework;
using System.Linq;

namespace ShadowzBurns.Last.Tests
{
	public class LastDumpTest
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void ReadContent()
		{
			var records = Last.Dump.Get().ToList();

			if (records.Count > 2)
				Assert.Pass();
			else
				Assert.Fail();
		}
	}
}