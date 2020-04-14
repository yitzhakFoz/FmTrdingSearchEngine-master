using System;
using System.Web.Http;
using FmTradingSearchEngine.BL;
using FmTradingSearchEngine.Models;
using System.Linq;
using System.Collections.Generic;
using System.IO;


namespace FmTradingSearchEngine.Controllers
{
    public class DiamondController : ApiController
    {

        #region Field 
        private DiamondControllerBL _diamondControllerBL;
        #endregion

        #region Ctor
        public DiamondController()
        {
            _diamondControllerBL = new DiamondControllerBL();
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetDiamondsById([FromUri] List<string> id)
        {
            var res = new List<Diamond>();
            var diamonds = _diamondControllerBL.ConvertCsvFileToList();
            if (id.Count > 0)
            {
                res = (from d in diamonds
                       where id.Contains(d.Id)
                       select new Diamond()
                       {
                           Id = d.Id,
                           Lab = d.Lab,
                           Shape = d.Shape,
                           Weight = d.Weight,
                           Color = d.Color,
                           Cut = d.Cut,
                           Polish = d.Polish,
                           Symmetry = d.Symmetry,
                           Depth = d.Depth,
                           Table = d.Table,
                           Measurements = d.Measurements,
                           Fluorescence = d.Fluorescence,
                           availability = d.availability,
                           PictureUrl = d.PictureUrl,
                           CertificateUrl = d.CertificateUrl,
                           ParceUrl = d.ParceUrl
                       }).ToList();
            }

            if (res.Count > 0)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest("Diamond Id is not found");
            }
        }

        [HttpPost]
        public IHttpActionResult GetDiamondByFilter([FromBody] SearchDiamond diamond)
        {
            try
            {
                var diamonds = _diamondControllerBL.ConvertCsvFileToList();

                var res = new List<Diamond>();

                if (diamond.Clarity.Count > 0)
                {
                    diamonds = diamonds.Where(d => diamond.Clarity.Contains(d.Clarity)).ToList();
                }
                if (diamond.Color.Count > 0)
                {
                    //    foreach (var item in diamond.Color)
                    //    {
                    //        if (item == "N-Z")
                    //        {
                    //            diamonds = from dia in diamonds
                    //        }
                       
                    diamonds = diamonds.Where(d => diamond.Color.Contains(d.Color)).ToList();
                }
                if (diamond.Cut.Count > 0)
                {
                    diamonds = diamonds.Where(d => diamond.Cut.Contains(d.Cut)).ToList();
                }
                if (diamond.Fluorescence.Count > 0)
                {
                    diamonds = diamonds.Where(d => diamond.Fluorescence.Contains(d.Fluorescence)).ToList();
                }
                if (diamond.Grading_Report.Count > 0)
                {
                    diamonds = diamonds.Where(d => diamond.Grading_Report.Contains(d.Lab)).ToList();
                }
                if (diamond.Polish.Count > 0)
                {
                    diamonds = diamonds.Where(d => diamond.Polish.Contains(d.Polish)).ToList();
                }
                if (diamond.Shapes.Count > 0)
                {
                    diamonds = diamonds.Where(d => diamond.Shapes.Contains(d.Shape)).ToList();
                }
                if (diamond.Symmetry.Count > 0)
                {
                    diamonds = diamonds.Where(d => diamond.Symmetry.Contains(d.Symmetry)).ToList();
                }

                if (diamond.Weight.Count > 0)
                {
                    diamonds = ChekWeight(diamond.Weight, diamonds);

                    diamonds = (from dia in diamonds
                                orderby dia.Weight ascending
                                select dia).ToList();
                }

                else
                {
                    diamonds = (from dia in diamonds
                                orderby dia.Weight ascending
                                select dia).ToList();

                    return Ok(diamonds);
                }

                return Ok(diamonds);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        private List<Diamond> ChekWeight(List<string> weights, List<Diamond> diamonds)
        {
            double weight = 0;
            var res = new List<Diamond>();

            foreach (var item in weights)
            {
                var userInput = new List<double>();

                var val = item.Split('-');

                foreach (var v in val)
                {
                    if (double.TryParse(v, out weight))
                    {
                        userInput.Add(weight);
                    }
                    else
                    {

                    }

                }

                double stockWeight = 0;
                foreach (var d in diamonds)
                {
                    if (double.TryParse(d.Weight, out stockWeight))
                    {
                        if (stockWeight >= userInput[0] && stockWeight <= userInput[1])
                        {
                            res.Add(d);
                        }
                    }
                }
            }
            return res;
        }
        //public List<Diamond> GetAll(List<Diamond> diamonds)
        //{

        //    foreach (var item in diamonds)
        //        if (Path.GetExtension(item.PictureUrl) == ".jpg")
        //        {
        //            diamonds.Add(item);
        //            return diamonds;

        //        }
        //    return null;
        //}
    }
}