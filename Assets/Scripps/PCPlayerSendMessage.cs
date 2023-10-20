using Microsoft.MixedReality.Toolkit.Experimental.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.XR;

public class PCPlayerSendMessage : MonoBehaviour
{
    public ShowKeyboard showKeyboard;
    public TMP_InputField InputField;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            showKeyboard = GameObject.Find("InputField (TMP)2314215").GetComponent<ShowKeyboard>();
            showKeyboard.SendMessageServerRpc(InputField.text);
        }
    }

}
