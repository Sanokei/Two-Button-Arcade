using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerManager : MonoBehaviour
{
    public delegate void DeactivateInputField();
    public static event DeactivateInputField DeactivateInputFieldEvent;
    [SerializeField] PlayerMovement _playerMovement;
    public BoxCollider ComputerCollider;
    
    // FIXME: Flag variable. Bad practice.
    bool _computerMode = false;
    void OnEnable()
    {
        Eyes.OnRayCastHitEvent += OnComputerModeEvent;
    }
    void OnDisable()
    {
        Eyes.OnRayCastHitEvent -= OnComputerModeEvent;
    }

    // public void ShowDottedCircle(DottedCircleEventData eventData)
    // {
    //     if(eventData.hit.transform.tag == "Computer" && !_computerMode)
    //     {
    //         _DottedCircle.SetActive(true);
    //     }
    //     else
    //     {
    //         _DottedCircle.SetActive(false);
    //     }
    // }
    private void OnComputerModeEvent(RaycastHit hit)
    {
        // Fixed.
            // Warning: You have to be looking at the computer to leave it
            // This may cause errors later on.
        if( // yes I know this is gross but its for future readability.
            // if you not in computer mode and you are looking at the computer and click mouse 0 (Left click)
            (hit.transform.tag == "Computer" && !_computerMode && Input.GetMouseButtonDown(0))
            || // or
            // if you are in computer mode and you press escape
            (_computerMode && Input.GetKeyDown(KeyCode.Escape))
            )
        {	
            Debug.Log(!_computerMode ? "Hacker Mode" : "Normal Mode");
            _computerMode = !_computerMode;

            // Fix to deactivate the input field 
            // https://github.com/Sanokei/Programmed-Dystopia/issues/5
            if(!_computerMode && DeactivateInputFieldEvent != null)
                DeactivateInputFieldEvent();
            
            if(gameObject.activeSelf)
                // Disable the player's movement
                ChangeComputerMode();
        }
    }
    public void ChangeComputerMode(bool Override = false, bool OverrideBool = false)
    {
        _playerMovement.canMove = Override ? !OverrideBool : !_computerMode;
        StartCoroutine(Co_ChangeMouseState(Override ? OverrideBool : _computerMode)); // I dont remember why I made this a coroutine
    }

    private IEnumerator Co_ChangeMouseState(bool state)
    {
        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = state;
        yield break;
    }
}
