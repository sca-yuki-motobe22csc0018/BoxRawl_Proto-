using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float spawnTimer;
    private GameObject player;
    private float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        SpawnDraw();
        SpawnDraw2();
        player=GameObject.Find("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > 3)
        {
            int random = Random.Range(0, 10);
            if (random <2)
            {
                SpawnDraw();
            }else
            if (random <5)
            {
                SpawnDraw2();
            }else
            if (random < 8)
            {
                SpawnDraw3();
            }
            else
            if (random < 10)
            {
                SpawnDraw4();
            }
            spawnTimer = 0;
        }
    }

    private void ObjectEnemy(float x, float y)
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("Enemy");
        GameObject Enemy = Instantiate(Enemy_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }

    void SpawnDraw()
    {
        ObjectEnemy(25, 13);
    }
    void SpawnDraw2()
    {
        ObjectEnemy(-25, 13);
    }
    void SpawnDraw3()
    {
        ObjectEnemy(0, 13);
    }
    void SpawnDraw4()
    {
        ObjectEnemy(0, 13);
        ObjectEnemy(25, 13);
        ObjectEnemy(-25, 13);
    }
}
