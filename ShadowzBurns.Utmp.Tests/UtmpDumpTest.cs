using NUnit.Framework;
using System.Linq;

namespace ShadowzBurns.Utmp.Tests
{
	public class UtmpDumpTest
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void ReadContent()
		{
			var records = Utmp.Dump.Get().ToList();

			if (records.Count > 2)
				Assert.Pass();
			else
				Assert.Fail();
		}
	}
}