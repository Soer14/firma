
using Common.Module.Tools;
using DevExpress.Data.Filtering;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.Xpo;
using Firma.Module.BusinessObjects;
using kashiash.utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Common.Module.Imports
{
    public class KodyPocztoweImporter : CSVImporter
    {
        UnitOfWork unitOfWork;
        Session _session;
        CultureInfo culture = CultureInfo.InvariantCulture;


        public void Import(string FileName, bool deleteFile = false)
        {

            if (File.Exists(FileName))
            {
                watch = new System.Diagnostics.Stopwatch();

                watch.Start();

                ImportujPlik(FileName, ';');
                if (unitOfWork != null)
                {
                    unitOfWork.CommitChanges();
                }

                Console.WriteLine($"Specification Value Import Time: {watch.ElapsedMilliseconds} ms");


                if (deleteFile)
                {
                    File.Delete(FileName);
                }
            }
        }



        public KodyPocztoweImporter(string connectionString)
        {
            _session = new Session() { ConnectionString = connectionString };


        }

        public override void ImportRow(CsvRow csv)
        {
            if (unitOfWork == null)
            {
                unitOfWork = new UnitOfWork(_session.DataLayer);
            }
            // throw new NotImplementedException();

            var Miejscowosc = csv[1].Truncate(100);
            var Kod = csv[0];

            //PostalCode rec = unitOfWork.FindObject<PostalCode>(CriteriaOperator.Parse("City = ? And Code =?", Miejscowosc, Kod));
            PostalCode rec = unitOfWork.Query<PostalCode>().Where(p => p.City == Miejscowosc && p.Code == Kod).FirstOrDefault();
            if (rec == null)
             rec = new PostalCode(unitOfWork);
            rec.Numbers = csv[3].Truncate(100);
            rec.Street = csv[2].Truncate(100);
            rec.City = csv[1].Truncate(100);
            rec.Code = csv[0];
            //rec.KodUpr = rec.Kod.Replace("-", "");
            //PNA     ; MIEJSCOWOŚĆ; ULICA; NUMERY; GMINA; POWIAT; WOJEWÓDZTWO
            //83 - 440; Abisynia; ; ; Karsin; kościerski; pomorskie


            //var woj = unitOfWork.FindObject<Voivodeship>(new BinaryOperator("Name", csv[6]));
            var woj = unitOfWork.Query<Voivodeship>().Where(v => v.Name == csv[6]).FirstOrDefault();
            if (woj == null)
            {
                woj = new Voivodeship(unitOfWork);
                woj.Name = csv[6].Truncate(100);
                woj.Save();
              unitOfWork.CommitChanges();
            }

            //var pow = unitOfWork.FindObject<County>(new BinaryOperator("Name", csv[5]));
            var pow = unitOfWork.Query<County>().Where(v => v.Name == csv[5]).FirstOrDefault();
            if (pow == null)
            {
                pow = new County(unitOfWork);
                pow.Name = csv[5].Truncate(100);
                pow.Voivodeship = woj;
               pow.Save();
                unitOfWork.CommitChanges();
            }

            //var gmi = unitOfWork.FindObject<Commune>(new BinaryOperator("Name", csv[4]));
            var gmi = unitOfWork.Query<Commune>().Where(v => v.Name == csv[4]).FirstOrDefault();
            if (gmi == null)
            {
                gmi = new Commune(unitOfWork);
                gmi.Name = csv[4].Truncate(100);
                //gmi.Wojewodztwo = woj;
                gmi.County = pow;
               gmi.Save();
                unitOfWork.CommitChanges();

            }
            //rec.Wojewodztwo = woj;
           // rec.Powiat = pow;
            rec.Commune = gmi;
            
    
            rec.Save();

            //  Console.WriteLine($"   {rec.value1}");
            if (rowCnt % 10000 == 0)
            {
                Console.WriteLine($"recs: {rowCnt} Execution Time: {watch.ElapsedMilliseconds} ms");
                unitOfWork.CommitChanges();
                unitOfWork.Dispose();
                unitOfWork = null;



                Console.WriteLine($"After commit Execution Time: {watch.ElapsedMilliseconds} ms");
                //Console.ReadLine();
                watch.Restart();

            }
        }

    }
}
