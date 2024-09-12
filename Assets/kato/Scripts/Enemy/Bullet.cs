using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ñIÇ™îÚÇŒÇ∑íeÇÃèàóù
/// </summary>
public class Bullet : MonoBehaviour
{
    public GameObject pary;
    // Start is called before the first frame update
    void Start()
    {
        if (pary.gameObject != null)
        {
            pary.transform.parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pary.gameObject == null)
        {
            Destroy(this.gameObject);
        }
        if (pary.gameObject != null)
        {
            pary.transform.position = this.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"
            || collision.gameObject.tag == "Ground"
            || collision.gameObject.tag == "Wall"
            || collision.gameObject.tag == "Ceiling")
        {
            Destroy(pary.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Drop")
        {
            Destroy(pary.gameObject);
        }
    }
}
