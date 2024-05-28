using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab5_Lab6.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private static List<Compounding> list = new List<Compounding>();

        [HttpPost]
        public ActionResult<string> GetCompounding(int sothang, long sotien, double tylelai)
        {
            if (tylelai < 0 || sotien < 0 || sothang < 0)
            {
                return Ok("Các Value không thể âm");
            }
            else if (tylelai > 0 && sotien > 0 && sothang > 0)
            {
                var lai = sotien * Math.Pow(1 + tylelai / 100, sothang) - sotien;
                var compounding = new Compounding(){ sothang = sothang, sotien = sotien, tylelai = tylelai , lai = Math.Round(lai)};
                list.Add(compounding);
                return Ok($"Số tiền lãi kép sau {sothang} tháng là : {Math.Round(lai , 2)}");
            }
            else
            {
                return NotFound("Lỗi");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Compounding>> GetCompounding()
        {
            return Ok(list);
        }
    }
    public class Compounding
    {
        public int sothang { get; set; }
        public long sotien { get; set; }
        public double tylelai { get; set; }
        public double lai { get; set; }
    }
}

