using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DiologData/Diolog")]
public class DiologDataScriptable : ScriptableObject
{
    public List<Message> messages;
}
