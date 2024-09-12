using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceBlinking : MonoBehaviour
{
    [SerializeField] private float firstWaitTime;
    [SerializeField] private float secondWaitTime;
    [SerializeField] private float thirdWaitTime;
    [SerializeField] private float fourthWaitTime;
    [SerializeField] private float fiveWaitTime;
    private SpriteRenderer Space;
    // Start is called before the first frame update
    void Start()
    {
        Space=GetComponent<SpriteRenderer>();
        StartCoroutine(blin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator blin()
    {
        while (true)
        {
            yield return new WaitForSeconds(firstWaitTime);
            Space.color = new Color(1,1,1,1);
            yield return new WaitForSeconds(secondWaitTime);
            Space.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(thirdWaitTime);
            Space.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(fourthWaitTime);
            Space.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(fiveWaitTime);
            Space.color = new Color(1, 1, 1, 1);


        }
       


    }
}
