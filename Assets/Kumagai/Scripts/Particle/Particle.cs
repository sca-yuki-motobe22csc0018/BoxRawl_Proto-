using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private float count=0;
    private ParticleSystem _particles;
    private ParticleSystem.Burst _burst;
    [SerializeField]private List<ParticleCollisionEvent> particleEvents;
    [SerializeField] private int particleCount;
    // Start is called before the first frame update
    void Start()
    {
       
        count = 0;
        _particles = GetComponent<ParticleSystem>();
        _burst = _particles.emission.GetBurst(0);
        _burst.count = particleCount;
        _particles.emission.SetBurst(0, _burst);
        particleEvents= new List<ParticleCollisionEvent>();

    }

    // Update is called once per frame
    void Update()
    {
        if(count>1) { Destroy(this.gameObject); }
        count += Time.deltaTime;
        if(ChainAttack.chainLv>=2)
        {
            _burst.count = particleCount*1.3f;
        }

        //_emission = _particle.emission;
        //_emission.burstCount= particleCount;   
    }
    
    private void OnParticleCollision(GameObject other)
    {
            Debug.Log("a");
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log(other.gameObject.transform.position);
                EXPController.EXP += 5.0f * PlayerMove.EXPUP;
                PlayerMove.EXPUP += 1;
                if (ChainAttack.chainLv >= 3)
                {
                    Destroy(other.gameObject);
                    Instantiate(ChainAttack.insParticle, other.gameObject.transform.position, Quaternion.identity);
                }
                Destroy(other.gameObject);
            }
            else
            {
            }
        
    }
}
