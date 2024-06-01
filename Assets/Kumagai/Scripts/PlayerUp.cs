using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerUp : MonoBehaviour
{
    //���̃X�N���v�g�̓v���C���[�̋�������(�X�L��?)�Ɋւ���X�N���v�g�ł�
    // Start is called before the first frame update
    void Start()
    {
        setBarrier = true;
        playerGetBarrier = false;
    }

    // Update is called once per frame
    void Update()
    {
        Barrier();
        tmpSetBarrier=setBarrier;
    }

    private float barrierCoolTime=10;
    private float barrierTimer=0;
    public static bool setBarrier;
    public static bool playerGetBarrier;
    [SerializeField] bool tmpSetBarrier;

    private void Barrier()
    {
        if(playerGetBarrier)
        {
            if(!setBarrier)
            {
                barrierTimer += Time.deltaTime;
                if(barrierTimer>barrierCoolTime)
                {
                    setBarrier=true;
                    barrierTimer = 0;
                }
            }
        }
    }
}
