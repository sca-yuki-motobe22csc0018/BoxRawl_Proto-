using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoControllerEnemy : MonoBehaviour
{
    float spawnTimer;
    public float spawnTime;
    public int playStageNum;
    public GameObject[] playSpawnPoint;
    public GameObject[] SpawnPoint01;
    public GameObject[] SpawnPoint02;
    public GameObject[] SpawnPoint03;
    public GameObject[] SpawnPoint04;
    public GameObject[] SpawnPoint05;
    public GameObject[] SpawnPoint06;
    public GameObject[] SpawnPoint07;
    public GameObject[] SpawnPoint08;
    public GameObject[] SpawnPoint09;

    // Start is called before the first frame update
    void Start()
    {
        playStageNum = StageSelect.selectNumber;
        if (playStageNum == 0)
        {
            playStageNum = 9;
        }
        for (int i = 0; i < 10; i++)
        {
            if (playStageNum == 1)
            {
                playSpawnPoint[i] = SpawnPoint01[i];
            }else
            if (playStageNum == 2)
            {
                playSpawnPoint[i] = SpawnPoint02[i];
            }else
            if (playStageNum == 3)
            {
                playSpawnPoint[i] = SpawnPoint03[i];
            }else
            if (playStageNum == 4)
            {
                playSpawnPoint[i] = SpawnPoint04[i];
            }else
            if (playStageNum == 5)
            {
                playSpawnPoint[i] = SpawnPoint05[i];
            }else
            if (playStageNum == 6)
            {
                playSpawnPoint[i] = SpawnPoint06[i];
            }else
            if (playStageNum == 7)
            {
                playSpawnPoint[i] = SpawnPoint07[i];
            }else
            if (playStageNum == 8)
            {
                playSpawnPoint[i] = SpawnPoint08[i];
            }
            
        }
        for (int i = 0; i < 25; i++)
        {
            if (playStageNum == 9)
            {
                playSpawnPoint[i] = SpawnPoint09[i];
            }
        }
        if (playStageNum > 4 && playStageNum < 9)
        {
            spawnTime *= 1.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.PlayerDead)
        {
            return;
        }
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnTime)
        {
            if (playStageNum < 4 ||playStageNum==9)
            {
                int random = Random.Range(0, 23);
                if (random < 2)
                {
                    SpawnDraw0();
                }
                else
                if (random < 5)
                {
                    SpawnDraw1();
                }
                else
                if (random < 8)
                {
                    SpawnDraw2();
                }
                else
                if (random < 11)
                {
                    SpawnDraw3();
                }
                else
                if (random < 14)
                {
                    SpawnDraw4();
                }
                else
                if (random < 17)
                {
                    SpawnDraw5();
                }
                else
                if (random < 20)
                {
                    SpawnDrawFly();
                }
                else
                {
                    SpawnDrawAll();
                }
            }
            if(playStageNum==4)
            {
                int random = Random.Range(0, 20);
                if (random < 2)
                {
                    SpawnDrawFly();
                }else
                if (random < 15)
                {
                    SpawnDraw1();
                }
                else
                {
                    SpawnDraw1();
                    SpawnDraw1();
                }
            }
            if (playStageNum == 5)
            {
                int random = Random.Range(0, 23);
                if (random < 2)
                {
                    SpawnDraw0();
                }
                else
                if (random < 5)
                {
                    SpawnDraw1();
                }
                else
                if (random < 8)
                {
                    SpawnDraw2();
                }
                else
                if (random < 11)
                {
                    SpawnDraw3();
                }
                else
                if (random < 14)
                {
                    SpawnDraw4();
                }
                else
                if (random < 17)
                {
                    SpawnDraw5();
                }
                else
                if (random < 20)
                {
                    SpawnDrawFly();
                }
                else
                {
                    SpawnDrawAll();
                }
            }
            if (playStageNum == 6)
            {
                int random = Random.Range(0, 23);
                if (random < 9)
                {
                    SpawnDraw3();
                }
                else
                if (random < 18)
                {
                    SpawnDraw4();
                }
                else
                {
                    SpawnDrawFly();
                }
            }
            if (playStageNum == 7)
            {
                int random = Random.Range(0, 23);
                if (random < 6)
                {
                    SpawnDraw2();
                }
                else
                if (random < 12)
                {
                    SpawnDraw3();
                }
                else
                {
                    SpawnDraw0();
                }
            }
            if (playStageNum == 8)
            {
                int random = Random.Range(0, 23);
                if (random < 2)
                {
                    SpawnDraw0();
                }
                else
                if (random < 5)
                {
                    SpawnDraw1();
                }
                else
                if (random < 8)
                {
                    SpawnDraw2();
                }
                else
                if (random < 11)
                {
                    SpawnDraw3();
                }
                else
                if (random < 14)
                {
                    SpawnDraw4();
                }
                else
                if (random < 17)
                {
                    SpawnDraw5();
                }
                else
                if (random < 20)
                {
                    SpawnDrawFly();
                }
                else
                {
                    SpawnDrawAll();
                }
            }
            if (playStageNum == 9)
            {
                int random = Random.Range(0, 33);
                if (random < 5)
                {
                    SpawnDrawStage9_0();
                }else
                    if (random < 10)
                {
                    SpawnDrawStage9_1();
                }else
                    if (random < 15)
                {
                    SpawnDrawStage9_2();
                }else if (random < 20)
                {
                    SpawnDrawStage9_3();
                }else if (random < 25)
                {
                    SpawnDrawStage9_4();
                }else if (random < 30)
                {
                    SpawnDrawStage9_5();
                }
                else
                {
                    SpawnDrawStage9_All();
                    Debug.Log("SpawnAll!");
                }
            }
            spawnTimer = 0;
        }
    }
    private void ObjectEnemy0(float x, float y)
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("BetaFlogEnemy");
        GameObject Enemy = Instantiate(Enemy_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }
    private void ObjectEnemy1(float x, float y)
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("BetaBullEnemy");
        GameObject Enemy = Instantiate(Enemy_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }
    private void ObjectEnemy2(float x, float y)
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("BetaTurtleEnemy");
        GameObject Enemy = Instantiate(Enemy_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }
    private void ObjectEnemy3(float x, float y)
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("BetaMomongaEnemy");
        GameObject Enemy = Instantiate(Enemy_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }
    private void ObjectEnemy4(float x, float y)
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("BetaBeeEnemy");
        GameObject Enemy = Instantiate(Enemy_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }
    private void ObjectEnemy5(float x, float y)
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("BetaMoleEnemy");
        GameObject Enemy = Instantiate(Enemy_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }
    void SpawnDraw0()
    {
        int rand=Random.Range(0, 10);
        ObjectEnemy0(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
    }
    void SpawnDraw1()
    {
        int rand = Random.Range(0, 10);
        ObjectEnemy1(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
    }
    void SpawnDraw2()
    {
        int rand = Random.Range(0, 10);
        ObjectEnemy2(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
    }
    void SpawnDraw3()
    {
        int rand = Random.Range(0, 10);
        ObjectEnemy3(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
    }
    void SpawnDraw4()
    {
        int rand = Random.Range(0, 10);
        ObjectEnemy4(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
    }
    void SpawnDraw5()
    {
        int rand = Random.Range(0, 10);
        ObjectEnemy5(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
    }
    void SpawnDrawFly()
    {
        int rand = Random.Range(0, 10);
        ObjectEnemy3(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
        ObjectEnemy4(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
        ObjectEnemy3(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
        ObjectEnemy4(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
    }
    void SpawnDrawAll()
    {
        SpawnDraw0();
        SpawnDraw1();
        SpawnDraw2();
        SpawnDraw3();
        SpawnDraw4();
        SpawnDraw5();
    }
    void SpawnDrawStage9_0()
    {
        for(int i = 0; i < 2; i++)
        {
            int rand = Random.Range(0, 25);
            if (rand < 10 || rand > 15)
            {
                ObjectEnemy0(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
            }
        }
        
    }
    void SpawnDrawStage9_1()
    {
        for (int i = 0; i < 2; i++)
        {
            int rand = Random.Range(0, 25);
            if (rand < 10 || rand > 15)
            {
                ObjectEnemy1(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
            }
        }
    }

    void SpawnDrawStage9_2()
    {
        for (int i = 0; i < 2; i++)
        {
            int rand = Random.Range(0, 25);
            if (rand < 10 || rand > 15)
            {
                ObjectEnemy2(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
            }
        }
    }
    void SpawnDrawStage9_3()
    {
        for (int i = 0; i < 2; i++)
        {
            int rand = Random.Range(0, 25);
            ObjectEnemy3(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
        }
    }
    void SpawnDrawStage9_4()
    {
        for (int i = 0; i < 2; i++)
        {
            int rand = Random.Range(0, 25);
            ObjectEnemy4(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
        }
    }
    void SpawnDrawStage9_5()
    {
        for (int i = 0; i < 2; i++)
        {
            int rand = Random.Range(0, 25);
            if (rand < 10 || rand > 15)
            {
                ObjectEnemy5(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
            }
        }
    }
    void SpawnDrawStage9_All()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnDrawStage9_0();
            SpawnDrawStage9_1();
            SpawnDrawStage9_2();
            SpawnDrawStage9_3();
            SpawnDrawStage9_4();
            SpawnDrawStage9_3();
            SpawnDrawStage9_4();
            SpawnDrawStage9_5();
        }
    }
}
