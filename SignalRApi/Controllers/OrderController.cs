﻿using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}
		[HttpGet("TotalOrderCount")]
		public IActionResult TotalOrderCount()
		{
			return Ok(_orderService.TTotalOrderCount());
		}
		[HttpGet("ActiveOrderCount")]
		public IActionResult ActiveOrderCount()
		{
			return Ok(_orderService.TActiveOrderCount());
		}
		[HttpGet("PassiveOrderCount")]
		public IActionResult PassiveOrderCount()
		{
			return Ok(_orderService.TPassiveOrderCount());
		}
		[HttpGet("LastOrderPrice")]
		public IActionResult LastOrderPrice()
		{
			return Ok(_orderService.TLastOrderPrice());
		}
		[HttpGet("ToDayTotalPrice")]
		public IActionResult ToDayTotalPrice()
		{
			return Ok(_orderService.TToDayTotalPrice());
		}
	}
}
