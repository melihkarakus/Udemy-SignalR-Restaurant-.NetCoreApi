using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTableController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;

		public MenuTableController(IMenuTableService menuTableService)
		{
			_menuTableService = menuTableService;
		}
		[HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.TMenuTableCount());
		}
		[HttpGet]
		public IActionResult MenuTableList()
		{
			var values = _menuTableService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDtos createMenuTableDtos)
		{
			_menuTableService.TAdd(new MenuTable()
			{
				Name = createMenuTableDtos.Name,
				Status = false,
			});
			return Ok("Masa Başarılı Şekilde Eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var values = _menuTableService.TGetByID(id);
			_menuTableService.TDelete(values);
			return Ok("İşlem Başarılı Şekilde Silindi");
		}
		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDtos updateMenuTableDtos)
		{
			_menuTableService.TUpdate(new MenuTable()
			{
				MenuTableID = updateMenuTableDtos.MenuTableID,
				Name = updateMenuTableDtos.Name,
				Status = updateMenuTableDtos.Status,
			});
			return Ok("İşlem Başarılı Şekilde Güncellendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var values = _menuTableService.TGetByID(id);
			return Ok(values);
		}
	}
}
