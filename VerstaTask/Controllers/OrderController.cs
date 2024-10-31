using AutoMapper;
using Business.DomainModels;
using Business.Services.Order;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VerstaTask.Models.Orders;
using VerstaTask.Validators;

namespace VerstaTask.Controllers;

[Route("Orders")]
public class OrderController : Controller
{
    private readonly AbstractValidator<CreateOrderRequest> createOrderValidator;
    private readonly IOrderService orderService;
    private readonly IMapper mapper;

    public OrderController(
        CreateOrderValidator createOrderValidator,
        IOrderService orderService,
        IMapper mapper)
    {
        this.createOrderValidator = createOrderValidator;
        this.orderService = orderService;
        this.mapper = mapper;
    }

    /// <summary>
    /// Отображение списка всех заказов
    /// </summary>
    [HttpGet(Name = "GetAllOrders")]
    public async Task<IActionResult> GetAll(CancellationToken token = default)
    {
        var orders = await orderService.GetAllAsync(token);

        return View(mapper.Map<ICollection<Order>>(orders));
    }

    /// <summary>
    /// Отображение подробностей о заказе
    /// </summary>
    [HttpGet("Details", Name = "GetOrderDetails")]
    public async Task<IActionResult> Details(Guid id, CancellationToken token = default)
    {
        if (id == default)
        {
            return RedirectToAction("GetAll");
        }

        var order = await orderService.GetAsync(id, token);

        return View(mapper.Map<Order>(order));
    }

    /// <summary>
    /// Создание заказа
    /// </summary>
    [HttpGet("Create", Name = "CreateOrder")]
    public IActionResult Create()
    {
        return View();
    }

    /// <summary>
    /// Создание заказа
    /// </summary>
    [HttpPost("Create", Name = "CreateOrder")]
    public async Task<IActionResult> Create(
        CreateOrderRequest request,
        CancellationToken token = default)
    {
        var validationResult = createOrderValidator.Validate(request);
        if (validationResult.Errors.Count != 0)
        {
            return BadRequest(validationResult);
        }

        var order = mapper.Map<DomainOrder>(request);
        var orderId = await orderService.CreateAsync(order, token);

        return RedirectToAction("Details", new { id = orderId });
    }
}
