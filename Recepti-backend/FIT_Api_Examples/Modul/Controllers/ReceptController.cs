using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Recepti.Data;
using Recepti.Helper;
using Recepti.Modul1.Models;
using Recepti.Modul1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Recepti.Modul1.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReceptController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ReceptController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public Recept Get(int id)
        {
            return _dbContext.Recipes.Find(id);
        }

        [HttpPost]
        public Recept Add([FromBody] ReceptAddVM x)
        {
            var newRecept = new Recept
            {
                naziv = x.naziv,
                opis = x.opis.RemoveTags(),
                sastojci = x.sastojci,
                image = Config.SlikeURL + "empty.png",
                created_time = DateTime.Now
            };

            _dbContext.Add(newRecept);
            _dbContext.SaveChanges();
            return newRecept;
        }
     

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] ReceptUpdateVM x)
        {
            Recept recept = _dbContext.Recipes.Find(id);

            if (recept == null)
                return BadRequest("pogresan ID");

            recept.naziv = x.naziv.RemoveTags();
            recept.opis= x.opis;
            recept.sastojci = x.sastojci;

            _dbContext.SaveChanges();
            return Ok(recept);
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            if (_dbContext.Recipes.Count() < 10)
                return BadRequest("Ne moze se obrisati ako je broj zapisa manji od 100");
          
            Recept recept = _dbContext.Recipes.Find(id);
            
            if (recept == null || id == 1 )
                return BadRequest("Pogresan ID");

            _dbContext.Remove(recept);

            _dbContext.SaveChanges();
            return Ok(recept);
        }
       
        [HttpGet]
        

        [HttpGet]
        public List<ReceptiGetAllVM> GetAll(string name)
        {
            var data = _dbContext.Recipes.Where(x => name == null || x.naziv.StartsWith(name)).OrderByDescending(s => s.id)
                .Select(s => new ReceptiGetAllVM
                {
                    id = s.id,
                    naziv = s.naziv,
                    opis = s.opis,
                    sastojci = s.sastojci,
                    created_time = s.created_time,
                    image = s.image,
                   

                })
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost("{id}")]
        public Recept AddProfileImage(int id, [FromForm] ReceptImageAddVM x)
        {
            Recept recept = _dbContext.Recipes.Find(id);

            if (x.image != null && recept != null)
            {
                string ekstenzija = Path.GetExtension(x.image.FileName);
                var filename = $"{Guid.NewGuid()}{ekstenzija}";

                x.image.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
               recept.image = Config.SlikeURL + filename;
                _dbContext.SaveChanges();
            }

            return recept;
        }
    }
}
