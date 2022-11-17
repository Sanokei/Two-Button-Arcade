using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using TMPro;

public class RightClickOptionMenu : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] TextMeshProUGUI _text;

    public void OnEnable()
    {
        // var option = Sanject.Instance.CurrentOptionButton;
        // _text.text = option;
        // _button.onClick.AddListener(() => {option.Event?.Invoke(option);} );
    }
}
