using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;

public class MobileInputManager : IInputManager
{
    private MobileJoysticksCanvas _canvas;
    
    public MobileInputManager(DiContainer container, InputConfig config)
    {
        _canvas = container.InstantiatePrefabForComponent<MobileJoysticksCanvas>(config.MobileJoysticksCanvas);
    }

    public bool IsForward() => _canvas.IsForward();

    public bool IsBackward() => _canvas.IsBackward();

    public bool IsLeft() => _canvas.IsLeft();

    public bool IsRight() => _canvas.IsRight();

    public bool IsJump() => false;

    public bool IsJumpStart() => false;

    public bool IsSpawnSupport() => _canvas.IsSpawnSupport();

    public bool IsSlow() => _canvas.IsSlow();

    public bool IsWatchAd() => _canvas.IsWatchAd();

    public void SendEvent(string eventName) => _canvas.SendEvent(eventName);
}
