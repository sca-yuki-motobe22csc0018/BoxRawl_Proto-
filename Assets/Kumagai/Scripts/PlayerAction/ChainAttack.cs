using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainAttack : MonoBehaviour
{
    public static bool canChain;
    public static int  chainLv;
    [SerializeField] private ParticleSystem particles;
    public static ParticleSystem insParticle;


    private void Start()
    {
        chainLv=0;
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
            Instantiate(particles, this.gameObject.transform.position, Quaternion.identity);
            canChain = false;
        }
    }

}
