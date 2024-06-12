using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesOrChack : MonoBehaviour
{

    [SerializeField] private GameObject selector;
    [SerializeField] private GameObject yesObj;
    [SerializeField] private GameObject noObj;
    [SerializeField] private GameObject player;
    public static bool retYes;
    // Start is called before the first frame update
    void Start()
    {
        Yes = false;
        retYes = false;
    }

    public static bool Yes;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Yes)
            {
                ButtonManager.yesOrNo = "Yes";
            }
            else
            {
                ButtonManager.yesOrNo = "No";
                this.gameObject.SetActive(false);
            }
           
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            Yes = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Yes = true;
        }
        if (yesObj.transform.position.x > selector.transform.position.x && Yes)
        {
           selector.transform.position += new Vector3(75f * Time.deltaTime, 0, 0);
        }
        if (noObj.transform.position.x < selector.transform.position.x && !Yes)
        {
            selector.transform.position += new Vector3(-75f * Time.deltaTime, 0, 0);
        }

    }
}
