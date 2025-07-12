public interface IInputManager
{
    public bool IsForward();
    public bool IsBackward();
    public bool IsLeft();
    public bool IsRight();
    public bool IsJump();
    public bool IsJumpStart();
    public bool IsSpawnSupport();
    public bool IsSlow();
    public void SendEvent(string eventName);
}
