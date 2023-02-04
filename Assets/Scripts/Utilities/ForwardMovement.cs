using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    [SerializeField] PlayerMovementSettings playerSettings;
    private bool isMoveStraight = true;

    [SerializeField] private bool canControl;


    //---------------------------------------------------------------------------------
    private void OnEnable()
    {
        EventManager.StartLevel += SwitchCanControl;
        EventManager.SwitchPlayerCanControl += SwitchCanControl;
        EventManager.SetWin += SwitchCanControl;
    }
    private void OnDisable()
    {
        EventManager.StartLevel -= SwitchCanControl;
        EventManager.SwitchPlayerCanControl -= SwitchCanControl;
        EventManager.SetWin -= SwitchCanControl;
    }


    //---------------------------------------------------------------------------------
    void Update()
    {
        if (!canControl)
            return;

        if (isMoveStraight)
            transform.position += new Vector3(0f, 0f, playerSettings.forwardSpeed * Time.deltaTime);
    }


    //---------------------------------------------------------------------------------
    private void SwitchCanControl()
    {
        canControl = !canControl;
    }
}
