using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour
{
    public GameObject uiObj;

    private void OnMouseDown()
    {
        Time.timeScale = 1.0f;

        uiObj.SetActive(false);
    }

    public void CloseUi()
    {
        Time.timeScale = 1.0f;
        uiObj.SetActive(false);
    }
}
