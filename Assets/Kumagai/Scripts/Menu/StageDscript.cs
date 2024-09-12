using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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
    public static bool setSizeEnd;
    public static bool cancelFlag;
    [SerializeField] private Text stageName;
    [SerializeField] private Text stageDiscript;
    // Start is called before the first frame update
    void OnEnable()
    {
        DscriptSetVec();
        setSizeEnd = false;
        StartCoroutine(SetPos());
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)&&nextScene)
        //{
        //    StartCoroutine(StageSet());
        //}
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            cancelFlag = !cancelFlag;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow))
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
        switch(StageSelect.selectNumber)
        {
            case 1:
                {
                    stageName.text = "BasicStyle 1";
                    stageDiscript.text = "広くて普遍的なステージ\nまずはココから\n操作や敵に慣れよう";
                }
                break;
            case 2:
                {
                    stageName.text = "BasicStyle 2";
                    stageDiscript.text = "広くて普遍的なステージ\nまずはココから\n操作や敵に慣れよう";

                }
                break;
            case 3:
                {
                    stageName.text = "BasicStyle 3";
                    stageDiscript.text = "広くて普遍的なステージ\nまずはココから\n操作や敵に慣れよう";
                }
                break;
            case 4:
                {
                    stageName.text ="Bison panic";
                    stageDiscript.text = "牛が大量発生するステージ\nスピードに翻弄されないように\n気を付けよう";
                }
                break;
            case 5:
                {
                    stageName.text = "Parry party";
                    stageDiscript.text = "連続でパリィしやすいステージ\n高いところから一気に\n敵を倒そう";
                }
                break;
            case 6:
                {
                    stageName.text = "Wall jump";
                    stageDiscript.text = "足場が少なく\n安全地帯が少ないステージ\n壁ジャンプで高所に行こう";
                }
                break;
            case 7:
                {
                    stageName.text = "Put togetter";
                    stageDiscript.text = "中央の大きな穴が\n特徴的なステージ\n敵を集めてまとめて倒そう";
                }
                break;
            case 8:
                {
                    stageName.text = "Avoid room";
                    stageDiscript.text = "弾幕が飛び交うステージ\n足場と壁を使って縦横無尽に避けまくろう";
                }
                break;
        }
    }
     void DscriptSetVec()
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
            selectStage.transform.localScale=tmpSize+new Vector3 (defSize,defSize,defSize)*time*0.8f;
            yield return null;
        }
        tmptmpSize = selectStage.transform.localScale;
        setSizeEnd = true;
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
