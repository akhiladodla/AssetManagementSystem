namespace AssetManagementApi.Models;

public class Request
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string AssetType { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";
}