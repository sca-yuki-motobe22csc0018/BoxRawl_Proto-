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
            Debug.Log("ìGÇ∆è’ìÀÇµÇ‹ÇµÇΩ");
        }
        else
        {
            Debug.Log("è’ìÀÇµÇ‹ÇµÇΩ");
        }
    }
}
