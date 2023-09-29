namespace HomeHero_API.Models.Dto
{
    public class UpdateContactDto
    {
        public string OwnerUserEmail { get; set; }
        public string OldNumberPhone { get; set; }
        public string NewNumberPhone { get; set; }
    }
}
