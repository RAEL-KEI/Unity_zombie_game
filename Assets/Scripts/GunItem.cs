using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour, IItem
{
    public int gunId = 0;

    public void Use(GameObject target)
    {
        
        PlayerShooter playerShooter = target.GetComponent<PlayerShooter>();

        if (playerShooter != null)
        {
            playerShooter.gun[playerShooter.activated].gameObject.SetActive(false);
            playerShooter.activated = gunId;
            playerShooter.gun[gunId].gameObject.SetActive(true);
        }

        // ���Ǿ����Ƿ�, �ڽ��� �ı�
        Destroy(gameObject);
    }
}
