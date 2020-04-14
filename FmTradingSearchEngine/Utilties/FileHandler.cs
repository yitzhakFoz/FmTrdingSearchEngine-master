using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace FmTradingSearchEngine.Utilties
{
	public class FileHandler
	{
		public IEnumerable<string> ReadStockFile()
		{
			IEnumerable<string> lines = File.ReadAllLines
				(@"C:\Users\Yitzhak\Desktop\SampleFiles\Fm new WEBSITE_2019-10-24 16-55-06.csv")
				.Skip(1);
			return lines;
		}
	}
}