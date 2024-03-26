namespace SignalR.EntityLayer.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool ProductStatus { get; set; }
        //İlişkili tablo için her ürünün bir kategorisi olacağı için 
        public int CategoryID { get; set; }//Category Entity ID Eklendi
        public Category Category { get; set; }//Category tablosuda buraya geçildi
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
