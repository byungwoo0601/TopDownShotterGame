using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{

    public void UpgradeHp()
    {
        if (UIManager.Instance.uiInfo.triangleCount >= 8 && GameManager.Instance.playerController.hp < 5)
        {
            UIManager.Instance.uiInfo.triangleCount -= 8;

            GameManager.Instance.playerController.hp += 1;
        }
    }

    public void UpgradeAttack()
    {
        if (UIManager.Instance.uiInfo.squareCount >= 5)
        {
            UIManager.Instance.uiInfo.squareCount -= 5;

            GameManager.Instance.attack.playerAtkDmg += 1;
        }
    }

}
