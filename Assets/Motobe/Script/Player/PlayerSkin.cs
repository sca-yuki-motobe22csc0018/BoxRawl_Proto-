using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    public static bool Rota;
    public static int rota;
    public float speed;
    public bool startRota;
    // Start is called before the first frame update
    void Start()
    {
        rota = -1;
        Rota = true;
        //speed = 750f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.PlayerDead)
        {
            return;
        }
        if (Rota)
        {
            
            if (startRota&&rota==0)
            {
                transform.Rotate(0, 0, speed * -1 * Time.deltaTime);
            }
            else
            {
                transform.Rotate(0, 0, speed * rota * Time.deltaTime);
            }
        }
        if (!Rota)
        {
            if (startRota)
            {
                transform.Rotate(0, 0, speed * -1 * Time.deltaTime);
            }
            else
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
        
    }
}
