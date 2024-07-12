using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomongaEnemyBeta : MonoBehaviour
{
    GameObject PlayerObj;

    Vector3 GoPosition;

    Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerMove.PlayerDead)
        {
            if (Vector2.Distance(transform.position, new Vector2(PlayerObj.transform.position.x, PlayerObj.transform.position.y)) < 0.1f)
            {

            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(PlayerObj.transform.position.x, PlayerObj.transform.position.y), 5 * Time.deltaTime);
            }
            if (PlayerObj.transform.position.x >= this.transform.position.x)
            {
                scale.x = 1;
                transform.localScale = scale;
            }
            else
            {
                scale.x = -1;
                transform.localScale = scale;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Drop"))
        {
            EXPController.EXP += 8.0f * PlayerMove.EXPUP;
            PlayerMove.EXPUP += 1;
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("DestroyObj"))
        {
            Destroy(this.gameObject);
        }
    }
}
