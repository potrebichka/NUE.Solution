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
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System;
using Twilio.Rest.Lookups.V1;
using PhoneNumbers;

namespace WebApp2.Controllers
{
  public class ReservationsController : Controller
  {
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public ReservationsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,ApplicationDbContext db)
    {
        _userManager = userManager;
        _signInManager = signInManager;
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
    public async Task<ActionResult> Create(Reservation reservation, int EventId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      reservation.Event = _db.Events.FirstOrDefault(ev => ev.EventId == EventId);
      reservation.User = currentUser;
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
      var thisReservation = _db.Reservations.Include(reservation => reservation.Event).FirstOrDefault(reservation => reservation.ReservationId == id);
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
      var thisReservation = _db.Reservations.Include(reservation => reservation.Event).FirstOrDefault(reservation => reservation.ReservationId == id);
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

    public ActionResult SendMessage(int id)
    {
      ViewBag.ReservationId = id;
      ViewBag.Message = "";
      return View();
    }
    [HttpPost, ActionName("SendMessage")]
    [ValidateAntiForgeryToken]
    public ActionResult SendMessage( [Bind("ReservationId, AreaCode, PhoneNumberRaw")] PhoneNumberCheckViewModel phone)
    { 
      if (ModelState.IsValid)
      {
        PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();    
        try    
        {   
          string telephoneNumber = phone.PhoneNumberRaw;
          string countryCode = phone.AreaCode;
          PhoneNumbers.PhoneNumber phoneNumber = phoneUtil.Parse("+" + countryCode + telephoneNumber, "");    

          bool isValidNumber = phoneUtil.IsValidNumber(phoneNumber); // returns true for valid number    
          if (isValidNumber)
          {
            var accountSid = EnvironmentVariables.TWILIO_ACCOUNT_SID;
            var authToken = EnvironmentVariables.TWILIO_AUTH_TOKEN;

            TwilioClient.Init(accountSid, authToken);

            Reservation reservation = _db.Reservations.Include(res => res.Event).FirstOrDefault(res => res.ReservationId == Int32.Parse(phone.ReservationId));

            string textMessage = $"Your reservation at {reservation.Event.EventTitle} is confirmed!";

            var message = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber(EnvironmentVariables.TWILIO_NUMBER),
                body: textMessage,
                to: new Twilio.Types.PhoneNumber(phone.PhoneNumberRaw)
            );
            return RedirectToAction("Details", new {id = phone.ReservationId});
          }
          ViewBag.Message = "The phone number do not exist.";
        }    
        catch (NumberParseException ex)    
        {    
            String errorMessage = "NumberParseException was thrown: " + ex.Message.ToString();  
        }        
      }
      ViewBag.ReservationId = phone.ReservationId;
      return View(phone);
    }
  }
}