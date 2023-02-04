using System;
using UnityEngine;

public class ClampedArea : MonoBehaviour
{
    public static Func<Vector2> GetArea;
    
    //---------------------------------------------------------------------------------
    private void OnEnable()
    {
        GetArea += GetSize;
    }
    private void OnDisable()
    {
        GetArea -= GetSize;

    }


    //---------------------------------------------------------------------------------
    private Vector2 GetSize() => new Vector2(transform.localScale.x / 2 * 10, transform.localScale.z / 2 * 10);


}
