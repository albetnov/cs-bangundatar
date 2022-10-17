namespace Core;

class Trapesium : BaseBangunDatar
{
    private double tinggi;
    private double sisi1, sisi2, sisi3, sisi4;
    public override double handler(string type)
    {
        this.cli.typeSatisfier(type);

        this.tinggi = this.cli.toDouble().ask("Jumlah tinggi? ");
        this.sisi1 = this.cli.toDouble().ask("Jumlah sisi ke-1? ");
        this.sisi2 = this.cli.toDouble().ask("Jumlah sisi ke-2? (Default: Sama dengan sisi ke-2) ", Convert.ToString(this.sisi2));
        this.sisi3 = this.cli.toDouble().ask("Jumlah sisi ke-3? (Default: Sama dengan sisi ke-3) ", Convert.ToString(this.sisi3));
        this.sisi4 = this.cli.toDouble().ask("Jumlah sisi ke-4? (Default: Sama dengan sisi ke-4) ", Convert.ToString(this.sisi4));

        if (type == BangunDatar.LUAS)
        {
            return this.luas();
        }
        return this.keliling();
    }
    public double luas()
    {
        return (1 / 2) * (sisi1 + sisi2) * this.tinggi;
    }

    public double keliling()
    {
        return this.sisi1 + this.sisi2 + this.sisi3 + this.sisi4;
    }
}