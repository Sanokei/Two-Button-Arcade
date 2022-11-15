using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HierarchyManager : TotalityManager
{
    public void CreateHierarchyElement(Transform eventdata)
    {
        Instantiate(Resources.Load<GameObject>("Resources/Prefabs/Totality/HierarchyElement.prefab"), eventdata);
    }
}
