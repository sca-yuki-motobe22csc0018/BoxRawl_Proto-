using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageDscript : MonoBehaviour
{

    [SerializeField] private GameObject descriptStagePosObj;
    private GameObject selectStage;
    [SerializeField] private float speed;
    Vector3 selectStagePos;
    Vector3 tmpStagePos;
    Vector3 vec;
    Vector3 tmpSize;
    // Start is called before the first frame update
    void OnEnable()
    {
        DscriptSetVec();
        StartCoroutine(SetPos());
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void DscriptSetVec()
    {
        selectStage = StageSelect.stages[StageSelect.x, StageSelect.y];
        selectStage.GetComponent<SpriteRenderer>().sortingOrder = 50;
        selectStagePos = selectStage.transform.position;
        tmpStagePos = selectStagePos;//初期位置を記憶
        tmpSize=selectStage.transform.localScale;
        vec = descriptStagePosObj.transform.position - selectStagePos;//選択したステージからのベクトルを取得
    }

    private IEnumerator SetPos()
    {
        float time = 0;
        while(time<1) {
            time += Time.deltaTime*speed;
            Debug.Log(time);
            selectStage.transform.position += vec * speed*Time.deltaTime;
            yield return null;
        }
        StartCoroutine(SetSize());
    }

    private IEnumerator SetSize()
    {
        float time = 0;
        while(time<0.5f) 
        {
            time += Time.deltaTime;
            selectStage.transform.localScale=tmpSize+new Vector3 (1,1,1)*time;
            yield return null;
        }
    }
}
