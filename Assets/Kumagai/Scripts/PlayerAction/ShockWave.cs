using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    private int dropShockWaveLv;
    [SerializeField]private GameObject shockWaveCollider;
    [SerializeField]private GameObject shockWave;
    [SerializeField]private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        dropShockWaveLv = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if(PlayerMove.Drop)
            {
                shockWaveCollider.SetActive(true);
                Instantiate(shockWave,new Vector3(transform.position.x,transform.position.y+0.4f,transform.position.z),Quaternion.identity,canvas.transform);
                Debug.Log("ShockWave");
            }
        }
    }
}
