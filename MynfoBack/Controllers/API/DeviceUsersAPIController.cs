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
using MynfoBack.Models;

namespace MynfoBack.Controllers.API
{
    public class DeviceUsersAPIController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/DeviceUsersAPI
        public IQueryable<DeviceUser> GetDeviceUsers()
        {
            return db.DeviceUsers;
        }

        // GET: api/DeviceUsersAPI/5
        [ResponseType(typeof(DeviceUser))]
        public IHttpActionResult GetDeviceUser(int id)
        {
            DeviceUser deviceUser = db.DeviceUsers.Find(id);
            return Ok(deviceUser);
        }

        // GET: api/DeviceUsersAPI/cyn/1234
        [ResponseType(typeof(DeviceUser))]
        public IHttpActionResult GetDeviceUser(string id, string param2)
        {
            var deviceUser = db.DeviceUsers.ToList()
                                            .Where(u => u.NickName.ToUpper() == id.ToUpper() 
                                            && u.Password == param2)
                                            .FirstOrDefault();
            return Ok(deviceUser);
        }

        // PUT: api/DeviceUsersAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeviceUser(int id, DeviceUser deviceUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deviceUser.DeviceUserID)
            {
                return BadRequest();
            }

            db.Entry(deviceUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceUserExists(id))
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

        // POST: api/DeviceUsersAPI
        [ResponseType(typeof(DeviceUser))]
        public IHttpActionResult PostDeviceUser(DeviceUser deviceUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeviceUsers.Add(deviceUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = deviceUser.DeviceUserID }, deviceUser);
        }

        // DELETE: api/DeviceUsersAPI/5
        [ResponseType(typeof(DeviceUser))]
        public IHttpActionResult DeleteDeviceUser(int id)
        {
            DeviceUser deviceUser = db.DeviceUsers.Find(id);
            if (deviceUser == null)
            {
                return NotFound();
            }

            db.DeviceUsers.Remove(deviceUser);
            db.SaveChanges();

            return Ok(deviceUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeviceUserExists(int id)
        {
            return db.DeviceUsers.Count(e => e.DeviceUserID == id) > 0;
        }
    }
}