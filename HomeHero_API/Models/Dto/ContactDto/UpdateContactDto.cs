namespace HomeHero_API.Models.Dto.ContactDto
{
    public class UpdateContactDto
    {
        public string OwnerUserEmail { get; set; }
        public string OldNumberPhone { get; set; }
        public string NewNumberPhone { get; set; }
    }
}
