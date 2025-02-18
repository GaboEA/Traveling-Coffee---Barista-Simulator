using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
public class ShowKeyboard : MonoBehaviour
{

    //For the Position of the KeyBoard
    public float distance = 0.5f;
    public float verticalOffset = -0.5f;
    public Transform positionSource;

    [SerializeField] private TMP_Text textDisplayTable;
    [SerializeField] private TMP_InputField inputText;
    private bool keyboardOpen;
    public void DisplayKeyBoard()
    {
        keyboardOpen = true;
        inputText.onValueChanged.AddListener(UpdateText);
        NonNativeKeyboard.Instance.PresentKeyboard();

        Vector3 direction = positionSource.forward;
        direction.y = 0;
        direction.Normalize();

        Vector3 targetPosition = positionSource.position + direction * distance + Vector3.up * verticalOffset;

        NonNativeKeyboard.Instance.RepositionKeyboard(targetPosition);
    }

    public void SaveComment()
    {
       textDisplayTable.text = inputText.text;
       RemoveLeakEvent();
    }

    public void RemoveLeakEvent()
    {
        keyboardOpen = false;
        inputText.onValueChanged.RemoveListener(UpdateText);
    }
    void UpdateText(string inputText)
    {
        if (keyboardOpen) textDisplayTable.text = inputText;
    }
}
