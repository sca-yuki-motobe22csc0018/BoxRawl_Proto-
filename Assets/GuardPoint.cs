using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPoint : MonoBehaviour
{
    public GameObject p;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(p.transform.position.x-0.9f,p.transform.position.y+0.9f,0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heal"))
        {
            PlayerMove.heal = true;
        }
        if (collision.gameObject.CompareTag("Guard"))
        {
            PlayerMove.barrier = true;
        }
    }
}
