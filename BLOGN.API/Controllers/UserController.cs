using AutoMapper;
using BLOGN.API.Services.IService;
using BLOGN.Data.Repositories.IRepository;
using BLOGN.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLOGN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public UserController(IUserService _userService, IMapper _mapper )
        {
            userService = _userService;
            mapper = _mapper;   
        }

        [HttpPost]
        public IActionResult Authentice(UserDto userDto)
        {
            var user = userService.Authentice(userDto.UserName,userDto.Password);
            if (user == null)
            {
                return BadRequest(new { messsage = "Kullanıcı Adı veya Parola Hatalı" });
            }

            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult Register(UserDto userDto)
        {
            bool userBool = userService.IsUniqueUser(userDto.UserName);
            if (!userBool)
            {
                return BadRequest(new { messsage = "Kullanıcı Adı Zaten Kayıtlı" });
            }

            var user = userService.Register(userDto.UserName,userDto.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Kayıt Esnasında Hata Oluştu" });
            }
            return Ok(user);
        }


    }
}
