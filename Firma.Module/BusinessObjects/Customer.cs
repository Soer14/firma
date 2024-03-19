using ApplicationCommon;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using GUS_lib;
using GUS_lib.Models;

namespace Firma.Module.BusinessObjects
{


    [DefaultClassOptions]
    [XafDefaultProperty(nameof(Symbol))]
    [NavigationItem("Kartoteki")]
    public class Customer : CustomBaseObject

    {
        public Customer(Session session) : base(session)
        { }


        string extra1;
        string customerType;
        SilosType silosType;
        string regon;
        Address mailingAddress;
        Address officeAddress;
        string email;
        string phoneNumber;
        string vatNumber;
        string symbol;
        string customerName;
        string notes;
        string lastName;
        string firstName;







        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Symbol
        {
            get => symbol;
            set => SetPropertyValue(nameof(Symbol), ref symbol, value);
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string FirstName
        {
            get => firstName;
            set => SetPropertyValue(nameof(FirstName), ref firstName, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LastName
        {
            get => lastName;
            set => SetPropertyValue(nameof(LastName), ref lastName, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CustomerName
        {
            get => customerName;
            set => SetPropertyValue(nameof(CustomerName), ref customerName, value);
        }
        [DataSourceProperty(nameof(Addresses))]
        public Address OfficeAddress

        {
            get => officeAddress;
            set => SetPropertyValue(nameof(OfficeAddress), ref officeAddress, value);
        }
        [DataSourceProperty(nameof(Addresses))]
        public Address MailingAddress
        {
            get => mailingAddress;
            set => SetPropertyValue(nameof(MailingAddress), ref mailingAddress, value);
        }

        [Size(11)]
        public string VatNumber
        {
            get => vatNumber;
            set
            {
                var modified = SetPropertyValue(nameof(VatNumber), ref vatNumber, value);
                if (modified && !IsLoading && !IsSaving && value.Length == 10)
                {
                    //Klient środowiska produkcyjnego
                    GetCustomerByNIP(value);
                }



            }

        }

        private void GetCustomerByNIP(string nip)
        {
            GUS gusClient = new GUS(ApplicationSettings.GusApiKey);

            gusClient.Login(true);
            Podmiot podmiot = gusClient.SzukajPodmiotNip(nip);
            FillCustomerData(podmiot);
        }

        private void GetCustomerByRegon(string regon)
        {
            GUS gusClient = new GUS(ApplicationSettings.GusApiKey);

            gusClient.Login(true);
            Podmiot podmiot = gusClient.SzukajPodmiotRegon(regon);
            FillCustomerData(podmiot);
        }

        private void FillCustomerData(Podmiot podmiot)
        {
            if (podmiot != null)
            {
                CustomerName = podmiot.Nazwa;
                var address = new Address(Session);
                address.Customer = this;
                Addresses.Add(address);
                address.City = podmiot.Miejscowosc;
                address.Street = podmiot.Ulica;
                address.ApartmentNumber = podmiot.NrLokalu;
                address.Commune = podmiot.Gmina;
                address.HouseNumber = podmiot.NrNieruchomosci;
                address.Voivodeship = podmiot.Wojewodztwo;
                address.PostalCode = podmiot.KodPocztowy;
                OfficeAddress = address;
                Regon = podmiot.Regon;
                SilosType = (SilosType)((int)podmiot.SilosID);
                CustomerType = Char.ToString(podmiot.Typ);


            }
        }

        public SilosType SilosType
        {
            get => silosType;
            set => SetPropertyValue(nameof(SilosType), ref silosType, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CustomerType
        {
            get => customerType;
            set => SetPropertyValue(nameof(CustomerType), ref customerType, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Regon
        {
            get => regon;
            set
            {
                var modified = SetPropertyValue(nameof(Regon), ref regon, value);
                if (modified && !IsLoading && !IsSaving && value.Length == 9)
                {
                    GetCustomerByRegon(value);

                }
            }
        }



        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetPropertyValue(nameof(PhoneNumber), ref phoneNumber, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }
        [Size(SizeAttribute.Unlimited)]
        public string Notes
        {
            get => notes;
            set => SetPropertyValue(nameof(Notes), ref notes, value);
        }

        [Association]
        public XPCollection<Address> Addresses
        {
            get
            {
                return GetCollection<Address>(nameof(Addresses));
            }
        }

        [Association]
        public XPCollection<Invoice> Invoices
        {
            get
            {
                return GetCollection<Invoice>(nameof(Invoices));

            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Extra1
        {
            get => extra1;
            set => SetPropertyValue(nameof(Extra1), ref extra1, value);
        }
    }
    public enum SilosType
    {
        CEIDG = 1,
        Rolnicza = 2,
        Inna = 3,
        KRUPGN = 4,
        Prawna = 6
    }
}