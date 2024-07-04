using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChildren : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (PlayerMove.PlayerDead)
        {
            return;
        }
        if (other.gameObject.CompareTag("Drop"))
        {
            this.gameObject.transform.parent = null;
            EXPController.EXP += 1.0f * PlayerMove.EXPUP;
            PlayerMove.EXPUP += 1;
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("DestroyObj"))
        {
            Destroy(this);
        }
    }
}
