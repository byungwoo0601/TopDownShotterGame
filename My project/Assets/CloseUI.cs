using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour
{
    public GameObject uiObj;

    private void OnMouseDown()
    {
        uiObj.SetActive(false);
    }

    public void CloseUi()
    {
        uiObj.SetActive(false);
    }
}
