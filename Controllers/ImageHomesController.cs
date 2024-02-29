using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeTravelAPI.EF;
using HomeTravelAPI.Entities;
using HomeTravelAPI.ViewModels;
using HomeTravelAPI.Common;
using Microsoft.Extensions.Hosting;
using Firebase.Auth;
using NuGet.Packaging;

namespace HomeTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageHomesController : ControllerBase
    {
        private readonly HomeTravelDbContext _context;
        private readonly IHostEnvironment _environment;

        public ImageHomesController(HomeTravelDbContext context, IHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private async Task<string> SaveImage(IFormFile file)
        {
            FileStream sm;
            string imageUrl = null;
            if (file.Length > 0)
            {
                string path = Path.Combine(_environment.ContentRootPath, $"images", file.FileName);
                using (sm = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(sm);
                }
                sm = System.IO.File.Open(path, FileMode.Open);
                imageUrl = await UploadFile.Upload(sm, file.FileName);

            }
            return imageUrl;
        }


        [HttpPost]
        public async Task<ActionResult> CreateImageHome(int homeStayId,List<IFormFile> files)
        {
            List<ImageHome> list = new List<ImageHome>();
            foreach(IFormFile file in files) 
            {
               var imageUrl = await SaveImage(file);
               var img = new ImageHome
                {
                    ImageURL = imageUrl,
                    HomeStayId = homeStayId
                };
                list.Add(img);
            }
            await _context.ImageHomes.AddRangeAsync(list);
            await _context.SaveChangesAsync();
            return Ok(new APIResult(Status: 200, Message: "Success"));
        }

        [HttpPut("UpdateImage/{id}")]
        public async Task<ActionResult> UpdateImageHome(int id, List<IFormFile> files)
        {
            List<ImageHome> list = new List<ImageHome>();
            var homestay = await _context.HomeStays.Include(x => x.ImageHomes).FirstOrDefaultAsync(x => x.HomeStayId == id);
            if(homestay == null)
            {
                return BadRequest("Not Found");
            }
            foreach (IFormFile file in files)
            {
                var imageUrl = await SaveImage(file);
                var img = new ImageHome
                {
                    ImageURL = imageUrl,
                };
                list.Add(img);
            }
            var images = homestay.ImageHomes;
            if(images.Count > 0)
            {
                homestay.ImageHomes.Clear();
                homestay.ImageHomes.AddRange(list);
            }
            await _context.SaveChangesAsync();
            return Ok(new APIResult(Status: 200, Message: "Success"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageHome(int id)
        {
            var imageHome = await _context.ImageHomes.FindAsync(id);
            if (imageHome == null)
            {
                return NotFound();
            }

            _context.ImageHomes.Remove(imageHome);
            await _context.SaveChangesAsync();

            return Ok(new APIResult(Status: 200, Message: "Success"));
        }

        private bool ImageHomeExists(int id)
        {
            return _context.ImageHomes.Any(e => e.ImageHomeId == id);
        }
    }
}
