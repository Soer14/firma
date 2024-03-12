using Bogus.DataSets;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using GUS_lib;
using GUS_lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.BusinessObjects
{


    [DefaultClassOptions]
    [XafDefaultProperty(nameof(Symbol))]
    [NavigationItem("Kartoteki")]
    public class Customer : CustomBaseObject

    {
        public Customer(Session session) : base(session)
        { }


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
                    GUS gusClient = new GUS("f3ccc9d63a3243bba830");

                    gusClient.Login(true);
                    Podmiot pNIP = gusClient.SzukajPodmiotNip(VatNumber);
                    Console.WriteLine($"{pNIP.Nazwa}{pNIP.Miejscowosc}{pNIP.KodPocztowy}{pNIP.Ulica}{pNIP.NrLokalu}");
                    if (pNIP != null)
                    {
                        CustomerName = pNIP.Nazwa;
                        var address = new Address(Session);
                        address.Customer = this;
                        Addresses.Add(address);
                        address.City = pNIP.Miejscowosc;
                        address.Street = pNIP.Ulica;
                        address.ApartmentNumber = pNIP.NrLokalu;
                        address.Commune = pNIP.Gmina;
                        address.HouseNumber = pNIP.NrNieruchomosci;
                        address.Voivodeship = pNIP.Wojewodztwo;
                        address.PostalCode = pNIP.KodPocztowy;
                        OfficeAddress = address;
                        Regon = pNIP.Regon;
                        SilosType = (SilosType)((int) pNIP.SilosID);
                        CustomerType = Char.ToString(pNIP.Typ);


                    }
                }



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
                    GUS gusClient = new GUS("f3ccc9d63a3243bba830");

                    gusClient.Login(true);
                    Podmiot pRegon = gusClient.SzukajPodmiotRegon(Regon);
                    Console.WriteLine($"{pRegon.Nazwa}{pRegon.Miejscowosc}{pRegon.KodPocztowy}{pRegon.Ulica}{pRegon.NrLokalu}");
                    if (pRegon != null)
                    {
                        CustomerName = pRegon.Nazwa;
                        var address = new Address(Session)
                        {
                            Customer = this,
                            City = pRegon.Miejscowosc,
                            Street = pRegon.Ulica,
                            ApartmentNumber = pRegon.NrLokalu,
                            Commune = pRegon.Gmina,
                            HouseNumber = pRegon.NrNieruchomosci,
                            Voivodeship = pRegon.Wojewodztwo,
                            PostalCode = pRegon.KodPocztowy
                        };
                        OfficeAddress = address;
                        VatNumber = pRegon.Nip;
                        SilosType = (SilosType)((int)pRegon.SilosID);
                        CustomerType = Char.ToString(pRegon.Typ);

                    }


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