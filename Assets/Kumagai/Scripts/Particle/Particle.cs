using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private float count=0;
    private ParticleSystem _particles;
    private ParticleSystem.Burst _burst;
    [SerializeField]private List<ParticleCollisionEvent> particleEvents;
    public static int particleCount;
    // Start is called before the first frame update
    void Start()
    {
       
        count = 0;
        _particles = GetComponent<ParticleSystem>();
        _burst = _particles.emission.GetBurst(0);
        _burst.count = ChainAttack.chainLv+3;
        _particles.emission.SetBurst(0, _burst);
        particleEvents= new List<ParticleCollisionEvent>();

    }

    private void OnEnable()
    {
        _burst.count =10;
    }
    // Update is called once per frame
    void Update()
    {
        if(count>1) { Destroy(this.gameObject); }
        count += Time.deltaTime;
       

        //_emission = _particle.emission;
        //_emission.burstCount= particleCount;   
    }
    
    private void OnParticleCollision(GameObject other)
    {
            Debug.Log("a");
            if (other.gameObject.CompareTag("Enemy"))
            {
                EXPController.EXP += 5.0f * PlayerMove.EXPUP;
                PlayerMove.EXPUP += 1;
                if (ChainAttack.chainLv >= 3)
                {
                    Instantiate(ChainAttack.insParticle, other.gameObject.transform.position, Quaternion.identity);
                    this.gameObject.tag = "Drop";
                }
                else if(other.GetComponent<EnemyChildren>()!=null)
                {
                    ScoreManager.smallEnemyKillCount++;
                    Debug.Log("エネミーキルカウントを加算しました");
                }
                else
                {
                    ScoreManager.bigEnemyKillCount++;
                }
                Destroy(other.gameObject);
            }
            else
            {
            }
        
    }
}
