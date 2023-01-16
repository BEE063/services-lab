using Microsoft.AspNetCore.Mvc;

namespace servicetwo.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private static readonly string[] Dishes = new[]
    {
        "Сroissant", "Pie", "Tea", "Cake", "Milkshake", "Pizza", "Wok", "Sushi"
    };

    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetOrder")]
    public IEnumerable<Order> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Order
        {
            Date = DateTime.Now.AddDays(index),
            Price = Random.Shared.Next(0, 2000),
            Dish = Dishes[Random.Shared.Next(Dishes.Length)]
        })
        .ToArray();
    }
}
