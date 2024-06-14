using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private float count=0;
    private ParticleSystem _particles;
    private ParticleSystem.Burst _burst;
    [SerializeField] private int particleCount;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        _particles = GetComponent<ParticleSystem>();
        _burst = _particles.emission.GetBurst(0);
        _burst.count = particleCount;
        _particles.emission.SetBurst(0, _burst);

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(count>3) { Destroy(this.gameObject); }
        count += Time.deltaTime;
        _emission = _particle.emission;
        _emission.burstCount= particleCount;   
    }*/
    }
}
