using Microsoft.AspNetCore.Mvc;
using swen_capstone_project.Data;
using swen_capstone_project.Models;

namespace swen_capstone_project.Controllers;

[Route("[controller]")]
[ApiController]
public class AssignmentController : Controller
{
    private readonly CapstoneProjectContext _context;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AssignmentController> _logger;

    public AssignmentController(ILogger<AssignmentController> logger, IConfiguration configuration, CapstoneProjectContext context)
    {
        _logger = logger;
        _configuration = configuration;
        _context = context;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(_context.Assignments.ToList());
    }

    [HttpPost]
    [Route("create/{id}")]
    public ActionResult CreateAssignment(int userId, [FromBody]Assignment assignment)
    {
        _context.Assignments.Add(assignment);
        var creator = _context.Users.FirstOrDefault(u => u.Id == userId);
        if (creator == null)
        {
            return NotFound();
        }

        creator.Assignments.Add(assignment);
        _context.SaveChanges();
        return Ok();
    }
}
