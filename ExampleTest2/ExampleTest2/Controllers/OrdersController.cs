using ExampleTest2.DTOs;
using ExampleTest2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IDbService _dbService;
    public OrdersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrdersData(string? clientLastName = null)
    {
        var orders = await _dbService.GetMultipleObjectsData(clientLastName);
        
        return Ok(orders.Select(e => new GetOrdersDTO()
        {
            Id = e.Id,
            AcceptedAt = e.AcceptedAt,
            FulfilledAt = e.FulfilledAt,
            Comments = e.Comments,
            Pastries = e.sampleAssociativeModels.Select(p => new GetOrdersPastryDTO
            {
                Name = p.Pastry.Name,
                Price = p.Pastry.Price,
                Amount = p.Amount
            }).ToList()
        }));
    }
}