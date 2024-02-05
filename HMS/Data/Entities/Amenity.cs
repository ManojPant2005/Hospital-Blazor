using System.ComponentModel.DataAnnotations;

namespace HMS.Data.Entities
{
    public class Amenity
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(25)]
        public string Name { get; set; }
        [Required, MaxLength(25)]
        public string Icon { get; set; }
        public bool IsDeleted { get; set; }

        public Amenity Clone() => (MemberwiseClone() as Amenity)!;
    }
}
