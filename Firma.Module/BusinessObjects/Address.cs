using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Kartoteki")]
    public class Address : BaseObject

    {
        public Address(Session session) : base(session)
        { }

        public object DisplayName => $"{Street} {City}";

        Customer customer;
        string street;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Street
        {
            get => street;
            set => SetPropertyValue(nameof(Street), ref street, value);
        }

        string houseNumber;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string HouseNumber
        {
            get => houseNumber;
            set => SetPropertyValue(nameof(HouseNumber), ref houseNumber, value);
        }

        string apartmentNumber;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ApartmentNumber
        {
            get => apartmentNumber;
            set => SetPropertyValue(nameof(ApartmentNumber), ref apartmentNumber, value);
        }

        string city;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string City
        {
            get => city;
            set => SetPropertyValue(nameof(City), ref city, value);
        }

        string postalCode;

        [Size(10)] // Adjust the size accordingly
        public string PostalCode
        {
            get => postalCode;
            set => SetPropertyValue(nameof(PostalCode), ref postalCode, value);
        }

        string country;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Country
        {
            get => country;
            set => SetPropertyValue(nameof(Country), ref country, value);
        }

        string commune;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Commune
        {
            get => commune;
            set => SetPropertyValue(nameof(Commune), ref commune, value);
        }

        string voivodeship;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Voivodeship
        {
            get => voivodeship;
            set => SetPropertyValue(nameof(Voivodeship), ref voivodeship, value);
        }


        [Association]
        public Customer Customer
        {
            get => customer;
            set => SetPropertyValue(nameof(Customer), ref customer, value);
        }
        [Action(AutoCommit = true,Caption ="Set As Office Address", ImageName ="BO_Skull")]
        public void SetAsOfficeAddress()
        {
            if (Customer != null)
            {
                Customer.OfficeAddress = this;
            }
        }
        [Action(AutoCommit = true, Caption = "Set As Mailing Address", ImageName = "Travel_Pub")]
        public void SetAsMailingAddress()
        {
            if (Customer != null)
            {
                Customer.MailingAddress = this;
            }
        }

    }



}
