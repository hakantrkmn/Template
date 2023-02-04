using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraFollowTween : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float lerpSpeed = 3f;
    [SerializeField] Ease ease;

    private float xOffset;
    private float yOffset;
    private float zOffset;
    private Sequence seq;



    //---------------------------------------------------------------------------------
    private void Start()
    {
        xOffset = target.position.x - transform.position.x;
        yOffset = transform.position.y - target.position.y;
        zOffset = target.position.z - transform.position.z;
    }


    //---------------------------------------------------------------------------------
    private void Update()
    {
        Vector3 pos = transform.position;
        pos = new Vector3(target.position.x - xOffset, pos.y, pos.z);
        pos = new Vector3(pos.x, target.position.y + yOffset, target.position.z - zOffset);
        seq.Append(transform.DOMove(pos, lerpSpeed).SetEase(ease));
    }
}
