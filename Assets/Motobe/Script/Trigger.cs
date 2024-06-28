using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public static bool EnemyTrigger;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        EnemyTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Player.transform.position;    
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyTrigger = false;
        }
    }
}
