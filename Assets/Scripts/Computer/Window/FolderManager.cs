using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FolderManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Inventory inventory;
    
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            // Create Physical Representation of Window
            WindowMaker window = Instantiate(Resources.Load($"Computer/Window/CodeEditor") as WindowMaker, transform.parent);
        }
    }
}
