using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using System;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class ShowKeyboard : NetworkBehaviour
{
    private TMP_InputField InputField;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        InputField = GetComponent<TMP_InputField>();
        InputField.onSelect.AddListener(x => OpenKeyBoard());
        NonNativeKeyboard.Instance.OnTextSubmitted += TextSubmittedEventHandler;

    }
    public void OpenKeyBoard()
    {
        NonNativeKeyboard.Instance.InputField = InputField;
        NonNativeKeyboard.Instance.PresentKeyboard(InputField.text);
    }


    void TextSubmittedEventHandler(object sender, EventArgs e)
    {
        Debug.Log("test1");
        SendMessageServerRpc(InputField.text);
    }

    [ServerRpc(RequireOwnership = false)]
    public void SendMessageServerRpc(string message)
    {
        Debug.Log("test2");
        HandleMessageClientRpc(message);
    }

    [ClientRpc]
    public void HandleMessageClientRpc(string message)
    {
        Debug.Log("test3");
        text.text += "\n" + message;
        Debug.Log(message);
    }

}
