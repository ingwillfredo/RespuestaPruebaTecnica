using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiBackPruebaTec.Entities.Custom;
using ApiBackPruebaTec.Entities.Models;
using ApiBackPruebaTec.Entities.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using System;

namespace ApiBackPruebaTec.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly DbpruebaTecContext _dbContext;
        private readonly Utilities _utils;
        public AccessController(DbpruebaTecContext dbContext, Utilities utils)
        {
            _dbContext = dbContext;
            _utils = utils;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            Entities.Models.User userExist = new Entities.Models.User();
            userExist.Id = 1;
            userExist.Name = "Willfredo Martinez";
            userExist.Email = "ingwillfredo@gmail.com";
            userExist.Password = "Will0811";

            if (login.Email == "ingwillfredo@gmail.com" && login.Password == "Will0811")
            {

                return StatusCode(StatusCodes.Status200OK, new { isSucces = true, token = _utils.generateJWT(userExist) });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSucces = false, token = "" });
            }
        }


        [HttpGet("TokenValidate")]
        public IActionResult TokenValidate([FromQuery]string token)
        {
            bool respose = _utils.TokenValidate(token);
            return StatusCode(StatusCodes.Status200OK, new { isSucces = respose });
        }
    }
}
