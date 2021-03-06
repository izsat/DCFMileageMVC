﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DCFMileage.DAL;
using DCFMileage.Models;

namespace DCFMileage.Controllers.Api
{
    public class TripsController : ApiController
    {
        private TripDbContext db = new TripDbContext();

        // GET: api/Trips

        public IQueryable<Trip> GetTrips()
        {
            return db.Trips;
        }

        // GET: api/Trips/5
        [ResponseType(typeof(Trip))]
        public IHttpActionResult GetTrip(int id)
        {
            var trips = from trip in db.Trips
                        where trip.Employee.EmployeeID == id
                        select trip;

            List<TripApiModel> tripList = new List<TripApiModel>();
            foreach(var trip in trips)
            {
                TripApiModel newTrip = new TripApiModel();
                newTrip.Id = trip.Id;
                newTrip.StartMileage = trip.StartMileage;
                newTrip.EndMileage = trip.EndMileage;
                newTrip.EmployeeId = trip.Employee.EmployeeID;
                newTrip.Purpose = trip.Purpose;
                newTrip.StartLocation = trip.StartLocation;
                newTrip.EndLocation = trip.EndLocation;
                tripList.Add(newTrip);
            }

            IEnumerable<TripApiModel> tripJson = tripList;

            return Ok(tripJson);
        }

        // PUT: api/Trips/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrip(int id, Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trip.Id)
            {
                return BadRequest();
            }

            db.Entry(trip).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Trips
        [ResponseType(typeof(Trip))]
        public IHttpActionResult PostTrip(Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trips.Add(trip);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trip.Id }, trip);
        }

        // DELETE: api/Trips/5
        [ResponseType(typeof(Trip))]
        public IHttpActionResult DeleteTrip(int id)
        {
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return NotFound();
            }

            db.Trips.Remove(trip);
            db.SaveChanges();

            return Ok(trip);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TripExists(int id)
        {
            return db.Trips.Count(e => e.Id == id) > 0;
        }
    }
}