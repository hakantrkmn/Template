using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class RandomTransformation : MonoBehaviour
{

    [BoxGroup("RandomMove", showLabel: false)]
    public bool randomMove;

    [BoxGroup("RandomMove"), ShowIf("randomMove")]
    public bool isAdditionalMove, isLocalMove;

    [BoxGroup("RandomMove"), ShowIf("randomMove"), MinMaxSlider(-20, 20, true)]
    public Vector2 xRange, yRange, zRange;



    [BoxGroup("RandomRotate", showLabel: false)]
    public bool randomRotate;

    [BoxGroup("RandomRotate"), ShowIf("randomRotate")]
    public bool isAdditionalRotate, isLocalRotate;

    [BoxGroup("RandomRotate"), ShowIf("randomRotate"), MinMaxSlider(-180, 180, true)]
    public Vector2 xRotateRange, yRotateRange, zRotateRange;



    [BoxGroup("RandomScale", showLabel: false)]
    public bool randomScale;

    [BoxGroup("RandomScale"), ShowIf("randomScale")]
    public bool isAdditionalScale;

    [BoxGroup("RandomScale"), ShowIf("randomScale"), MinMaxSlider(0, 10, true)]
    public Vector2 xScaleRange = new Vector2(1, 1), yScaleRange = new Vector2(1, 1), zScaleRange = new Vector2(1, 1);



    [Button("Randomize")]
    private void OnEnable()
    {
        //Random Move
        if (randomMove)
        {
            Vector3 randomPosition = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), Random.Range(zRange.x, zRange.y));

            if (isLocalMove)
                transform.localPosition = (isAdditionalMove ? transform.localPosition : Vector3.zero) + randomPosition;
            else
                transform.position = (isAdditionalMove ? transform.position : Vector3.zero) + randomPosition;
        }

        //Random Rotate
        if (randomRotate)
        {
            Vector3 randomRotation = new Vector3(Random.Range(xRotateRange.x, xRotateRange.y), Random.Range(yRotateRange.x, yRotateRange.y), Random.Range(zRotateRange.x, zRotateRange.y));

            if (isLocalMove)
                transform.localRotation = Quaternion.Euler((isAdditionalRotate ? transform.localRotation.eulerAngles : Vector3.zero) + randomRotation);
            else
                transform.rotation = Quaternion.Euler((isAdditionalRotate ? transform.rotation.eulerAngles : Vector3.zero) + randomRotation);
        }

        //Random Scale
        if (randomScale)
        {
            Vector3 randomScale = new Vector3(Random.Range(xScaleRange.x, xScaleRange.y), Random.Range(yScaleRange.x, yScaleRange.y), Random.Range(zScaleRange.x, zScaleRange.y));
            transform.localScale = (isAdditionalScale ? transform.localScale : Vector3.zero) + randomScale;
        }

    }

}
