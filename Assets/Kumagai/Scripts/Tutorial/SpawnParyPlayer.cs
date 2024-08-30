using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParyPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawner()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(player, this.transform.position, Quaternion.identity);
        }
    }
}
