using HeroesAndMonsters.Data.Models.Heroes;
using System.ComponentModel.DataAnnotations;

namespace HeroesAndMonsters.Data.Models
{
    public class Player
    {
        public Player(Hero hero)
        {
            this.Hero = hero;

            this.CreationTime = DateTime.UtcNow;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public Hero Hero { get; set; } = null!;

        public DateTime CreationTime { get; set; }
    }
}
