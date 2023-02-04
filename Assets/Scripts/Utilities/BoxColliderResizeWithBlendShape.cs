using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;


[RequireComponent(typeof(BoxCollider))]
public class BoxColliderResizeWithBlendShape : MonoBehaviour
{
    [Serializable]
    private class Data
    {
        [Range(0, 100)]
        public int percentage;
        public Vector3 center, size;

        public Data(Vector3 center, Vector3 size)
        {
            this.center = center;
            this.size = size;
        }
    }


    [SerializeField] List<Data> spectrum;
    [SerializeField] SkinnedMeshRenderer sMRenderer;
    [SerializeField] bool setFirstDataAtStart;



    //---------------------------------------------------------------------------------
    private void SetData(Data data)
    {
        BoxCollider col = GetComponent<BoxCollider>();
        col.center = data.center;
        col.size = data.size;
    }


    //---------------------------------------------------------------------------------
    [Button(Style = ButtonStyle.Box, Expanded = true)]
    private void PreviewData(int index)
    {
        if (spectrum.Count > index)
            SetData(spectrum[index]);
        else
            Debug.LogError("Out of range!");
    }


    //---------------------------------------------------------------------------------
    [Button(Style = ButtonStyle.CompactBox)]
    private void AddRecentData()
    {
        BoxCollider col = GetComponent<BoxCollider>();
        spectrum.Add(new Data(col.center, col.size));
    }


    //---------------------------------------------------------------------------------
    private void Start()
    {
        if (spectrum.Count > 0 && setFirstDataAtStart)
            PreviewData(0);
    }



    //---------------------------------------------------------------------------------
    [Button("Preview Based Blend Shape", Style = ButtonStyle.FoldoutButton)]
    private void FixedUpdate()
    {
        if (sMRenderer)
        {
            float value = sMRenderer.GetBlendShapeWeight(0);
            int minI = 0, maxI = spectrum.Count - 1;

            //Min
            for (int i = 0; i < spectrum.Count; i++)
                if (spectrum[i].percentage < (int)value && spectrum[minI].percentage < spectrum[i].percentage)
                    minI = i;
            //Max
            for (int i = spectrum.Count - 1; i >= 0; i--)
                if (spectrum[i].percentage > (int)value && spectrum[maxI].percentage > spectrum[i].percentage)
                    maxI = i;

            int difPer = spectrum[maxI].percentage - spectrum[minI].percentage;
            Data newData = new Data(
                spectrum[minI].center + (((spectrum[maxI].center - spectrum[minI].center) / difPer) * (value - spectrum[minI].percentage)),
                spectrum[minI].size + (((spectrum[maxI].size - spectrum[minI].size) / difPer) * (value - spectrum[minI].percentage))
                );
            SetData(newData);
        }
    }



}
