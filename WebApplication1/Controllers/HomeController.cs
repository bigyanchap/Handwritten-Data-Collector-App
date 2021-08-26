using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using static WebApplication1.Models.Enums;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IWebHostEnvironment host;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            host = environment;
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("SessionCount","0");
            return View();
        }

        public IActionResult InsertDataPage()
        {
            int SessionCount = Convert.ToInt32(HttpContext.Session.GetString("SessionCount"));
            SessionCount++;
            if (SessionCount <= _class.classList.Count)
            {
                _class _class_ = new _class();
                _class_.classId = SessionCount;
                _class_.Name = _class.classList.Where(x => x.classId == _class_.classId).FirstOrDefault().Name;
                _class_.Description = _class.classList.Where(x => x.classId == _class_.classId).FirstOrDefault().Description;

                HttpContext.Session.SetString("SessionCount", SessionCount.ToString());
                return View(_class_);
            }
            else
            {
                return RedirectToAction("EndPage");
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertData()
        {
            try
            {
                var file = Request.Form.Files[0];
                var classId = Convert.ToInt32(file.Name);
                _class _class_ = new _class();
                _class_.Name = _class.classList.Where(x => x.classId == classId).FirstOrDefault().Name;
                
                string folderName = _class_.Name;
                if (file == null) return BadRequest("No file found");
                string uploadFolderPath = Path.Combine(host.ContentRootPath, "Uploads\\"+folderName+"\\");

                if (!Directory.Exists(uploadFolderPath))
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }


                var fileName = string.Empty;
                if (file != null)
                {
                    
                    fileName = Guid.NewGuid().ToString() + ".png";
                    var filepath = Path.Combine(uploadFolderPath, fileName);
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                   
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
        }
        public IActionResult EndPage()
        {
            HttpContext.Session.Remove("SessionCount");
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
