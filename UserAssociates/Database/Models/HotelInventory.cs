using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models
{
	public class HotelInventory : BaseEntities
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string ReservationPrefix { get; set; }
		public string ReservationSequence { get; set; }
		public bool EnforceSameGenderInSharedReservations { get; set; }
		public bool HidePaxesAlreadyAddedInReservation { get; set; }
		public int User_ID { get; set; }
	}
}
