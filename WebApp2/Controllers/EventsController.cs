  
using Microsoft.AspNetCore.Mvc;
using WebApp2.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using WebApp2.Data;

namespace WebApp2.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EventsController (ApplicationDbContext  db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
        List<Event> model = _db.Events.ToList();
        
        return View(model);
        }

        public ActionResult Reserve()
        {
            return View();
        }

        // [HttpPost]
        // public ActionResult Reserve(Event event)
        // {
            
        // }


    }
}