using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDtos>>(_productService.TGetListAll());
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory()
            {
                ProductName = y.ProductName,
                Description = y.Description,
                Price = y.Price,
                ProductStatus = y.ProductStatus,
                ImageUrl = y.ImageUrl,
                ProductID = y.ProductID,
                CategoryName = y.Category.CategoryName
            });
            return Ok(values.ToList());
            //var values = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
            //return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDtos createProductDtos)
        {
            _productService.TAdd(new Product()
            {
                ProductName = createProductDtos.ProductName,
                Description = createProductDtos.Description,
                Price = createProductDtos.Price,
                ImageUrl = createProductDtos.ImageUrl,
                ProductStatus = createProductDtos.ProductStatus,
                CategoryID = createProductDtos.CategoryID,//İlişkili tablo oluşturduğumuz için dto da bunu geçtik fakat burada geçmemiz gerekir.
            });
            return Ok("İşlem başarılı şekilde eklenmiştir.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id) 
        {
            var values = _productService.TGetByID(id);
            _productService.TDelete(values);
            return Ok("İşlem başarılı şekilde silinmiştir.");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDtos updateProductDtos)
        {
            _productService.TUpdate(new Product()
            {
                ProductID = updateProductDtos.ProductID,
                ProductName = updateProductDtos.ProductName,
                Description = updateProductDtos.Description,
                Price = updateProductDtos.Price,
                ImageUrl = updateProductDtos.ImageUrl,
                ProductStatus = updateProductDtos.ProductStatus,
                CategoryID = updateProductDtos.CategoryID,
            });
            return Ok("İşlem başarılı şekilde güncellenmiştir.");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var values = _productService.TGetByID(id);
            return Ok(values);
        }
    }
}
