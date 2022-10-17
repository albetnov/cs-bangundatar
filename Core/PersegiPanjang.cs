namespace Core;
class PersegiPanjang : BaseBangunDatar
{
    private double panjang, lebar;
    public override double handler(string type)
    {
        this.cli.typeSatisfier(type);

        this.panjang = this.cli.toDouble().ask("Jumlah panjang? ", Convert.ToString(10));
        this.lebar = this.cli.toDouble().ask("Jumlah lebar? (default: sama dengan panjang): ", Convert.ToString(this.panjang));

        if (type == BangunDatar.LUAS)
        {
            return this.luas();
        }
        return this.keliling();
    }
    public double luas()
    {
        return this.cli.sum(this.panjang, this.lebar);
    }

    public double keliling()
    {
        return this.cli.plusDoubleSum(this.panjang, this.lebar);
    }
}
