using System.Collections.Generic;

public static class DataStore
{
    private static readonly Dictionary<string, Dictionary<string, int>> dataSet = new()
    {
        { "SetA", new Dictionary<string, int> { { "One", 1 }, { "Two", 2 } } },
        { "SetB", new Dictionary<string, int> { { "Three", 3 }, { "Four", 4 } } },
        { "SetC", new Dictionary<string, int> { { "Five", 5 }, { "Six", 6 } } },
        { "SetD", new Dictionary<string, int> { { "Seven", 7 }, { "Eight", 8 } } },
        { "SetE", new Dictionary<string, int> { { "Nine", 9 }, { "Ten", 10 } } }
    };

    public static bool Lookup(string setKey, string subKey, out int count)
    {
        count = 0;
        if (dataSet.ContainsKey(setKey) && dataSet[setKey].ContainsKey(subKey))
        {
            count = dataSet[setKey][subKey];
            return true;
        }
        return false;
    }
}