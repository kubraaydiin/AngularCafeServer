namespace AngularCafeServer.DTOs.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string Name { get; set; }        // Sarah Jenkins
        public string Title { get; set; }       // Freelance Designer
        public string Comment { get; set; }     // Yorum metni

        public string ImageUrl { get; set; }    // Profil resmi
        public int Rating { get; set; }         // 1-5 yıldız

        public bool IsActive { get; set; }      // Yayında mı
        public int DisplayOrder { get; set; }   // Slider sırası
    }
}
