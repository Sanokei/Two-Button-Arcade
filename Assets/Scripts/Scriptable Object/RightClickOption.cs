using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

using BuildingBlocks.DataTypes;

[System.Serializable]
[CreateAssetMenu (menuName = "RightClickMenu Option")]
public class RightClickOption : ScriptableObject
{   
    // Action button would take
    public UnityEvent<RightClickOption> Event;

}
