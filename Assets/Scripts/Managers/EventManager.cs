using System;
using UnityEngine;


public static class EventManager
{
    #region LevelManagerEvents
    public static Action StartLevel;
    public static Action OpenNextLevel;
    public static Action RestartLevel;
    public static Action SwitchPauseLevel;
    #endregion

    #region GameManagerEvents
    public static Action SetWin;
    public static Action SetLose;
    public static Action OnGameStarted;
    public static Action OnGameCompleted;
    public static Func<bool> IsGameStarted;
    public static Func<bool> IsGameCompleted;
    #endregion

    #region PlayerControllerEvents
    public static Action SwitchPlayerCanControl;
    public static Action SwitchPlayerCanSway;
    #endregion

    #region InputSystem
    public static Func<Vector2> GetInput;
    public static Func<Vector2> GetInputDelta;
    public static Action InputStarted;
    public static Action InputEnded;
    public static Func<bool> IsTouching;
    public static Func<bool> IsPointerOverUI;
    #endregion

    #region UI
    public static Action<float> ChangeProgressBarFillAmount;
    public static Action ResetProgressData;
    #endregion

    #region PlayerAnimation
    public static Action<AnimationType, float> SetAnimation;
    #endregion

 


}