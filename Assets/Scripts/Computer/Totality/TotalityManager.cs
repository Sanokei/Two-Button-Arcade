using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RightClickMenuManager))]
public abstract class TotalityManager : MonoBehaviour
{
    RightClickMenuManager RightClickMenuManager;

    void Start()
    {
        gameObject.GetComponent<RightClickMenuManager>();
    }
}
