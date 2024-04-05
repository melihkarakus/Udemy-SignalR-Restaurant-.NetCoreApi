using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult BasketList()
        {
            var values = _basketService.TGetListAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetBasketByMenuTableNumber(int id)
        {
            var values = _mapper.Map<List<ResultBasketDtos>>(_basketService.TGetBasketByMenuTableNumber(id));
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTableWithProductName")]//Httpget sepetin içindeki ürünler ürün adına göre getirme sınıfı oluşturuldu.
        public IActionResult BasketListByMenuTableWithProductName(int id)//oluşturulan sınıf çağrıldı id ile
        {
            using var context = new SignalRContext();//Database bağlantısı kuruldu.
            //Values içine include ile product tablosunu seçti -> şartı ise menu sınıfındakileri id -> seçtir bizim tanımlanan modele göre 
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select(z => new ResultBasketListWithProducts
            {
                //Buraya ise modelde tanımlanan tablo verilerinin getirdik.
                BasketID = z.BasketID,
                Count = z.Count,
                MenuTableID = z.MenuTableID,
                Price = z.Price,
                ProductID = z.ProductID,
                TotalPrice = z.TotalPrice,
                ProductName = z.Product.ProductName //Product sınıfının productname ile getirdik.
            }).ToList();//listeleme işlemi yaptık.
            return Ok(values);//values gösterdik
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDtos createBasketDtos)
        {
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductID = createBasketDtos.ProductID,
                Count = 1,
                MenuTableID = 4,
                Price = context.Products.Where(x => x.ProductID == createBasketDtos.ProductID).Select(y => y.Price).FirstOrDefault(),
                TotalPrice = 0,
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var valıues = _basketService.TGetByID(id);
            _basketService.TDelete(valıues);
            return Ok("İşlem başarılı ile silinmiştir.");
        }
    }
}
