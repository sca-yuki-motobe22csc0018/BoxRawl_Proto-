using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpArrow : MonoBehaviour
{
    // Start is called before the first frame update
    private float y;
    private float x;
    private float time;
    //private SpriteRenderer spriteRenderer;
    //private float alpha;
    [SerializeField] private float addPositionX;
    private Vector3 startPos;
    Matrix4x4 mat;
    // Start is called before the first frame update
    void Start()
    {
        y = this.transform.position.y;
        x = this.transform.position.x;
        time = 0;
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //alpha = 1;
        startPos = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        mat = Matrix4x4.Rotate(this.transform.rotation);
        y =Mathf.Sin(time);  
            time += Time.deltaTime*3;
            this.transform.localPosition =mat* new Vector3(x, y, 0);
       
    }
}
