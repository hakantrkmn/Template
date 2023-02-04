using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "PlayerMovementSettings", menuName = "ScriptableObjects/Player Movement Settings", order = 2)]
public class PlayerMovementSettings : ScriptableObject
{
    [BoxGroup("Speeds")]
    public float forwardSpeed;
    [BoxGroup("Speeds")]
    public float horizontalSpeed;
    [BoxGroup("Speeds")]
    public float swaySpeed;
    [BoxGroup("Speeds")]
    public float animationSpeed;
    [BoxGroup("Speeds")]
    [Range(0f, 0.99f)]
    public float horizontalDamping;


    [BoxGroup("Clamp")]
    public bool isClamped;

    [BoxGroup("Clamp"), ShowIf("isClamped")]
    public float defaultMinXClampValue;

    [BoxGroup("Clamp"), ShowIf("isClamped")]
    public float defaultMaxXClampValue;

    [BoxGroup("Clamp"), ShowIf("isClamped")]
    public float defaultMinZClampValue;

    [BoxGroup("Clamp"), ShowIf("isClamped")]
    public float defaultMaxZClampValue;

    [HideInInspector] public float minXClampValue;
    [HideInInspector] public float maxXClampValue;
}
