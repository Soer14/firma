using System.Globalization;
using Bogus;
using DevExpress.Data.Filtering;
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
            //AddTestData(ObjectSpace);

           // DodajKraje(ObjectSpace);

            //   DodajWojewodztwa(ObjectSpace);


        }
        //ObjectSpace.CommitChanges(); //This line persists created object(s).

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
        var cusFaker = new Faker<Customer>("pl")
            .CustomInstantiator(f => ObjectSpace.CreateObject<Customer>())
            .RuleFor(o => o.PhoneNumber, f => f.Person.Phone)
            .RuleFor(o => o.Symbol, f => f.Company.CompanyName())
            .RuleFor(o => o.CustomerName, f => f.Company.CompanyName())
            .RuleFor(o => o.Email, (f, u) => f.Internet.Email())
            .RuleFor(o => o.FirstName, (f, u) => f.Person.FirstName)
            .RuleFor(o => o.LastName, (f, u) => f.Person.LastName);

        var customers = cusFaker.Generate(10);

        var ProductFaker = new Faker<Product>("pl")
             .CustomInstantiator(f => ObjectSpace.CreateObject<Product>())
             .RuleFor(o => o.ProductName, f => f.Commerce.ProductName())
             .RuleFor(o => o.Symbol, f => f.Commerce.Product())
             .RuleFor(o => o.GTIN, f => f.Commerce.Ean13())
             .RuleFor(o => o.Notes, (f, u) => f.Commerce.ProductDescription());


        var Product = ProductFaker.Generate(10);
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



            var currency = ObjectSpace.FindObject<Currency>(new BinaryOperator("Symbol", ri.ISOCurrencySymbol));
            if (currency == null)
            {
                currency = ObjectSpace.CreateObject<Currency>();
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
