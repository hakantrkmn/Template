using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "PriceHolder", menuName = "ScriptableObjects/PriceHolder_ScriptableObject", order = 3)]
public class PriceHolder : ScriptableObject
{
    [BoxGroup("Prices And Values")] public List<PriceHolderStruct> priceValues = new List<PriceHolderStruct>();

    public void Add(string _name)
    {
        priceValues.Add(new PriceHolderStruct(_name, 5, 10));
    }

    public void Remove()
    {
        priceValues.RemoveAt(priceValues.Count - 1);
    }
}
