using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiInfo : MonoBehaviour
{

    public Text curHp;
    public Text curAtkDmg;

    public Text triangle;
    public Text square;

    private void Awake()
    {
        CurPlayerInfo();
    }

    private void Start()
    {

    }

    void CurPlayerInfo()
    {
        curHp.text = "ü�� : " + GameManager.Instance.playerController.hp;
        curAtkDmg.text = "���ݷ� : " + GameManager.Instance.attack.playerAtkDmg;
    }
}
