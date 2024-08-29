using UnityEngine;
using DG.Tweening;

public class MomongaEnemyBeta : MonoBehaviour
{
    GameObject PlayerObj;

    Vector3 scale;

    public GameObject GoObject;
    public GameObject Pary;
    bool death;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        scale = transform.localScale;
        GoObject.transform.position = PlayerObj.transform.position;
        GoObject.transform.parent = null;
        Pary.transform.parent = null;
        death = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (death)
        {
            return;
        }
        if (!PlayerMove.PlayerDead)
        {
            if (Vector2.Distance(transform.position, new Vector2(GoObject.transform.position.x, GoObject.transform.position.y)) < 0.1f)
            {
                GoObject.transform.position = PlayerObj.transform.position;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(GoObject.transform.position.x, GoObject.transform.position.y), 5 * Time.deltaTime);
            }
            if (GoObject.transform.position.x >= this.transform.position.x)
            {
                scale.x = 1;
                transform.localScale = scale;
            }
            else
            {
                scale.x = -1;
                transform.localScale = scale;
            }
        }
        if (scale.x == 1)
        {
            Pary.transform.position = new Vector3(this.transform.position.x-0.075f,this.transform.position.y-0.05f,0);
        }
        else
        {
            Pary.transform.position = new Vector3(this.transform.position.x + 0.075f, this.transform.position.y - 0.05f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Drop"))
        {
            EXPController.EXP += 8.0f * PlayerMove.EXPUP;
            PlayerMove.EXPUP += 1;
            death = true;
            ScoreManager.bigEnemyKillCount++;
            Destroy(Pary.gameObject);
            Destroy(GoObject.gameObject);
            var sequence = DOTween.Sequence();
            sequence.AppendInterval(0.01f);
            sequence.AppendCallback(() => Dest());
        }

        if (other.gameObject.CompareTag("DestroyObj"))
        {
            death = true;
            Destroy(Pary.gameObject);
            Destroy(GoObject.gameObject);
            var sequence = DOTween.Sequence();
            sequence.AppendInterval(0.01f);
            sequence.AppendCallback(() => Dest());
        }
    }
    private void Dest()
    {
        Destroy(this.gameObject);
    }
}
