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
                    stageDiscript.text = "�L���ĕ��ՓI�ȃX�e�[�W\n�܂��̓R�R����\n�����G�Ɋ���悤";
                }
                break;
            case 2:
                {
                    stageName.text = "BasicStyle 2";
                    stageDiscript.text = "�L���ĕ��ՓI�ȃX�e�[�W\n�܂��̓R�R����\n�����G�Ɋ���悤";

                }
                break;
            case 3:
                {
                    stageName.text = "BasicStyle 3";
                    stageDiscript.text = "�L���ĕ��ՓI�ȃX�e�[�W\n�܂��̓R�R����\n�����G�Ɋ���悤";
                }
                break;
            case 4:
                {
                    stageName.text ="Bison panic";
                    stageDiscript.text = "������ʔ�������X�e�[�W\n�X�s�[�h�ɖ|�M����Ȃ��悤��\n�C��t���悤";
                }
                break;
            case 5:
                {
                    stageName.text = "Parry party";
                    stageDiscript.text = "�A���Ńp���B���₷���X�e�[�W\n�����Ƃ��납���C��\n�G��|����";
                }
                break;
            case 6:
                {
                    stageName.text = "Wall jump";
                    stageDiscript.text = "���ꂪ���Ȃ�\n���S�n�т����Ȃ��X�e�[�W\n�ǃW�����v�ō����ɍs����";
                }
                break;
            case 7:
                {
                    stageName.text = "Put togetter";
                    stageDiscript.text = "�����̑傫�Ȍ���\n�����I�ȃX�e�[�W\n�G���W�߂Ă܂Ƃ߂ē|����";
                }
                break;
            case 8:
                {
                    stageName.text = "Avoid room";
                    stageDiscript.text = "�e������ь����X�e�[�W\n����ƕǂ��g���ďc�����s�ɔ����܂��낤";
                }
                break;
        }
    }
     void DscriptSetVec()
    {
        selectStage = StageSelect.stages[StageSelect.x, StageSelect.y];
        selectStage.GetComponent<SpriteRenderer>().sortingOrder = 50;
        selectStagePos = selectStage.transform.position;
        tmpStagePos = selectStagePos;//�����ʒu���L��
        tmpSize=selectStage.transform.localScale;
        vec = descriptStagePosObj.transform.position - selectStagePos;//�I�������X�e�[�W����̃x�N�g�����擾
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
