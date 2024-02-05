using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HMS.Data.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public short RoomTypeId { get; set; }
        [Required, MaxLength(25), Unicode(false)]
        public string RoomNumber { get; set; }
        public bool IsAvailable { get; set; }
    }
}
