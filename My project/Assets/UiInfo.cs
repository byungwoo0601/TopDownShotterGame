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
        curHp.text = "체력 : " + GameManager.Instance.playerController.hp;
        curAtkDmg.text = "공격력 : " + GameManager.Instance.attack.playerAtkDmg;
    }
}
