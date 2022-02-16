using Microsoft.AspNetCore.Mvc;
using _4Shapes.Models;
using _4Shapes.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace _4Shapes.Controllers
{
    public class ShapesController : Controller
    {
        private readonly IDBService _dbSvc;
        private readonly IWebHostEnvironment _env;

        public ShapesController(IDBService dbService,
                              IWebHostEnvironment env)
        {
            _dbSvc = dbService;
            _env = env;
        }
      [Authorize]
        // GET: ShapesController
        public ActionResult Index()
        {
            List<Shapes> lstShapes = _dbSvc.GetList<Shapes>("SELECT * FROM Shapes");
            return View(lstShapes);
            
        }
        [Authorize]
        public ActionResult Live()
        {
     
            return View();

        }
      
    }
}
