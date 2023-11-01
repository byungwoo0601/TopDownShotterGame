using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiInfo : MonoBehaviour
{

    public Text stage;
    public int _stage = 1;

    public Text curHp;
    public Text curAtkDmg;

    public Text triangle;
    public Text square;

    float time;
    private void Update()
    {
        time += Time.deltaTime;
        if (time > 1.5)
        {
            time = 0;
            CurPlayerInfo();
        }
    }

    public void CurPlayerInfo()
    {
        curHp.text = "체력 : " + GameManager.Instance.playerController.hp;
        curAtkDmg.text = "공격력 : " + GameManager.Instance.attack.playerAtkDmg;
    }

    public void CurStageInfo()
    {
        stage.text = "Stage " + _stage;
    }
}
