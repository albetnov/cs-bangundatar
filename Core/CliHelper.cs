namespace Core;

class CliHelper
{
    private bool setAsDouble = false;
    public CliHelper toDouble()
    {
        this.setAsDouble = true;
        return this;
    }

    public CliHelper disableToDouble()
    {
        this.setAsDouble = false;
        return this;
    }

    public dynamic ask(string question, string userDefault = "")
    {
        Console.Write(question);
        string? answer = Console.ReadLine();

        string finalAnswer = answer == "" || answer == null ? userDefault : answer;

        if (finalAnswer == userDefault)
        {
            Console.WriteLine("Menggunakan nilai default {0}", userDefault);
        }


        if (this.setAsDouble)
        {
            return Convert.ToDouble(finalAnswer);
        }

        return finalAnswer;
    }

    public bool typeSatisfier(string type)
    {
        if (type != BangunDatar.LUAS && type != BangunDatar.KELILING)
        {
            Console.WriteLine("Tipe mu invalid mas.");
            System.Environment.Exit(1);
            return false;
        }
        return true;
    }

    public double sum(double angka1, double angka2)
    {
        return angka1 * angka2;
    }

    public double plusDoubleSum(double angka1, double angka2)
    {
        return 2 * (angka1 + angka2);
    }

}