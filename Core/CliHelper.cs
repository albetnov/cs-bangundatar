namespace Core;

class CliHelper
{
    private bool setAsDouble = false;
    public CliHelper toDouble()
    {
        this.setAsDouble = true;
        return this;
    }

    public dynamic ask(string question, string userDefault = "")
    {
        Console.Write(question);
        string? answer = Console.ReadLine();

        string finalAnswer = answer ?? userDefault;

        if (this.setAsDouble)
        {
            Console.WriteLine("Menggunakan nilai default: {0}", finalAnswer);
            return Convert.ToDouble(finalAnswer);
        }

        return finalAnswer;
    }

    public bool typeSatisfier(string type)
    {
        if (type != BangunDatar.LUAS || type != BangunDatar.KELILING)
        {
            Console.WriteLine("Invalid type");
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