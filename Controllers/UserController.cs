using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using swen_capstone_project.Data;
using swen_capstone_project.Models;

namespace swen_capstone_project.Controllers;

[Route("[controller]")]
[ApiController]

public class UserController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<UserController> _logger;
    private readonly CapstoneProjectContext _context;

    public UserController(ILogger<UserController> logger, IConfiguration configuration, CapstoneProjectContext context)
    {
        _logger = logger;
        _configuration = configuration;
        _context = context;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult Get(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public ActionResult CreateUser([FromBody]User user)
    {
        return Ok(_context.Users.Add(user));
    }

    [HttpPut]
    public ActionResult UpdateUser([FromBody] User user)
    {
        var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == user.Id);
        if (userToUpdate == null)
        {
            return NotFound();
        }

        userToUpdate.Name = user.Name;
        userToUpdate.Username = user.Username;
        _context.SaveChanges();
        return Ok(userToUpdate);
    }

    [HttpPut]
    [Route("assign/{id}")]
    public ActionResult AddAssignmentToStudent(int id, [FromBody] Assignment assignment)
    {
        if (assignment == null)
        {
            return BadRequest();
        }

        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if(user == null)
        {
            return NotFound();
        }

        user.Assignments.Add(assignment);
        _context.SaveChanges();
        return Ok();
    }
}