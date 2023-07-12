using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AlmejaCode/Variables/Int")]
public class IntVariable : ScriptableObject
{
    public string DeveloperDescription;
    public int Value;

    public void SetValue(int value)
    {
        Value = value;
    }
}