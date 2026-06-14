using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_web_Tatry.Entities
{
    public class Zdjecie
    {
        public int Id { get; set; }
        public string SciezkaPliku { get; set; } = string.Empty; 
        public int SzlakId { get; set; }
        public Szlak? Szlak { get; set; }
    }
}
