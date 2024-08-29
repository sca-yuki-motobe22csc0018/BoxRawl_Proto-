using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Video;

public class EnemyBurst : MonoBehaviour
{
    [SerializeField] private VideoPlayer enemyBurst;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(enemyBurst, collision.gameObject.transform.position, Quaternion.identity);
        }
    }
}
