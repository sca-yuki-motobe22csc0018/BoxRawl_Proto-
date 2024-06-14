using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHit : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            EXPController.EXP += 5.0f * PlayerMove.EXPUP;
            PlayerMove.EXPUP += 1;
            Destroy(other.gameObject);
        }
        else
        {
        }
    }
}
