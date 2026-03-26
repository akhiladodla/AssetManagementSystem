using Microsoft.AspNetCore.Mvc;
using AssetManagementApi.Data;
using AssetManagementApi.Models;

namespace AssetManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmployeesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetEmployees()
    {
        return Ok(_context.Employees.ToList());
    }

    [HttpPost]
    public IActionResult AddEmployee(Employee emp)
    {
        _context.Employees.Add(emp);
        _context.SaveChanges();
        return Ok(emp);
    }
}