using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusInfo : MonoBehaviour
{
    public GameObject StatPanel;

    private void OnMouseDown()
    {
        StatPanel.SetActive(true);
    }
}
