using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetismController : MonoBehaviour
{
    [SerializeField] private float power;
    [SerializeField] private float timer;

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Vector3 dir = this.transform.position - collision.gameObject.transform.position;
            dir=dir.normalized;
            collision.gameObject.transform.position += dir * Time.deltaTime*power;
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
        yield return null;
    }
}
