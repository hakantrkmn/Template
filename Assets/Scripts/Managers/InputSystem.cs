using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;


public class InputSystem : MonoBehaviour
{

    [HideInInspector] public Vector2 dir;
    [HideInInspector] public Vector2 deltaDir;
    [HideInInspector] public bool isTouchDown;
    [HideInInspector] public bool isTouchUp;
    [HideInInspector] public bool isTouching;
    [HideInInspector] public bool isPointerOverUI;
    public InputType inputType;

    public float dirMaxMagnitude = float.PositiveInfinity;
    public float dirMultiplier = 10;

    private Vector2 dirOld;
    private const int NO_TOUCH = -1;
    private int touchId;
    private Vector2 joystickCenterPos;
    private bool touchControls;



    //---------------------------------------------------------------------------------
    private void Awake()
    {
        touchId = NO_TOUCH;
        touchControls = Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android;
    }


    //---------------------------------------------------------------------------------
    private void OnEnable()
    {
        EventManager.GetInput = () => dir;
        EventManager.GetInputDelta = () => deltaDir;
        EventManager.IsTouching = () => isTouching;
        EventManager.IsPointerOverUI = () => isPointerOverUI;
    }


    //---------------------------------------------------------------------------------
    private void Start()
    {
    }


    //---------------------------------------------------------------------------------
    private void Update()
    {
        if (inputType == InputType.Touch)
            GetTouchInput();
        
    }


    //---------------------------------------------------------------------------------
    private void GetTouchInput()
    {
        int touchIdOld = touchId;
        dirOld = dir;

        //Is mobile device
        if (touchControls)
        {
            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        if (touchId == NO_TOUCH && !IsPointerOverUIObject(touch.fingerId))
                        {
                            touchId = touch.fingerId;
                            joystickCenterPos = touch.position;
                            EventManager.InputStarted?.Invoke();
                        }
                        break;
                    case TouchPhase.Canceled:
                    case TouchPhase.Ended:
                        touchId = NO_TOUCH;
                        EventManager.InputEnded?.Invoke();
                        break;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
            {
                touchId = 0;
                joystickCenterPos = Input.mousePosition;
                EventManager.InputStarted?.Invoke();
            }
            if (Input.GetMouseButtonUp(0))
            {
                touchId = NO_TOUCH;
                EventManager.InputEnded?.Invoke();
            }
        }

        if (touchId != NO_TOUCH)
        {
            float multiplier = dirMultiplier / Screen.width;
            Vector2 touchPos = GetTouchPos(touchId);
            dir = (touchPos - joystickCenterPos) * multiplier;
            float m = dir.magnitude;
            if (m > dirMaxMagnitude) dir = dir * dirMaxMagnitude / m;
            deltaDir = dir - dirOld;

        }
        else
        {
            dir = Vector2.zero;
            if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
            {
                dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                dir = dir.normalized * dirMaxMagnitude;
            }
            deltaDir = Vector2.zero;
        }

        isTouchDown = touchIdOld == NO_TOUCH && touchId != NO_TOUCH;
        isTouchUp = touchIdOld != NO_TOUCH && touchId == NO_TOUCH;
        isTouching = touchId != NO_TOUCH;
    }





    //---------------------------------------------------------------------------------
    private Vector2 GetTouchPos(int touchId)
    {
        if (touchControls)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId == touchId)
                {
                    return touch.position;
                }
            }
            return joystickCenterPos;
        }
        else
        {
            return Input.mousePosition;
        }
    }


    //---------------------------------------------------------------------------------
    public Vector2 GetTouchPos() => GetTouchPos(touchId);


    //---------------------------------------------------------------------------------
    public bool IsPointerOverUIObject(int touchId = 0)
    {
        isPointerOverUI = false;
        if (touchControls && EventSystem.current.IsPointerOverGameObject(touchId))
            isPointerOverUI = true;
        else if (EventSystem.current.IsPointerOverGameObject())
            isPointerOverUI = true;
        return isPointerOverUI;
    }


    //---------------------------------------------------------------------------------
    public enum InputType
    {
        Touch,
        Joystick
    }


    //---------------------------------------------------------------------------------
   
}
