using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDiscriptionIcon : MonoBehaviour
{
    [SerializeField] private GameObject skin;
    [SerializeField] private GameObject icon;
    [SerializeField] private Sprite[] types;

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
     
    }
}
