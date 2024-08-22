using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagnetismManager : MonoBehaviour
{
    [SerializeField] private float power;
    private float timer = 1;
    [SerializeField] private GameObject player;

    private void OnEnable()
    {
        transform.position=player.transform.position;
        timer = 1;
    }

    private void Update()
    {
        timer-=Time.deltaTime;
        this.gameObject.SetActive(timer > 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            Vector3 dir = this.transform.position - collision.gameObject.transform.position;
            rb.AddForce(dir.normalized * Time.deltaTime * power);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
