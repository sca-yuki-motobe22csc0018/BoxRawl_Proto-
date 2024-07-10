using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageDscript : MonoBehaviour
{

    [SerializeField] private GameObject descriptStagePosObj;
    [SerializeField] private GameObject centerObj;
    private GameObject selectStage;
    [SerializeField] private float speed;
    Vector3 selectStagePos;
    public static Vector3 tmpStagePos;
    Vector3 vec;
    public static Vector3 tmpSize;
    Vector3 tmptmpSize;
    public static bool nextScene;
    [SerializeField] private GameObject stageSelect;
    [SerializeField] private GameObject cancel;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject insPlayer;
    private bool cancelFlag;
    // Start is called before the first frame update
    void OnEnable()
    {
        DscriptSetVec();
        StartCoroutine(SetPos());
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)&&nextScene)
        //{
        //    StartCoroutine(StageSet());
        //}
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            cancelFlag = !cancelFlag;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            cancelFlag = !cancelFlag;
        }
        nextScene = !cancelFlag;
        if(cancelFlag)
        {
            insPlayer.transform.position = cancel.transform.position;
        }
        else
        {
            insPlayer.transform.position = start.transform.position;
        }
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
            time += Time.deltaTime/speed;
            Debug.Log(time);
            selectStage.transform.position += vec *Time.deltaTime/speed;
            yield return null;
        }
        StartCoroutine(SetSize());
    }

    private IEnumerator SetSize()
    {
        yield return new WaitForSeconds(0.25f);
        float time = 0;
       const float defSize=0.15f;
        while(time<0.5f) 
        {
            time += Time.deltaTime;
            selectStage.transform.localScale=tmpSize+new Vector3 (defSize,defSize,defSize)*time;
            yield return null;
        }
        tmptmpSize = selectStage.transform.localScale;
       // nextScene = true;
       // stageSelect.SetActive(false);
    }

    private IEnumerator StageSet()
    {
        float time = 0;
        Vector3 centerVec = centerObj.transform.position-selectStage.transform.position;
        while (time<1)
        {
            time += Time.deltaTime;
            selectStage.transform.position += centerVec * Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        while(time>1&&time<4)
        {
            time += Time.deltaTime*2;
            selectStage.transform.localScale= tmptmpSize * time*2;
            yield return null;
        }
        SceneManager.LoadScene("Main Game");
        yield break;
    }
}
