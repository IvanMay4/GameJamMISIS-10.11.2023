using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenInteract : MonoBehaviour
{
    public GameObject uiObject;

    private void Start()
    {
        uiObject.SetActive(false);
    }

    void ShowScreen()
    {
        uiObject.SetActive(true);
    }

    
}
