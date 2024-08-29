using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayBurst : MonoBehaviour
{
    VideoPlayer player;
    [SerializeField] float timer;
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        timer = (float)player.clockTime;
        player.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
