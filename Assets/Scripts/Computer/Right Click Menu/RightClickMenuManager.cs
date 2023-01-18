using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

using TMPro;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

using BuildingBlocks.DataTypes;

public class RightClickMenuManager : MonoBehaviour, IPointerClickHandler
{
    // Every Right Click Menu should have a corresponding RightClickOptionMenu
    [HideInInspector] public RightClickOptionMenu Instantiated_RightClickOptionMenu;
    
    // Top two Combine + instantiated reference
    [HideInInspector] public InspectableDictionary<GameObject, Func<bool>> Instantiated_Buttons;

    [SerializeField] List<RightClickOption> Buttons;

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        // if the mouse button clicked was right click
        if((int)eventData.button == 1)
        {
            // Creating the box that will have the buttons and get the option menu component
            RightClickMenu ircm = Instantiate(Resources.Load<RightClickMenu>("Prefabs/RightClickMenu/RightClickMenu"), transform);
            if(ircm.TryGetComponent<RightClickOptionMenu>(out Instantiated_RightClickOptionMenu))
                Debug.LogError($"No RightClickOption Menu for coresponding {ircm.GetType().ToString()}");

            // Now injecting button manually
                // Combining Button List and Delegates into one local var
                // the way var works and such is way too clever
                // var Buttons = ButtonList.Zip(ButtonDelegates, (go,d) => new {GameObject = go, Delegate = d});

            // Gets every combine button and creates a list of instantiated and delegates 
            // I could have done the combining in any order
            foreach(var button in Buttons)
            {
                GameObject option = Instantiate(Resources.Load<GameObject>("Prefabs/RightClickMenu/Option"), ircm.transform);
                option.GetComponent<RightClickOptionMenu>().Create(button);
                // Instantiated_Buttons.Add(option, button.Delegate);
            }
        }
    }
}
