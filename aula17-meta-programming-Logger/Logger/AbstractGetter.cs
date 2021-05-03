public abstract class AbstractGetter : IGetter
{
    private readonly string name;

    protected AbstractGetter(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public abstract object GetValue(object target);
}