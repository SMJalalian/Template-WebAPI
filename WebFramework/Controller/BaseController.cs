using Microsoft.AspNetCore.Mvc;

namespace MyProject.WebFramework.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/{Culture}/[controller]")]
    public class BaseController : ControllerBase
    {

    }
}
