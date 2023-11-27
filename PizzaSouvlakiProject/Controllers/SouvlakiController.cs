using Pizza.ReadModels;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using PizzaSouvlakiProject.ReadModels;
using PizzaSouvlakiProject.Services;

namespace allSouvlakia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SouvlakiController : ControllerBase
    {
        private readonly ILogger<SouvlakiController> _logger;
        
        static private List<SouvlakiModel> allSouvlakia = new List<SouvlakiModel>();

        public SouvlakiController(ILogger<SouvlakiController> logger)
        {
            _logger = logger;
        }

        ///<summary>
        //We use this method to get every souvlaki from the database.
        ///</summary>
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(IEnumerable<SouvlakiModel>), 200)]
        public IEnumerable<SouvlakiModel> Search()
        {
            allSouvlakia = new SouvlakiServices().GetEverySouvlaki();
            return allSouvlakia;
        }


        ///<summary>
        //We use this method to get a souvlaki from the database with a specific id.
        ///</summary>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(SouvlakiModel),200)]
        public ActionResult<SouvlakiModel> Find(string id)
        {
            var oneSouvlaki = allSouvlakia.SingleOrDefault(f => f.Id == id);

            if (oneSouvlaki == null)
                return NotFound();

            return Ok(oneSouvlaki);
        }
         
    }
}