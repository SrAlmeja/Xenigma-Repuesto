using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AlmejaCode/Variables/Int")]
public class IntVariable : ScriptableObject
{
    public string DeveloperDescription;
    public float Value;

    public void SetValue(float value)
    {
        Value = value;
    }
}