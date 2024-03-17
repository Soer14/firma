// See https://aka.ms/new-console-template for more information
using ApplicationCommon;
using Common.Module.Imports;

Console.WriteLine("Rozpoczeto import kodów pocztowych!");
var watch = new System.Diagnostics.Stopwatch();

watch.Start();

var Importer = new KodyPocztoweImporter(ApplicationSettings.ConnectionString);
Importer.Import("c:\\UTF8KodyPocztowe\\spispna-cz1.txt");

watch.Stop();

Console.WriteLine($"Complete Execution Time: {watch.ElapsedMilliseconds} ms");

Console.ReadLine();
