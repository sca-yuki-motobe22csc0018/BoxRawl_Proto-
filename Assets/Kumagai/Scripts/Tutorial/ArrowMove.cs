using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{

    private float y;
    private float x;
    private float time;
    [SerializeField] private GameObject enemy;
    private SpriteRenderer spriteRenderer;
    private float alpha;
    [SerializeField]private float upPositionY;
    // Start is called before the first frame update
    void Start()
    {
        y = this.transform.position.y;
        time = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.activeSelf)
        {
            y = Mathf.Sin(time);
            time += Time.deltaTime;
            this.transform.position = new Vector3(this.transform.position.x, y + upPositionY, this.transform.position.z);
        }
        else if(alpha>0)
        {
            spriteRenderer.color = new Color(1, 1, 1, alpha);
            alpha -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
