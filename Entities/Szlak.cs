namespace App_web_Tatry.Entities
{
    public class Szlak
    {
        public int Id { get; set; }
        public string Nazwa { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public double Dlugosc { get; set; }
        public double CzasPrzejscia { get; set; }
        public string PoziomTrudnosci { get; set; } = string.Empty;
        public string KolorSzlakow {  get; set; } = string.Empty;
        public List<Zdjecie> Zdjecia { get; set; } = new List<Zdjecie>();

    }
}
