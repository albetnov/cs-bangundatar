namespace Core;

class Segitiga : BaseBangunDatar
{
    private double alas, tinggi;
    public override double handler(string type)
    {
        this.cli.typeSatisfier(type);

        this.alas = this.cli.toDouble().ask("Berapa lebar alas (Sisi Bawah sisi ke-1) ? ", Convert.ToString(10));
        this.tinggi = this.cli.toDouble().ask("Berapa tingginya? ", Convert.ToString(10));

        if (type == BangunDatar.LUAS)
        {
            return this.luas();
        }

        return this.keliling();
    }
    public double luas()
    {
        return 0.5 * this.alas * this.tinggi;
    }

    public double keliling()
    {
        double sisi2 = this.cli.toDouble().ask("Berapa panjang sisi ke-2 ? ", Convert.ToString(this.alas));
        double sisi3 = this.cli.toDouble().ask("Berapa panjang sisi ke-3 ? ", Convert.ToString(sisi2));
        return this.alas + sisi2 + sisi3;
    }


}