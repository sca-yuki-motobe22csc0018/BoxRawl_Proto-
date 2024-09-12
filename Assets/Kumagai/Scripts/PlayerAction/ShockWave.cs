using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    public static int dropShockWaveLv;
    public static int wallShockWaveLv;
    [SerializeField]private GameObject shockWave;
    [SerializeField]private bool wallFirst;
    [SerializeField]private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        wallFirst = true;
        dropShockWaveLv = 0;    
        wallShockWaveLv=0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(wallShockWaveLv);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            wallFirst = false;
            if (dropShockWaveLv>0)
            {
                if (PlayerMove.Drop)
                {
                    Instantiate(shockWave, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity, canvas.transform);
                    Debug.Log("ShockWave");
                }
            }
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            if(wallShockWaveLv>0)
            {
                if (wallFirst)
                {
                    if (transform.position.x - collision.transform.position.x > 0)
                    {
                        Debug.Log("shockWave");
                        Instantiate(shockWave, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, -90), canvas.transform);
                        wallFirst = false;
                    }
                    if (transform.position.x - collision.transform.position.x < 0)
                    {
                        Debug.Log("shockWave");
                        Instantiate(shockWave, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 90), canvas.transform);
                        wallFirst = false;
                    }
                }
            }
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            wallFirst = true;
        }
    }
}
