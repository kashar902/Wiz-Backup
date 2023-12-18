using App.Wiz.Common.BaseEntity;

namespace App.Wiz.Infrastructure.Entities
{
    public class Vehicle : BaseEntities
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? RegistrationNo { get; set; }
        public string? Description { get; set; }
    }
}
