﻿using System;
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
using ThinkLogic;

namespace APISparta.Controllers
{
    public class SkillsController : ApiController
    {
        private dbSpartaEntities db = new dbSpartaEntities();

        // GET: api/Skills
        public IQueryable<Skill> GetSkills()
        {
            return db.Skills;
        }

        // GET: api/Skills/5
        [ResponseType(typeof(Skill))]
        public async Task<IHttpActionResult> GetSkill(int id)
        {
            Skill skill = await db.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }

        // PUT: api/Skills/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSkill(int id, Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skill.SkillId)
            {
                return BadRequest();
            }

            db.Entry(skill).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
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

        // POST: api/Skills
        [ResponseType(typeof(Skill))]
        public async Task<IHttpActionResult> PostSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Skills.Add(skill);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SkillExists(skill.SkillId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = skill.SkillId }, skill);
        }

        // DELETE: api/Skills/5
        [ResponseType(typeof(Skill))]
        public async Task<IHttpActionResult> DeleteSkill(int id)
        {
            Skill skill = await db.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            db.Skills.Remove(skill);
            await db.SaveChangesAsync();

            return Ok(skill);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkillExists(int id)
        {
            return db.Skills.Count(e => e.SkillId == id) > 0;
        }
    }
}