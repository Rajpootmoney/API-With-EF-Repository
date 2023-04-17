using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practice_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        //[Route("[action]")]
        [HttpGet]
        public string PrintName()
        {
            return "test";
        }
        //[Route("GetDescription")]
        [HttpGet]
        public string GetDescription()
        {
            return "Description";
        }
    }
}
