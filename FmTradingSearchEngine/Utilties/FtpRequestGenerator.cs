using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace FmTradingSearchEngine
{
	public class FtpRequestGenerator
	{
		private readonly WebClient _request;

		public FtpRequestGenerator()
		{
			_request = new WebClient();
		}
		public IEnumerable<string> Fo()
		{
			IEnumerable<string> lines = new List<string>();
			try 
			{
				var url = "http://mendish.com/fmtrading.net/wp-content/plugins/fm-search-diamonds/data/FmStock.csv";
				_request.Credentials = new NetworkCredential("itzFoz@fmtrading.net", "mqsZV%FQPw4Z");
				byte[] newFileData = _request.DownloadData(url);
				var fileString = System.Text.Encoding.UTF8.GetString(newFileData);
				lines = fileString.Split(new string[] { "\r\n", "\n" },
									  StringSplitOptions.RemoveEmptyEntries).Skip(1);
			}
			catch (WebException ex)
			{

				throw new Exception(ex.Message);
			}
			return lines;
		}
	}
}