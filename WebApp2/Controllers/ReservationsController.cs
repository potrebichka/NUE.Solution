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
    public class ReservationsController : Controller
    {
    private readonly ApplicationDbContext _db;

    public ReservationsController(ApplicationDbContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Reservation> model = _db.Reservations.Include(reservation => reservation.Event).ToList();
      
      return View(model);
    }

    public ActionResult Create()
    {
        ViewBag.EventId = new SelectList(_db.Events, "EventId", "EventTitle");
        return View();
    }

    [HttpPost]
    public ActionResult Create(Reservation reservation)
    {
      reservation.EventTitle = _db.Events.FirstOrDefault(ev => ev.EventId == reservation.EventId).EventTitle;
      _db.Reservations.Add(reservation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
       
        var thisReservation = _db.Reservations
            .Include(reservation => reservation.Event)
            
            .FirstOrDefault(reservation => reservation.ReservationId == id);
        return View(thisReservation);
    }

    public ActionResult Edit(int id)
    {
      ViewBag.EventId = new SelectList(_db.Events, "EventId", "EventTitle");
      var thisReservation = _db.Reservations.FirstOrDefault(reservation => reservation.ReservationId == id);
      return View(thisReservation);
    }

    [HttpPost]
    public ActionResult Edit(Reservation reservation)
    {
      _db.Entry(reservation).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisReservation = _db.Reservations.FirstOrDefault(reservation => reservation.ReservationId == id);
      return View(thisReservation);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisReservation = _db.Reservations.FirstOrDefault(reservation => reservation.ReservationId == id);
      _db.Reservations.Remove(thisReservation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult DeleteAll()
    {
      var allReservations = _db.Reservations.ToList();
      return View();
    }

    [HttpPost, ActionName("DeleteAll")]
    public ActionResult DeleteAllConfirmed()
    {
      var allReservations = _db.Reservations.ToList();

      foreach (var reservation in allReservations)
      {
        _db.Reservations.Remove(reservation);
      }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}