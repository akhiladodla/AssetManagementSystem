using Microsoft.AspNetCore.Mvc;
using AssetManagementApi.Data;
using AssetManagementApi.Models;

namespace AssetManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequestsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RequestsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetRequests()
    {
        return Ok(_context.Requests.ToList());
    }

    [HttpPost]
    public IActionResult CreateRequest(Request req)
    {
        _context.Requests.Add(req);
        _context.SaveChanges();
        return Ok(req);
    }

    [HttpPut("{id}/approve")]
    public IActionResult ApproveRequest(int id)
    {
        var request = _context.Requests.Find(id);
        if (request == null) return NotFound();

        request.Status = "Approved";
        _context.SaveChanges();

        return Ok(request);
    }

    [HttpPut("{id}/reject")]
    public IActionResult RejectRequest(int id)
    {
        var request = _context.Requests.Find(id);
        if (request == null) return NotFound();

        request.Status = "Rejected";
        _context.SaveChanges();

        return Ok(request);
    }
}