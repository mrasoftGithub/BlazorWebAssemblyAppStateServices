using BlazorBlogProject.Server.Data;
using BlazorBlogProject.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBlogProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceDBController : ControllerBase
    {
        private readonly DbContextClass _dbContextClass;
        public ServiceDBController(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        [HttpGet]
        [Route("GetLijstEigenaren")]
        public ActionResult<List<EIGENAAR>> GetLijstEigenaren()
        {
            return Ok(_dbContextClass.EIGENAAR);
        }

        [HttpGet]
        [Route("GetTotaalAantalEigenaren")]
        public ActionResult<int> GetTotaalAantalEigenaren()
        {
            return Ok(_dbContextClass.EIGENAAR.Count());
        }

        [HttpPost]
        public async Task<EIGENAAR> VoegToe(EIGENAAR eigenaar)
        {
            _dbContextClass.Add(eigenaar);
            await _dbContextClass.SaveChangesAsync();
            return eigenaar;
        }
    }
}
