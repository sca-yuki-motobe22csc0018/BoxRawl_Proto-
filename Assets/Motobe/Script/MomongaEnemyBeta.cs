using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomongaEnemyBeta : MonoBehaviour
{
    GameObject PlayerObj;

    Vector3 scale;

    public GameObject GoObject;
    public GameObject Pary;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        scale = transform.localScale;
        GoObject.transform.position = PlayerObj.transform.position;
        GoObject.transform.parent = null;
        Pary.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerMove.PlayerDead)
        {
            if (Vector2.Distance(transform.position, new Vector2(GoObject.transform.position.x, GoObject.transform.position.y)) < 0.1f)
            {
                GoObject.transform.position = PlayerObj.transform.position;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(GoObject.transform.position.x, GoObject.transform.position.y), 5 * Time.deltaTime);
            }
            if (GoObject.transform.position.x >= this.transform.position.x)
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
        if (scale.x == 1)
        {
            Pary.transform.position = new Vector3(this.transform.position.x-0.075f,this.transform.position.y-0.05f,0);
        }
        else
        {
            Pary.transform.position = new Vector3(this.transform.position.x + 0.075f, this.transform.position.y - 0.05f, 0);
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
