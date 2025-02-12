using Microsoft.AspNetCore.Mvc;

namespace BankManagment.API.Controllers {

    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase {
        [HttpGet]
        public IActionResult GetUsers() {

            return Ok(new { message = "Users retrieved succesfully" });
        }
    }


}