namespace Core;

class Trapesium : BaseBangunDatar
{
    private double sisi1, sisi2, sisi3, sisi4;

    private double pair;

    private bool searchPair()
    {
        double[] allSets = { sisi1, sisi2, sisi3, sisi4 };

        var groups = allSets.GroupBy(v => v);

        double currentItem = 0;

        foreach (var group in groups)
            if (group.Count() == 2) currentItem = group.Key;

        if (currentItem != 0)
        {
            this.pair = currentItem;
            return true;
        }

        return false;
    }

    public override double handler(string type)
    {
        this.cli.typeSatisfier(type);

        this.sisi1 = this.cli.toDouble().ask("Berapa sisi ke-1? ", Convert.ToString(10));
        this.sisi2 = this.cli.toDouble().ask("Berapa sisi ke-2? ", Convert.ToString(this.sisi1));
        this.sisi3 = this.cli.toDouble().ask("Berapa sisi ke-3? ", Convert.ToString(this.sisi2));
        this.sisi4 = this.cli.toDouble().ask("Berapa sisi ke-4? ", Convert.ToString(this.sisi3));

        bool pair = this.searchPair();

        if (!pair)
        {
            Console.WriteLine("Tidak ditemukan sisi yang sama. Mengulang Pertanyaan.");
            this.handler(type);
            return 0;
        }

        if (type == BangunDatar.LUAS)
        {
            return this.luas();
        }

        return this.keliling();
    }

    public double luas()
    {
        double tinggi = this.cli.toDouble().ask("Berapa tingginya? ", Convert.ToString(10));
        return 0.5 * (this.pair * 2) * tinggi;
    }

    public double keliling()
    {
        return this.sisi1 + this.sisi2 + this.sisi3 + this.sisi4;
    }
}