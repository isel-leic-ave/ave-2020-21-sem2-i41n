using System.Collections;

internal class ConvertEnumerable : IEnumerable
{
    private IEnumerable src;
    private FunctionDelegate mapper;

    public ConvertEnumerable(IEnumerable src, FunctionDelegate mapper)
    {
        this.src = src;
        this.mapper = mapper;
    }

    public IEnumerator GetEnumerator()
    {
        return new ConvertEnumerator(src.GetEnumerator(), mapper);
    }
}
internal class ConvertEnumerator : IEnumerator
{
    private IEnumerator src;
    private FunctionDelegate mapper;

    public ConvertEnumerator(IEnumerator enumerator, FunctionDelegate mapper)
    {
        this.src = enumerator;
        this.mapper = mapper;
    }

    public object Current {
        get {
            return mapper(src.Current);
        }
    }

    public bool MoveNext()
    {
        return src.MoveNext();
    }

    public void Reset()
    {
        src.Reset();
    }
}