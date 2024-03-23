using System;
using System.Globalization;
using System.Security.AccessControl;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Poland;
using DevExpress.Data.Filtering;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using Firma.Module.BusinessObjects;
using Firma.Module.BusinessObjects.Kartoteki;
using Microsoft.Extensions.DependencyInjection;

namespace Firma.Module.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater
{
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
        base(objectSpace, currentDBVersion)
    {
    }
    public override void UpdateDatabaseAfterUpdateSchema()
    {
        base.UpdateDatabaseAfterUpdateSchema();
        //string name = "MyName";
        //DomainObject1 theObject = ObjectSpace.FirstOrDefault<DomainObject1>(u => u.Name == name);
        //if(theObject == null) {
        //    theObject = ObjectSpace.CreateObject<DomainObject1>();
        //    theObject.Name = name;
        //}



        // The code below creates users and roles for testing purposes only.
        // In production code, you can create users and assign roles to them automatically, as described in the following help topic:
        // https://docs.devexpress.com/eXpressAppFramework/119064/data-security-and-safety/security-system/authentication

        // If a role doesn't exist in the database, create this role
        var defaultRole = CreateDefaultRole();
        var adminRole = CreateAdminRole();

        ObjectSpace.CommitChanges(); //This line persists created object(s).

        UserManager userManager = ObjectSpace.ServiceProvider.GetRequiredService<UserManager>();
        // If a user named 'User' doesn't exist in the database, create this user
        AddUser(userManager, defaultRole, "User");
        AddUser(userManager, defaultRole, "John");
        AddUser(userManager, defaultRole, "Sam");

        // If a user named 'Admin' doesn't exist in the database, create this user
        if (userManager.FindUserByName<ApplicationUser>(ObjectSpace, "Admin") == null)
        {
            // Set a password if the standard authentication type is used
            string EmptyPassword = "";
            _ = userManager.CreateUser<ApplicationUser>(ObjectSpace, "Admin", EmptyPassword, (user) =>
            {
                // Add the Administrators role to the user
                user.Roles.Add(adminRole);
            });
        }
        if (true)
        {
            AddTestData(ObjectSpace);

            DodajKraje(ObjectSpace);

            //DodajWojewodztwa(ObjectSpace);

            FillMissingData();
        }
        ObjectSpace.CommitChanges(); //This line persists created object(s).

    }

    private void FillMissingData()
    {
        var employeesFromDatabase = ObjectSpace.GetObjectsQuery<Employee>().Where(e => e.Department == null);
        var departments = ObjectSpace.GetObjectsQuery<Department>().ToList();
        var random = new Random();
        foreach (var employee in employeesFromDatabase)
        {
            int index = random.Next(departments.Count);
            employee.Department = departments[index];
        }
        var customers = ObjectSpace.GetObjectsQuery<Customer>().Where(e => e.OfficeAddress == null);

        var adrFaker = new Faker<BusinessObjects.Address>("pl")
            .CustomInstantiator(f => ObjectSpace.CreateObject<BusinessObjects.Address>())
            .RuleFor(o => o.City, f => f.Address.City())
            .RuleFor(o => o.PostalCode, f => f.Address.ZipCode())
            .RuleFor(o => o.Street, f => f.Address.StreetName());

        foreach (var customer in customers)
        {
            var adress = adrFaker.Generate(1).First();
            customer.OfficeAddress = adress;
            var adress2 = adrFaker.Generate(1).First();
            customer.MailingAddress = adress2;
        }
        var customers2 = ObjectSpace.GetObjectsQuery<Customer>();
        foreach (var customer in customers2)
        {
            customer.Addresses.Add(customer.OfficeAddress);
            customer.Addresses.Add(customer.MailingAddress);
        }
    }


    private void AddUser(UserManager userManager, PermissionPolicyRole defaultRole, string userName)
    {
        if (userManager.FindUserByName<ApplicationUser>(ObjectSpace, userName) == null)
        {
            // Set a password if the standard authentication type is used
            string EmptyPassword = "";
            _ = userManager.CreateUser<ApplicationUser>(ObjectSpace, userName, EmptyPassword, (user) =>
            {
                // Add the Users role to the user
                user.Roles.Add(defaultRole);
            });
        }
    }
    private void DodajWojewodztwa(IObjectSpace objectSpace)
    {
        Session session = ((XPObjectSpace)objectSpace).Session;
        Voivodeship zachodniopomorskie = new Voivodeship(session) { Name = "Zachodniopomorskie", IsoCode = "PL-32" };
        Voivodeship wielkopolskie = new Voivodeship(session) { Name = "Wielkopolskie", IsoCode = "PL-30" };
        Voivodeship warmińskoMazurskie = new Voivodeship(session) { Name = "Warmińsko-Mazurskie", IsoCode = "PL-28" };
        Voivodeship swietokrzyskie = new Voivodeship(session) { Name = "Świętokrzyskie", IsoCode = "PL-26" };
        Voivodeship slaskie = new Voivodeship(session) { Name = "Śląskie", IsoCode = "PL-24" };
        Voivodeship pomorskie = new Voivodeship(session) { Name = "Pomorskie", IsoCode = "PL-22" };
        Voivodeship podlaskie = new Voivodeship(session) { Name = "Podlaskie", IsoCode = "PL-20" };
        Voivodeship podkarpackie = new Voivodeship(session) { Name = "Podkarpackie", IsoCode = "PL-18" };
        Voivodeship opolskie = new Voivodeship(session) { Name = "Opolskie", IsoCode = "PL-16" };
        Voivodeship mazowieckie = new Voivodeship(session) { Name = "Mazowieckie", IsoCode = "PL-14" };
        Voivodeship malopolskie = new Voivodeship(session) { Name = "Małopolskie", IsoCode = "PL-12" };
        Voivodeship lodzkie = new Voivodeship(session) { Name = "Łódzkie", IsoCode = "PL-10" };
        Voivodeship lubuskie = new Voivodeship(session) { Name = "Lubuskie", IsoCode = "PL-08" };
        Voivodeship lubelskie = new Voivodeship(session) { Name = "Lubelskie", IsoCode = "PL-06" };
        Voivodeship kujawskoPomorskie = new Voivodeship(session) { Name = "Kujawsko-Pomorskie", IsoCode = "PL-04" };
        Voivodeship dolnoslaskie = new Voivodeship(session) { Name = "Dolnośląskie", IsoCode = "PL-02" };
    }


    private void AddTestData(IObjectSpace objectSpace)
    {
        var departmentFaker = new Faker<Department>("pl")
           .CustomInstantiator(f => ObjectSpace.CreateObject<Department>())
           .RuleFor(o => o.Title, f => f.Commerce.Department())
           .RuleFor(o => o.Office, f => f.Commerce.Department());

        var departments = departmentFaker.Generate(10);

        var adrFaker = new Faker<BusinessObjects.Address>("pl")
            .CustomInstantiator(f => ObjectSpace.CreateObject<BusinessObjects.Address>())
            .RuleFor(o => o.City, f => f.Address.City())
            .RuleFor(o => o.PostalCode, f => f.Address.ZipCode())
            .RuleFor(o => o.Street, f => f.Address.StreetName());
        var adresses = adrFaker.Generate(20);
        ObjectSpace.CommitChanges();


       

        var cusFaker = new Faker<Customer>("pl")
            .CustomInstantiator(f => ObjectSpace.CreateObject<Customer>())
            .RuleFor(o => o.PhoneNumber, f => f.Person.Phone)
            .RuleFor(o => o.Symbol, f => f.Company.CompanyName())
            .RuleFor(o => o.CustomerName, f => f.Company.CompanyName())
            .RuleFor(o => o.VatNumber, f => f.Company.Nip())
            .RuleFor(o => o.Email, (f, u) => f.Internet.Email())
            .RuleFor(o => o.FirstName, (f, u) => f.Person.FirstName)
            .RuleFor(o => o.OfficeAddress, f => f.PickRandom(adresses))
            .RuleFor(o => o.MailingAddress, f => f.PickRandom(adresses))
            .RuleFor(o => o.LastName, (f, u) => f.Person.LastName);

        var customers = cusFaker.Generate(10);
        var stawki = objectSpace.GetObjectsQuery<VatRate>().ToList();
        if (stawki.Count == 0)
        {

            stawki.Add(NowaStawka("23%", 23M));
            stawki.Add(NowaStawka("0%", 0M));
            stawki.Add(NowaStawka("7%", 7M));
            stawki.Add(NowaStawka("ZW", 0M));
        }
        

        var ProductFaker = new Faker<Product>("pl")
             .CustomInstantiator(f => ObjectSpace.CreateObject<Product>())
             .RuleFor(o => o.ProductName, f => f.Commerce.ProductName())
             .RuleFor(o => o.Symbol, f => f.Commerce.Product())
             .RuleFor(o => o.GTIN, f => f.Commerce.Ean13())
             .RuleFor(o => o.VatRate, f => f.PickRandom(stawki))
             .RuleFor(o => o.Notes, (f, u) => f.Commerce.ProductDescription());



        var Product = ProductFaker.Generate(10);


        

        var EmployeeFaker = new Faker<Employee>("pl")
            .CustomInstantiator(f => ObjectSpace.CreateObject<Employee>())
            .RuleFor(o => o.FirstName, f => f.Person.FirstName)
            .RuleFor(o => o.LastName, f => f.Person.LastName)
            .RuleFor(o => o.BirthDate, f => f.Person.DateOfBirth)
            .RuleFor(o => o.WebPageAddress, (f, u) => f.Internet.Url())
            .RuleFor(o => o.Department, f => f.PickRandom(departments))
            .RuleFor(o => o.Email, (f, u) => f.Internet.Email());


        var employees = EmployeeFaker.Generate(10);
        objectSpace.CommitChanges();


        var employeesFromDatabase = objectSpace.GetObjectsQuery<Employee>().ToList();
        var phoneFaker = new Faker<BusinessObjects.Kartoteki.PhoneNumber>("pl")
          .CustomInstantiator(f => ObjectSpace.CreateObject<BusinessObjects.Kartoteki.PhoneNumber>())
          .RuleFor(o => o.Number, f => f.Person.Phone)
          .RuleFor(o => o.Employee, f => f.PickRandom(employeesFromDatabase))
          .RuleFor(o => o.PhoneType, f => "komórkowy");


        var phones = phoneFaker.Generate(300);
    }

    private VatRate NowaStawka(string symbol, decimal value)
    {
        VatRate stawka = ObjectSpace.FindObject<VatRate>(CriteriaOperator.Parse("Symbol = ?", symbol));
        if (stawka == null)
        {
            stawka = ObjectSpace.CreateObject<VatRate>();
            stawka.Symbol = symbol;
            stawka.RateValue = value;


        }
        return stawka;
    }


    public override void UpdateDatabaseBeforeUpdateSchema()
    {
        base.UpdateDatabaseBeforeUpdateSchema();
        //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
        //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
        //}
    }
    private PermissionPolicyRole CreateAdminRole()
    {
        PermissionPolicyRole adminRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(r => r.Name == "Administrators");
        if (adminRole == null)
        {
            adminRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
            adminRole.Name = "Administrators";
            adminRole.IsAdministrative = true;
        }
        return adminRole;
    }
    private PermissionPolicyRole CreateDefaultRole()
    {
        PermissionPolicyRole defaultRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(role => role.Name == "Default");
        if (defaultRole == null)
        {
            defaultRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
            defaultRole.Name = "Default";

            defaultRole.AddObjectPermissionFromLambda<ApplicationUser>(SecurityOperations.Read, cm => cm.Oid == (Guid)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
            defaultRole.AddNavigationPermission(@"Application/NavigationItems/Items/Default/Items/MyDetails", SecurityPermissionState.Allow);
            defaultRole.AddMemberPermissionFromLambda<ApplicationUser>(SecurityOperations.Write, "ChangePasswordOnFirstLogon", cm => cm.Oid == (Guid)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
            defaultRole.AddMemberPermissionFromLambda<ApplicationUser>(SecurityOperations.Write, "StoredPassword", cm => cm.Oid == (Guid)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
            defaultRole.AddTypePermissionsRecursively<PermissionPolicyRole>(SecurityOperations.Read, SecurityPermissionState.Deny);
            defaultRole.AddObjectPermission<ModelDifference>(SecurityOperations.ReadWriteAccess, "UserId = ToStr(CurrentUserId())", SecurityPermissionState.Allow);
            defaultRole.AddObjectPermission<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, "Owner.UserId = ToStr(CurrentUserId())", SecurityPermissionState.Allow);
            defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.Create, SecurityPermissionState.Allow);
            defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.Create, SecurityPermissionState.Allow);
            defaultRole.AddTypePermission<AuditDataItemPersistent>(SecurityOperations.Read, SecurityPermissionState.Deny);
            defaultRole.AddObjectPermissionFromLambda<AuditDataItemPersistent>(SecurityOperations.Read, a => a.UserId == CurrentUserIdOperator.CurrentUserId().ToString(), SecurityPermissionState.Allow);
            defaultRole.AddTypePermission<AuditedObjectWeakReference>(SecurityOperations.Read, SecurityPermissionState.Allow);
        }
        return defaultRole;
    }
    void DodajKraje(IObjectSpace os)
    {
        var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
        foreach (CultureInfo ci in cultures)

        {

            RegionInfo ri = null;

            try

            {

                ri = new RegionInfo(ci.Name);

            }

            catch

            {

                // If a RegionInfo object could not be created we don't want to use the CultureInfo

                //    for the country list.

                continue;

            }



            var currency = ObjectSpace.FindObject<BusinessObjects.Currency>(new BinaryOperator("Symbol", ri.ISOCurrencySymbol));
            if (currency == null)
            {
                currency = ObjectSpace.CreateObject<BusinessObjects.Currency>();
                currency.Symbol = ri.ISOCurrencySymbol;
                currency.EnglishName = ri.CurrencyEnglishName;
                currency.NativeName = ri.CurrencyNativeName;
                currency.NativeSymbol = ri.CurrencySymbol;
            }

            var country = ObjectSpace.FindObject<BusinessObjects.Country>(new BinaryOperator("Symbol", ri.ThreeLetterISORegionName));
            if (country == null)
            {
                country = ObjectSpace.CreateObject<BusinessObjects.Country>();
                country.Symbol = ri.ThreeLetterISORegionName;
                country.EnglishName = ri.EnglishName;
                country.NativeSymbol = ri.TwoLetterISORegionName;
                country.NativeName = ri.NativeName;
                country.GeoId = ri.GeoId;
                country.Currency = currency;
                country.IsMetric = ri.IsMetric;

            }
            currency.Country = country;
        }
    }


}
