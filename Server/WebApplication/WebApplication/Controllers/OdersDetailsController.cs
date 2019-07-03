using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OdersDetailsController : ApiController
    {
        private WebApplicationContext db = new WebApplicationContext();

        // GET: api/OdersDetails
        public IQueryable<OdersDetail> GetOdersDetails()
        {
            return db.OdersDetails;
        }

        // GET: api/OdersDetails/5
        [ResponseType(typeof(OdersDetail))]
        public IHttpActionResult GetOdersDetail(int id)
        {
            OdersDetail odersDetail = db.OdersDetails.Find(id);
            if (odersDetail == null)
            {
                return NotFound();
            }

            return Ok(odersDetail);
        }

        // PUT: api/OdersDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOdersDetail(int id, OdersDetail odersDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != odersDetail.id_order)
            {
                return BadRequest();
            }

            db.Entry(odersDetail).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OdersDetailExists(id))
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

        // POST: api/OdersDetails
        [ResponseType(typeof(OdersDetail))]
        public IHttpActionResult PostOdersDetail(OdersDetail odersDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OdersDetails.Add(odersDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OdersDetailExists(odersDetail.id_order))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = odersDetail.id_order }, odersDetail);
        }

        // DELETE: api/OdersDetails/5
        [ResponseType(typeof(OdersDetail))]
        public IHttpActionResult DeleteOdersDetail(int id)
        {
            OdersDetail odersDetail = db.OdersDetails.Find(id);
            if (odersDetail == null)
            {
                return NotFound();
            }

            db.OdersDetails.Remove(odersDetail);
            db.SaveChanges();

            return Ok(odersDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OdersDetailExists(int id)
        {
            return db.OdersDetails.Count(e => e.id_order == id) > 0;
        }
    }
}