using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.BusinessObjects
{
    public class DetailTransaction : BaseObject


    {
        public DetailTransaction(Session session) : base(session)
        { }
        //
        // {
        //   "identyfikator": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        //   "nrRachunku": 0,

        decimal ddataDostawy;
        int nrRachunku;

        public int NrRachunku
        {
            get => nrRachunku;
            set => SetPropertyValue(nameof(NrRachunku), ref nrRachunku, value);
        }
        //   "dataDostawy": "2024-04-15T09:59:24.122Z",
        
        public decimal DataDostawy
        {
            get => ddataDostawy;
            set => SetPropertyValue(nameof(DataDostawy), ref ddataDostawy, value);
        }
        //   "idPartneraRozliczeniowego": 0,
        //   "dataPrzetworzenia": "2024-04-15T09:59:24.122Z",
        //   "pelnyNrKarty": "string",
        //   "dataTransakcji": "2024-04-15T09:59:24.122Z",
        //   "numerIdStacji": 0,
        //   "lokalizacjaStacji": "string",
        //   "kodKrajuDostawy": "string",
        //   "nrPokwitowania": "string",
        //   "stanLicznika": "string",
        //   "kodProduktu": "string",
        //   "nazwaProduktu": "string",
        //   "ilosc": 0,
        //   "sB_BT": "string",
        //   "stawkaVat": 0,
        //   "walutaKrajuDostawy": "string",
        //   "cenaJednostkowaBruttoWKD": 0,
        //   "cenaJednostkowaNettoWKD": 0,
        //   "doplataWKD": 0,
        //   "rabatWKD": 0,
        //   "lacznaWartoscNettoWKD": 0,
        //   "lacznaWartoscBruttoWKD": 0,
        //   "walutaRozliczeniowa": "string",
        //   "doplataWR": 0,
        //   "rabatWR": 0,
        //   "lacznaWartoscNettoWR": 0,
        //   "lacznaWartoscVatWR": 0,
        //   "lacznaWartoscBruttoWR": 0,
        //   "nrRejNaKarcie": "string",
        //   "mpk": "string",
        //   "typKarty": "string",
        //   "statusCeny": 0,
        //   "wskaznikCeny": "string",
        //   "oznaczenieNrPojazdu": 0,
        //   "info": "string",
        //   "nrRejestracyjnyPojazdu": "string",
        //   "bitMap": "string",
        //   "czasTransakcji": 0,
        //   "dataFakturowania": "2024-04-15T09:59:24.122Z",
        //   "typTransakcji": "string",
        //   "powodWpisu": "string",
        //   "wypelnienie43": "string",
        //   "notaInformacyjna": "string",
        //   "zrodloNoty": "string",
        //   "wypelnienie46": "string",
        //   "cenaJednBruttoDostawy": 0,
        //   "cenaJednNettoDostawy": 0,
        //   "stawkaVatInf": 0,
        //   "wartoscVatOdUpustuDostawy": 0,
        //   "wartoscVatDoplatySerwisowejDostawy": 0,
        //   "licznyVatDoplatySerwisowejDostawy": 0,
        //   "dataWymagalnosci": "2024-04-15T09:59:24.122Z",
        //   "terminPlatnosci": 0,
        //   "sposobPlatnosci": "string",
        //   "tcNumerFaktury": "string",
        //   "tcDataFaktury": "2024-04-15T09:59:24.122Z",
        //   "kategoriaWartosciPlatnosci": "string",
        //   "miejscePowstaniaKosztow2": "string",
        //   "nrObcejKarty": "string",
        //   "identyfikatorUrzadzeniaOBU": "string",
        //   "nrRejPojazduSkompresowany": "string",
        //   "rodzajKarty": "string",
        //   "numerFakturyWgKraju": "string",
        //   "wjazdNaAutostrade": "string",
        //   "wyjazdZAutostrady": "string",
        //   "warunkiSpecjalneFRA": 0,
        //   "numerNotyObciazeniowej": "string",
        //   "przedstawiciel": "string",
        //   "indeks": "string",
        //   "identyfikatorSrodkaPlatnosci": "string",
        //   "kategoriaPodatkowa": "string",
        //   "numerPokwitowaniaUTA": "string",
        //   "dodatkowyNumerPokwitowaniaUTA": "string",
        //   "winietaWaznaOd": "2024-04-15T09:59:24.122Z",
        //   "winietaWaznaDo": "2024-04-15T09:59:24.122Z",
        //   "identyfikatorWystawcyUzytkownika": "string",
        //   "jednostkaMiary": "string",
        //   "krajMiejscaDostawy": "string",
        //   "kodPocztowyMiejscaDostawy": "string",
        //   "krajOpodatkowania": "string",
        //   "podatkowaGrupaProduktowa": "string",
        //   "zmiennoscMiejscaUslug": 0,
        //   "transactionDateAndTime": "2024-04-15T09:59:24.122Z"
        // }
        //
    }
}
