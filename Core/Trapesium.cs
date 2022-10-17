namespace Core;

class Trapesium : BaseBangunDatar
{
    private string type = BangunDatar.LUAS;
    private double tinggi;
    private bool pair = false;
    private double sisi1, sisi2, sisi3, sisi4;

    private bool checkForSame(double value)
    {
        if (this.sisi1 == value || this.sisi2 == value || this.sisi3 == value || this.sisi4 == value)
        {
            return true;
        }
        return false;
    }


    private void invalidPair()
    {
        Console.WriteLine("Invalid. sisi yang sama tidak boleh lebih dari 2.");
        this.pair = false;
        this.handler(this.type);
        return;
    }

    private void setPair(double value)
    {
        bool lookForPair = this.checkForSame(value);

        if (lookForPair)
        {
            if (this.pair)
            {
                this.invalidPair();
            }
            this.pair = true;
        }
    }


    private double getPair()
    {
        double[] allSets = { sisi1, sisi2, sisi3, sisi4 };

        var groups = allSets.GroupBy(v => v);

        double currentItem = 0;

        foreach (var group in groups)
            if (group.Count() == 2) currentItem = group.Key;

        return currentItem;
    }
    private void setSisi2(double value)
    {
        this.setPair(value);
        this.sisi2 = value;
    }

    private void setSisi3(double value)
    {
        this.setPair(value);
        this.sisi3 = value;
    }

    private void setSisi4(double value)
    {
        this.setPair(value);
        if (!this.pair)
        {
            Console.WriteLine("Tidak ada sisi yang sama. Mengulang pertanyaan.");
            this.handler(this.type);
            return;
        }
        this.sisi4 = value;
    }
    public override double handler(string type)
    {
        this.cli.typeSatisfier(type);
        this.type = type;

        this.tinggi = this.cli.toDouble().ask("Jumlah tinggi? ", Convert.ToString(10));
        this.sisi1 = this.cli.toDouble().ask("Jumlah sisi ke-1? ", Convert.ToString(10));
        this.setSisi2(this.cli.toDouble().ask("Jumlah sisi ke-2? (Default: Sama dengan sisi ke-2) ", Convert.ToString(this.sisi1)));
        this.setSisi3(this.cli.toDouble().ask("Jumlah sisi ke-3? (Default: Sama dengan sisi ke-3) ", Convert.ToString(this.sisi2)));
        this.setSisi4(this.cli.toDouble().ask("Jumlah sisi ke-4? (Default: Sama dengan sisi ke-4) ", Convert.ToString(this.sisi3)));

        if (type == BangunDatar.LUAS)
        {
            return this.luas();
        }
        return this.keliling();
    }
    public double luas()
    {
        return (1 / 2) * (this.getPair() + this.getPair()) * this.tinggi;
    }

    public double keliling()
    {
        return this.sisi1 + this.sisi2 + this.sisi3 + this.sisi4;
    }
}