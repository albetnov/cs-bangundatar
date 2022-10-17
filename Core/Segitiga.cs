namespace Core;

class Segitiga : BaseBangunDatar
{
    public double luas(double alas, double tinggi)
    {
        return (1 / 2) * alas * tinggi;
    }

    public double keliling(double sisi1, double sisi2, double sisi3)
    {
        return sisi1 + sisi2 + sisi3;
    }

    public override double handler(string type)
    {
        throw new NotImplementedException();
    }
}