using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetDiscriptionIcon : MonoBehaviour
{
    [SerializeField] private GameObject skin;
    [SerializeField] private GameObject icon;
    [SerializeField] private Sprite[] types;
    [SerializeField] private GameObject speed;
    [SerializeField] private GameObject jump;
    [SerializeField] private GameObject hp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((PlayerTypeSelect.selectNumber<4))
        {
            icon.SetActive(true);
            skin.GetComponent<SpriteRenderer>().sprite = types[PlayerTypeSelect.selectNumber];
        }
        else
        {
            icon.SetActive(false);
        }
        switch(PlayerTypeSelect.selectNumber) 
        {
            case 0:
                {
                    TypeDataSet(1, 1, 1);
                }
                break;
            case 1:
                {
                    TypeDataSet(1, 0, 2);
                }
                break;
            case 2:
                {
                    TypeDataSet(2, 1, 0);
                }
                break;
            case 3:
                {
                    TypeDataSet(0,2,1);
                }
                break;
        }
    }

    void TypeDataSet(int s,int j,int h)
    {
        for(int i=0;i<3;i++)
        {
            if(i==s)
            {
                speed.transform.GetChild(i).gameObject.SetActive(true);
            }
            else 
            {
                speed.transform.GetChild(i).gameObject.SetActive(false);
            }
            if(i==j)
            {
                jump.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                jump.transform.GetChild(i).gameObject.SetActive(false);
            }
            if (i == h)
            {
                hp.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                hp.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
