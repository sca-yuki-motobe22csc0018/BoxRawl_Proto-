using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoControllerEnemy : MonoBehaviour
{
    float spawnTimer;
    private float speed = 2;
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
    
    // Start is called before the first frame update
    void Start()
    {
        playStageNum = StageSelect.selectNumber;
        if (playStageNum == 0)
        {
            playStageNum = 2;
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
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > 2)
        {
            int random = Random.Range(0, 15);
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
                SpawnDrawAll();
            }
            spawnTimer = 0;
        }
    }
    private void ObjectEnemy(float x, float y)
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("EnemyProto");
        GameObject Enemy = Instantiate(Enemy_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }
    private void ObjectEnemy1(float x, float y)
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("EnemyProto1");
        GameObject Enemy = Instantiate(Enemy_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }
    private void ObjectEnemy2(float x, float y)
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("EnemyProto2");
        GameObject Enemy = Instantiate(Enemy_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }
    private void ObjectEnemy3(float x, float y)
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("EnemyProto3");
        GameObject Enemy = Instantiate(Enemy_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }
    void SpawnDraw0()
    {
        int rand=Random.Range(0, 10);
        ObjectEnemy(playSpawnPoint[rand].transform.position.x, playSpawnPoint[rand].transform.position.y);
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
    void SpawnDrawAll()
    {
        SpawnDraw0();
        SpawnDraw1();
        SpawnDraw2();
        SpawnDraw3();
    }
}
