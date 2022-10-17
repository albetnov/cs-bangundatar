namespace Core;

abstract class BaseBangunDatar
{
    protected CliHelper cli;
    public BaseBangunDatar()
    {
        this.cli = new CliHelper();
    }
    abstract public double handler(string type);
}
