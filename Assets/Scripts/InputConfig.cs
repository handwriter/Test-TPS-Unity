using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Input/InputConfig", fileName = "Input Config")]
public class InputConfig : ScriptableObject
{
    [Header("MOBILE")] public GameObject MobileJoysticksCanvas;
}
