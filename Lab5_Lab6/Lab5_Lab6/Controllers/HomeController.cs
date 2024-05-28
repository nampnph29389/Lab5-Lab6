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

        //Bai 4
        [Route("Bai-4[controller]")]
        
            [HttpPost]
            public ActionResult<double> CalculateArea(double a, double b, double c)
            {
          
                if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a)
                {
                    return BadRequest("Các cạnh không hợp lệ");
                }

                double s = (a + b + c) / 2;
                double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

                return Ok($"Diện tích là : {Math.Round(area, 2)}");
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

