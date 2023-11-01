using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiInfo : MonoBehaviour
{

    public Text stage;
    public Text curHp;
    public Text curAtkDmg;

    public Text triangle;
    public Text square;

    public int triangleCount = 0;
    public int squareCount = 0;

    private void Update()
    {
        CurPlayerInfo();
        CurMonsterCount();
    }

    public void CurPlayerInfo()
    {
        curHp.text = "체력 : " + GameManager.Instance.playerController.hp + "/5";
        curAtkDmg.text = "공격력 : " + GameManager.Instance.attack.playerAtkDmg;
    }

    public void CurMonsterCount()
    {
        triangle.text = triangleCount.ToString();
        square.text = squareCount.ToString();
    }

}
