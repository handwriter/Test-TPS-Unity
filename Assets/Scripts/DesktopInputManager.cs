using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopInputManager : IInputManager
{
    public DesktopInputManager() {
        Debug.Log("INT");
    }
    public bool IsBackward() => Input.GetKey(KeyCode.S);

    public bool IsForward() => Input.GetKey(KeyCode.W);

    public bool IsJump() => Input.GetKey(KeyCode.Space);

    public bool IsJumpStart() => Input.GetKeyDown(KeyCode.Space);

    public bool IsLeft() => Input.GetKey(KeyCode.A);

    public bool IsRight() => Input.GetKey(KeyCode.D);

    public bool IsSpawnSupport() => Input.GetKeyDown(KeyCode.T);
}
