using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChildren : MonoBehaviour
{
    public GameObject Pary;
    void Update()
    {
        Pary.transform.position = transform.position;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (PlayerMove.PlayerDead)
        {
            return;
        }
        if (other.gameObject.CompareTag("Drop"))
        {
            Trigger.EnemyTrigger = false;
            this.gameObject.transform.parent = null;
            EXPController.EXP += 2.0f * PlayerMove.EXPUP;
            PlayerMove.EXPUP += 1;
            ScoreManager.smallEnemyKillCount++;
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("DestroyObj"))
        {
            Destroy(this);
        }
    }
}
