using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovementSettings playerSettings;
    [SerializeField] private bool canControl;
    [SerializeField] private bool canSway;
    [ShowIf("canSway")]
    [SerializeField] private Transform swayTarget;

    private float _xGoal;



  
    private void Start()
    {
        _xGoal = transform.position.x;
        playerSettings.minXClampValue = playerSettings.defaultMinXClampValue;
        playerSettings.maxXClampValue = playerSettings.defaultMaxXClampValue;
    }


    //---------------------------------------------------------------------------------
    private void Update()
    {
        if (canControl == false)
            return;

        _xGoal += EventManager.GetInputDelta().x * playerSettings.horizontalSpeed;
        _xGoal = Mathf.Clamp(_xGoal, playerSettings.minXClampValue, playerSettings.maxXClampValue);

        if (playerSettings.horizontalDamping < float.Epsilon)
            transform.position = new Vector3(_xGoal, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, _xGoal, (1f - playerSettings.horizontalDamping) * Time.deltaTime * 30f), transform.position.y, transform.position.z);
    }


    //---------------------------------------------------------------------------------
    private void LateUpdate()
    {
        if (canControl == false)
            return;

        if (canSway)
        {
            var targetRot = 0f;
            if (EventManager.IsTouching())
            {
                targetRot = EventManager.GetInputDelta().x * playerSettings.swaySpeed * 30;
            }
            else
            {
                targetRot = 0f;
            }

            // var rotation = swayTarget.transform.rotation;
            // rotation = Quaternion.Lerp(rotation, Quaternion.Euler(rotation.x, 
            // 	Mathf.Clamp(targetRot, -40, 40), rotation.z), Time.deltaTime * 10);
            // swayTarget.transform.rotation = rotation;

            swayTarget.DOLocalRotate(new Vector3(0, Mathf.Clamp(targetRot, -40, 40), 0), 0.5f).SetId<Tween>("Sway");
        }
    }


    //---------------------------------------------------------------------------------
    private void SwitchCanControl()
    {
        canControl = !canControl;
        _xGoal = transform.position.x;
    }


    //---------------------------------------------------------------------------------
    private void SwitchCanSway()
    {
        canSway = !canSway;
    }
}
