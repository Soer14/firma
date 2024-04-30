using NUnit.Framework;
using System.Text;


namespace TestZ
{

    class Prgram
    {

        [Test]
        private static void Main()
        {
            double testPercentage = 85.5;
            string grade = CalculateGrade(testPercentage);
            Console.WriteLine($"Ocena za test: {grade}");
        }
        [Test]
        private static string CalculateGrade(double percentage)
        {
            if (percentage >= 90)
                return "A";
            else if (percentage >= 80)
                return "B";
            else if (percentage >= 70)
                return "C";
            else if (percentage >= 60)
                return "D";
            else
                return "F";
        }
    }

}



















