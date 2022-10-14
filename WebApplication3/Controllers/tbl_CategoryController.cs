using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class tbl_CategoryController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/tbl_Category
        public IQueryable<tbl_Category> Gettbl_Category()
        {
            return db.tbl_Category;
        }

        // GET: api/tbl_Category/5
        [ResponseType(typeof(tbl_Category))]
        public async Task<IHttpActionResult> Gettbl_Category(int id)
        {
            tbl_Category tbl_Category = await db.tbl_Category.FindAsync(id);
            if (tbl_Category == null)
            {
                return NotFound();
            }

            return Ok(tbl_Category);
        }

        // PUT: api/tbl_Category/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttbl_Category(int id, tbl_Category tbl_Category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Category.CatID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Category).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_CategoryExists(id))
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

        // POST: api/tbl_Category
        [ResponseType(typeof(tbl_Category))]
        public async Task<IHttpActionResult> Posttbl_Category(tbl_Category tbl_Category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Category.Add(tbl_Category);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Category.CatID }, tbl_Category);
        }

        // DELETE: api/tbl_Category/5
        [ResponseType(typeof(tbl_Category))]
        public async Task<IHttpActionResult> Deletetbl_Category(int id)
        {
            tbl_Category tbl_Category = await db.tbl_Category.FindAsync(id);
            if (tbl_Category == null)
            {
                return NotFound();
            }

            db.tbl_Category.Remove(tbl_Category);
            await db.SaveChangesAsync();

            return Ok(tbl_Category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_CategoryExists(int id)
        {
            return db.tbl_Category.Count(e => e.CatID == id) > 0;
        }
    }
}