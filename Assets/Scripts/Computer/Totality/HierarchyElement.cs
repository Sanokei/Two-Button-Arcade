using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HierarchyElement : MonoBehaviour
{
    [SerializeField] TMP_InputField _input;
    [SerializeField] TextMeshProUGUI _text;

    public void OnEnable()
    {
        _input.ActivateInputField();
        _input.Select();
    }
    public void OnEndEdit(string eventdata)
    {   
        _input.gameObject.SetActive(false);
        _input.text = "";
        _text.text = eventdata.Replace(" ", "") != "" ? eventdata : "GameObject";
    }
}
