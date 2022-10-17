namespace Core;
class Persegi : BaseBangunDatar
{
    private double sisi;
    public override double handler(string type)
    {
        this.cli.typeSatisfier(type);

        this.sisi = this.cli.toDouble().ask("Berapa sisi dari persegi anda? ", Convert.ToString(10));

        if (type == BangunDatar.LUAS)
        {
            return this.luas();
        }

        return this.keliling();
    }
    public double luas()
    {
        return this.sisi * this.sisi;
    }

    public double keliling()
    {
        return 4 * this.sisi;
    }
}