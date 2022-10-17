namespace Core;

class JajarGenjang : BaseBangunDatar
{
    private double alas, tinggi;
    public override double handler(string type)
    {
        this.cli.typeSatisfier(type);

        this.alas = this.cli.toDouble().ask("Jumlah alas? ", Convert.ToString(10));
        this.tinggi = this.cli.toDouble().ask("Jumlah tinggi? (default: sama dengan alas): ", Convert.ToString(this.alas));

        if (type == BangunDatar.LUAS)
        {
            return this.luas();
        }
        return this.keliling();
    }

    public double luas()
    {
        return this.cli.sum(this.alas, this.tinggi);
    }

    public double keliling()
    {
        return this.cli.plusDoubleSum(this.alas, this.tinggi);
    }
}