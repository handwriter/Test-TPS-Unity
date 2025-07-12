using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Input/InputConfig", fileName = "Input Config")]
public class InputConfig : ScriptableObject
{
    [Header("DESKTOP")] public GameObject DesktopInputCanvas;
    [Header("MOBILE")] public GameObject MobileJoysticksCanvas;
}
