using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDtos>>(_categoryService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDtos createCategoryDtos)
        {
            _categoryService.TAdd(new Category()
            {
                CategoryName = createCategoryDtos.CategoryName,
                Status = createCategoryDtos.Status,
            });
            return Ok("İşlem başarı şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var values = _categoryService.TGetByID(id);
            _categoryService.TDelete(values);
            return Ok("İşlem başarı şekilde silinmiştir.");
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var values = _categoryService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDtos updateCategoryDtos)
        {
            _categoryService.TUpdate(new Category()
            {
                CategoryID = updateCategoryDtos.CategoryID,
                CategoryName = updateCategoryDtos.CategoryName,
                Status = updateCategoryDtos.Status,
            });
            return Ok("İşlem başarı şekilde güncellenmiştir.");
        }
    }
}
