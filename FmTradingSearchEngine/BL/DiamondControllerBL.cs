using System.Collections.Generic;
using FmTradingSearchEngine.Utilties;
using FmTradingSearchEngine.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;

namespace FmTradingSearchEngine.BL
{
    public class DiamondControllerBL
    {
        #region Field

        private readonly FtpRequestGenerator _ftpRequestGenerator;
        private readonly List<Diamond> _diamonds;
        private JArray _parsedJson;
        private FileHandler _file;

        #endregion

        #region Ctor

        public DiamondControllerBL()
        {
            _ftpRequestGenerator = new FtpRequestGenerator();
            _file = new FileHandler();
            _diamonds = new List<Diamond>();
            _parsedJson = new JArray();
        }
        #endregion

        public List<Diamond> ConvertCsvFileToList()
        {
            var lines = _ftpRequestGenerator.Fo();
            try
            {
                foreach (var line in lines)
                {
                    var values = line.Split(',');

                    _diamonds.Add(new Diamond()
                    {
                        Id = values[0],
                        Lab = values[1],
                        Shape = values[2],
                        Weight = values[3],
                        Color = values[4],
                        Clarity = values[5],
                        Cut = values[6],
                        Polish = values[7],
                        Symmetry = values[8],
                        Depth = values[9],
                        Table = values[10],
                        Measurements = values[11],
                        Fluorescence = values[12],
                        PriceRapp = values[13],
                        Below = values[14],
                        PricePerCarat = values[15],
                        TotalPrice = values[16],
                        availability = values[17],
                        PictureUrl = values[18],
                        ParceUrl = values[19],
                        CertificateUrl = values[20]
                    });
                }
            }
            catch (Exception)
            {

                throw new Exception("but me");
            }

            return _diamonds;
        }

        public JArray ParseDiamondListToJson()
        {

            var diamondInJsonFormat = string.Empty;
            diamondInJsonFormat = JsonConvert.SerializeObject(_diamonds);
            _parsedJson = JArray.Parse(diamondInJsonFormat);
            return _parsedJson;
        }

        //private double ParsedWeigth(string values)
        //{
        //    double number;

        //    if (Double.TryParse(values, out number))
        //    {
        //        return number;
        //    }
        //    else
        //    {
        //        throw new Exception();
        //    }
        //}
    }
}