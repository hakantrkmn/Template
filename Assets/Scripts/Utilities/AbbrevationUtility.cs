using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public static class AbbrevationUtility
{
    private static readonly SortedDictionary<long, string> abbrevations = new SortedDictionary<long, string>
     {
         {1000,"K"},
         {1000000, "M" },
         {1000000000, "B" },
         {1000000000000,"T"}
     };

    public static string AbbreviateNumber(float number)
    {
        for (int i = abbrevations.Count - 1; i >= 0; i--)
        {
            KeyValuePair<long, string> pair = abbrevations.ElementAt(i);
            if (Mathf.Abs(number) >= pair.Key)
            {
                if (number % 1000 != 0)
                    return "$" + string.Format("{0:0.0}", (number / pair.Key)) + pair.Value;
                else
                    return "$" + string.Format("{0:0}", (number / pair.Key)) + pair.Value;
            }
        }

        return "$" + string.Format("{0:0}", (number));

    }
}