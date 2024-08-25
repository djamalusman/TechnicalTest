using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        GeneralOutputModel output = new GeneralOutputModel();
        public AuthController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpPost]
        [Route("loginUser")]
        public IActionResult Login([FromBody] LoginModel pr)
        {
           
            try
            {

                GeneralOutputModel retrn = _dataAccessProvider.loginUser(pr);

                if (retrn.Status == "OK")
                {
                    return Ok(retrn);
                }
                return BadRequest(retrn);
            }
            catch (Exception ex)
            {
                output.Status = "NG";
                output.Message = ex.ToString();

                return BadRequest(output);
            }

            // Generate a token here or any other logic as needed
            // For simplicity, returning a dummy token
            //var token = "dummy-token"; // Replace with your token generation logic

            //return Ok(new { Token = token });
        }
    }
}
