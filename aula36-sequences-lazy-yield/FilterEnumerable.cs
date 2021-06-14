using System.Collections;

internal class FilterEnumerable : IEnumerable
{
    private IEnumerable src;
    private PredicateDelegate pred;

    public FilterEnumerable(IEnumerable src, PredicateDelegate pred)
    {
        this.src = src;
        this.pred = pred;
    }

    public IEnumerator GetEnumerator()
    {
        return new FilterEnumerator(src.GetEnumerator(), pred);
    }
}

internal class FilterEnumerator : IEnumerator
{
    private IEnumerator src;
    private PredicateDelegate pred;

    public FilterEnumerator(IEnumerator enumerator, PredicateDelegate pred)
    {
        this.src = enumerator;
        this.pred = pred;
    }

    public object Current
    {
        get
        {
            return src.Current;
        }
    }

    public bool MoveNext()
    {
        bool result = false;
        do
        {
            result = src.MoveNext();
        } while (result == true && !pred(Current));
        return result;
    }

    public void Reset()
    {
        src.Reset();
    }
}