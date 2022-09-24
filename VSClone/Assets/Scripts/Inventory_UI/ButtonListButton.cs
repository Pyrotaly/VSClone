using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;

    public void SetText(string textString)
    {
        buttonText.text = textString;
    }

    public void OnClick()
    {

    }
}
