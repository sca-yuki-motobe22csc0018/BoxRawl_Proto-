using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainAttack : MonoBehaviour
{
    public static bool canChain;
    public static int  chainLv=3;
    [SerializeField] private ParticleSystem particles;
    public static ParticleSystem insParticle;


    private void Start()
    {
        chainLv=3;
        insParticle=particles;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            canChain = true;
        }
        if(canChain)
        {
           
            canChain = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(PlayerMove.Drop)
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                Instantiate(particles, this.gameObject.transform.position, Quaternion.identity);
            }
        }
    }

}
