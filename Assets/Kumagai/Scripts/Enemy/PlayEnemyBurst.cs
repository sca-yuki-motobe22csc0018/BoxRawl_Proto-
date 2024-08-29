using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayEnemyBurst : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] VideoPlayer player;
    [SerializeField]float timer;
    void Start()
    {
        timer = (float)player.clockTime;
        player.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
