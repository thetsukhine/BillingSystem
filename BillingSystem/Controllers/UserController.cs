using BillingSystem.DTO;
using BillingSystem.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillingSystem.Controllers
{
    //[Route("api/[controller]")]
    [Route("api")]
    [ApiController]
    //[Area("mm")]
    public class UserController : ControllerBase
    {

        private readonly UserdbContext DBContext;

        //private readonly IBloggerRepository _repository;

        //public BlogController(BloggerRepository repository)
        //{
        //    _repository = repository;
        //}
        public UserController(UserdbContext _DBContext)
        {
            this.DBContext = _DBContext;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var List = await DBContext.Users.Select(
                s => new UserDTO
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Username = s.Username,
                    Password = s.Password,
                    EnrollmentDate = s.EnrollmentDate
                }
            ).ToListAsync();
            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<UserDTO>> GetUserById(int Id)
        {
            UserDTO User = await DBContext.Users.Select(s => new UserDTO
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Username = s.Username,
                Password = s.Password,
                EnrollmentDate = s.EnrollmentDate
            }).FirstOrDefaultAsync(s => s.Id == Id);

            if (User == null)
            {
                return NotFound();
            }
            else
            {
                return User;
            }
        }

        // <summary>
        /// Use the below code to generate symmetric Secret Key
        ///     var hmac = new HMACSHA256();
        ///     var key = Convert.ToBase64String(hmac.Key);
        /// </summary>
        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public static string GenerateToken(string username, int expireMinutes = 20)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, username)
        }),

                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        //[AllowAnonymous]
        //public string Get(string username, string password)
        //{
        //    if (CheckUser(username, password))
        //    {
        //        return JwtManager.GenerateToken(username);
        //    }
        //    throw new HttpResponseException(HttpStatusCode.Unauthorized);
        //}

        [HttpPost("Login")]
        //public async Task<HttpStatusCode> InsertUser(UserDTO User)
        public async Task<string> InsertUser(UserDTO User)
        {
            var entity = new User()
            {
                FirstName = User.FirstName,
                LastName = User.LastName,
                Username = User.Username,
                Password = User.Password,
                EnrollmentDate = User.EnrollmentDate
            };
            DBContext.Users.Add(entity);
            await DBContext.SaveChangesAsync();

            string access_token = GenerateToken(User.Username, 3);
            string status_message = "Login is successful";

            return Newtonsoft.Json.JsonConvert.SerializeObject(new { status_message = status_message, access_token = access_token });

            //return user;
            //throw new httpresp HttpResponseException(HttpStatusCode.Unauthorized);
        }

        // GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UserController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

//public static class UserEndpoints
//{
//	public static void MapUserEndpoints (this IEndpointRouteBuilder routes)
//    {
//        routes.MapGet("/api/User", () =>
//        {
//            return new [] { new User() };
//        })
//        .WithName("GetAllUsers")
//        .Produces<User[]>(StatusCodes.Status200OK);

//        routes.MapGet("/api/User/{id}", (int id) =>
//        {
//            //return new User { ID = id };
//        })
//        .WithName("GetUserById")
//        .Produces<User>(StatusCodes.Status200OK);

//        routes.MapPut("/api/User/{id}", (int id, User input) =>
//        {
//            return Results.NoContent();
//        })
//        .WithName("UpdateUser")
//        .Produces(StatusCodes.Status204NoContent);

//        routes.MapPost("/api/User/", (User model) =>
//        {
//            //return Results.Created($"//api/Users/{model.ID}", model);
//        })
//        .WithName("CreateUser")
//        .Produces<User>(StatusCodes.Status201Created);

//        routes.MapDelete("/api/User/{id}", (int id) =>
//        {
//            //return Results.Ok(new User { ID = id });
//        })
//        .WithName("DeleteUser")
//        .Produces<User>(StatusCodes.Status200OK);
//    }
//}}
