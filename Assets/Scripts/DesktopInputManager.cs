using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;

public class DesktopInputManager : IInputManager
{
    private DesktopInputCanvas _canvas;
    public DesktopInputManager(DiContainer container, InputConfig config)
    {
        _canvas = container.InstantiatePrefabForComponent<DesktopInputCanvas>(config.DesktopInputCanvas);
    }
    
    public bool IsBackward() => Input.GetKey(KeyCode.S);

    public bool IsForward() => Input.GetKey(KeyCode.W);

    public bool IsJump() => Input.GetKey(KeyCode.Space);

    public bool IsJumpStart() => Input.GetKeyDown(KeyCode.Space);

    public bool IsLeft() => Input.GetKey(KeyCode.A);

    public bool IsRight() => Input.GetKey(KeyCode.D);

    public bool IsSpawnSupport() => Input.GetKeyDown(KeyCode.T);
    
    public bool IsSlow() => Input.GetKey(KeyCode.LeftShift);
    
    public bool IsWatchAd() => Input.GetKeyDown(KeyCode.Y);
    
    public void SendEvent(string eventName) => _canvas.SendEvent(eventName);
}
