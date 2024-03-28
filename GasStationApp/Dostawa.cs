namespace GasStationApp
{
    public class Dostawa
    {
        public string Identyfikator { get; set; }
        public string NazwaKlienta { get; set; }
        public int IdDostawcy { get; set; }
        public string NazwaDostawcy { get; set; }
        public DateTime DataDostawy { get; set; }
        public DateTime CzasDostawy { get; set; }
        public string Kraj { get; set; }
        public int PunktAkceptacji { get; set; }
        public string MarkaKoncern { get; set; }
        public string Miejscowosc { get; set; }
        public string KodPocztowyStacji { get; set; }
        public double StawkaVAT { get; set; }
        public string NrRejestr { get; set; }
        public int StanLicznika { get; set; }
        public string MiejsceKosztu { get; set; }
        public string MiejsceKosztu2 { get; set; }
        public string KategoriaKarty { get; set; }
        public double NrKarty { get; set; }
        public string PelnyNumerKarty { get; set; }
        public string Produkt { get; set; }
        public string KodProduktu { get; set; }
        public double Ilosc { get; set; }
        public string Waluta { get; set; }
        public double CenaJednostkowaNetto { get; set; }
        public double CenaJedn { get; set; }
        public double WartoscNetto { get; set; }
        public double Wartosc { get; set; }
        public string UTAVoucherNumber { get; set; }
        public string VoucherNr { get; set; }
    }
}
