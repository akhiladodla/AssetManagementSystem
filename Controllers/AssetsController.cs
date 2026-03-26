namespace AssetManagementApi.Controllers;using Microsoft.AspNetCore.Mvc;
using AssetManagementApi.Data;
using AssetManagementApi.Models;
[ApiController]
[Route("api/[controller]")]
public class AssetsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AssetsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAssets()
    {
        return Ok(_context.Assets.ToList());
    }

    [HttpPost]
    public IActionResult AddAsset(Asset asset)
    {
        _context.Assets.Add(asset);
        _context.SaveChanges();
        return Ok(asset);
    }
    [HttpPost("assign")]
public IActionResult AssignAsset(int assetId, int employeeId)
{
    var asset = _context.Assets.Find(assetId);
    if (asset == null)
        return NotFound("Asset not found");

    if (asset.Status == "Assigned")
        return BadRequest("Asset already assigned");

    var employee = _context.Employees.Find(employeeId);
    if (employee == null)
        return NotFound("Employee not found");

    asset.AssignedToEmployeeId = employeeId;
    asset.Status = "Assigned";

    _context.SaveChanges();

    return Ok(asset);
}
}