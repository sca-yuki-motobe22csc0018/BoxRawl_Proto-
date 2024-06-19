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
        vec = descriptStagePosObj.transform.position - selectStagePos;//選択したステージからのベクトルを取得
    }

    private IEnumerator SetPos()
    {
        float time = 0;
        while(time<speed) {
            time += Time.deltaTime;
            Debug.Log(time);
            selectStage.transform.position += vec * speed*Time.deltaTime;
            yield return null;
        }
       
    }
}
