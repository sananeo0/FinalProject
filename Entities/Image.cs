namespace FinalProject.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
