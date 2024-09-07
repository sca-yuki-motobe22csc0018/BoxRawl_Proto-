using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWaveDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(thisDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator thisDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
