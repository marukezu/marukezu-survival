using System;

public readonly struct LangEntry<TKey> where TKey : Enum
{
    public readonly TKey Key;
    public readonly string PT;
    public readonly string EN;

    public LangEntry(TKey key, string pt, string en)
    {
        Key = key;
        PT = pt;
        EN = en;
    }
}
