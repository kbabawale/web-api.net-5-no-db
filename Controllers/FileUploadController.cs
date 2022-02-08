using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npoi.Mapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace halogen.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    public class FileUploadController : Controller
    {

        public IHostingEnvironment hostingEnvironment;

        public FileUploadController(IHostingEnvironment hostingEnv)
        {
            hostingEnvironment = hostingEnv;
        }

        [HttpGet]
        [Route("upload")]
        public ActionResult Get()
        {
            return Ok("Web API working");
        }

            [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> OnPostUploadAsync(IFormFile file)
        {
            
            var filePath = Path.GetTempFileName();

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            var mapper = new Mapper(filePath);
            var objs1 = mapper.Take<ExcelClass>("sheet1");

            if (objs1.Count() > 1)
            {
                return BadRequest("Only one row permitted");
            }
            else
            {
                var first = objs1.First().Value;
                List<int> values = new List<int>();
                values.Add(first.A);
                values.Add(first.B);
                values.Add(first.C);
                values.Add(first.D);
                values.Add(first.E);
                values.Add(first.F);
                values.Add(first.G);
                values.Add(first.H);
                values.Add(first.I);
                values.Add(first.J);

                //get even numbers
                List<int> evenNumbers = ExcelMethodClass.getEvenNumbers(values);
                List<int> oddNumbers = ExcelMethodClass.getOddNumbers(values);
                List<int> numbersDivisibleBy3 = ExcelMethodClass.getNumbersDivisibleBy3(values);
                List<int> numbersDivisibleBy5 = ExcelMethodClass.getNumbersDivisibleBy5(values);
                List<int> numbersDivisibleBy7 = ExcelMethodClass.getNumbersDivisibleBy7(values);
                int mode = ExcelMethodClass.findMode(values);
                double mean = values.Average();

                List<decimal> doubles = values.Select<int, decimal>(i => i).ToList();
                decimal median = ExcelMethodClass.findMedian(doubles);
                int sum = values.Sum();

                ResponseClass res = new ResponseClass();
                res.evenNumbers = evenNumbers;
                res.oddNumbers = oddNumbers;
                res.numbersDivisibleBy3 = numbersDivisibleBy3;
                res.numbersDivisibleBy5 = numbersDivisibleBy5;
                res.numbersDivisibleBy7 = numbersDivisibleBy7;
                res.mode = mode;
                res.mean = mean;
                res.median = median;
                res.sum = sum;

                return Ok(res);
            }

            //return Ok(new { count = filePath });
        }

        

            
        
    }
}