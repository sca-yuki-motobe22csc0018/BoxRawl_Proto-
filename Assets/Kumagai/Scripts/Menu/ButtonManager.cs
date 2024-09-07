using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //[SerializeField] private GameObject sceneGround;
    [SerializeField] private GameObject sceneCheckBackGround;
    [SerializeField] private GameObject Player;
    [SerializeField] private Text sceneName;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private float alphaSec;
    [SerializeField] private GameObject statusWindow;
    [SerializeField] private GameObject floorLeft;
    [SerializeField] private GameObject floorRight;
    [SerializeField] private GameObject[] playerChild;
    [SerializeField] private GameObject stageSelectWindow;
    [SerializeField] private GameObject stageDiscriptWindow;
    [SerializeField] private GameObject[] stageWindow;
    [SerializeField] private GameObject DropObject;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject insPlayer;
    //private bool sceneChangeFlag;
    public static string yesOrNo;
    public static string thisSceneName;
    public static bool sceneCheck;
    public static bool sceneChange;
    public static bool stageSelect;
    


    // Start is called before the first frame update
    void Start()
    {
        sceneChange = false;
        sceneCheck = false;
        stageSelect = false;
        yesOrNo = "";
        thisSceneName = "";
        StageSelect.selectNumber = 0;
        StartCoroutine(ButtonStart());
        StageDscript.nextScene = false;
        insPlayer.SetActive(true);
        canvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        SceneCheck();
        Debug.Log(thisSceneName);
        stageSelectWindow.SetActive(stageSelect);
        Player.SetActive(!stageSelect);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            stageSelect = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)&&StageDscript.setSizeEnd)
        {
            if (StageDscript.nextScene)
            {
                thisSceneName = "Main Game";
                yesOrNo = "Yes";
                Debug.Log("ここでシーンを移動");
            }
            else if(stageDiscriptWindow.activeSelf&&StageDscript.setSizeEnd) 
            {

                StageSelect.stages[StageSelect.x, StageSelect.y].transform.position = StageDscript.tmpStagePos;
                StageSelect.stages[StageSelect.x, StageSelect.y].transform.localScale = StageDscript.tmpSize;
                StageSelect.stages[StageSelect.x, StageSelect.y].GetComponent<SpriteRenderer>().sortingOrder = 15;
                StageSelect.descriptionFlag = false;    
               
            }
        }
        //Debug.Log(sceneCheck);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.name == "Player")
        {
            if (PlayerMove.Drop)
            {
                sceneCheck = true;
                switch (this.gameObject.transform.name)
                {
                    case "Main Game":
                        {
                            thisSceneName = "Main Game";
                        }
                        break;
                    case "Tutorial":
                        {
                            thisSceneName = "Tutorial";
                        }
                        break;
                    case "AddStatus":
                        {
                            thisSceneName = "CharaChange";
                        }
                        break;
                    default:
                        {
                            thisSceneName = "Main Game";
                        }
                        break;
                }
                Player.transform.position = this.gameObject.transform.position + new Vector3(0, 0.3f, 0);//0.3はボタンサイズ
                sceneName.text = thisSceneName;
                PlayerMove.Drop = false;
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
    }

    //選択したときにそのシーンに移動するかどうかをチェックする
    //ステータス割り振りの時にはこのシーンはスキップする
    private void SceneCheck()
    {
        if (sceneCheck)
        {
            switch (sceneName.text)
            {
                case "Tutorial":
                    {
                        StartCoroutine(SceneChanger());
                    }
                    break;
                case "Main Game":
                    {
                       // sceneCheckBackGround.SetActive(true);
                        stageSelect = true;
                    }
                    break;
                case "CharaChange":
                    {
                        statusWindow.SetActive(true);
                        PlayerMove.Drop = false;
                        DropObject.SetActive(false);
                    }
                    break;
                default:
                    {
                        sceneCheckBackGround.SetActive(false);
                    }
                    break;
            }
            if (yesOrNo == "Yes")
            {
                StartCoroutine(SceneChanger());
            }
            if (yesOrNo == "No")
            {
                sceneCheck = false;
                sceneCheckBackGround.SetActive(false);
                yesOrNo = "";
            }

        }
    }


    //シーン切り替え時の演出（仮）
    public IEnumerator SceneChanger()
    {
            //mainCamera.transform.position = new Vector3(Player.transform.position.x, 2, -10);
            Player.GetComponent<Rigidbody2D>().gravityScale = 5;//重力を変更
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            for (int i = 0; i < playerChild.Length; i++) { playerChild[i].SetActive(false); }
           // FlooringOpen();
            sceneCheckBackGround.SetActive(false);
            //stageSelect = false;
           // foreach(var child in stageWindow) { child.SetActive(false); }
            yield return new WaitForSeconds(0.5f);
           
        //sceneGround.SetActive(false);
        //this.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        //this.gameObject.transform.GetComponent<BoxCollider2D>().isTrigger = true;
            sceneChange = true;
            FadeIO.FadeOut(sceneChange);
            yield return new WaitForSeconds(0.5f);
            canvas.SetActive(false);
            insPlayer.SetActive(false);
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(thisSceneName);
    }

    float alpha = 0;
    private IEnumerator ButtonStart()
    {
        while (this.transform.gameObject.GetComponent<SpriteRenderer>().color.a <= 1)
        {
            Color bc = this.GetComponent<SpriteRenderer>().color;
            //Color gc = sceneGround.GetComponent<SpriteRenderer>().color;
            alpha += Time.deltaTime / alphaSec;
            this.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(bc.r, bc.g, bc.b, alpha);
            //sceneGround.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(gc.r, gc.g, gc.b, alpha);
            //Debug.Log("呼ばれています");
            yield return new WaitForEndOfFrame();
           
        }
    }
    private float timer=0;
    private void FlooringOpen() 
    {
            Debug.Log("床を開きます");
            timer += Time.deltaTime*3.75f;
            floorLeft.transform.Rotate(0, 0, timer*Time.deltaTime);
            floorRight.transform.Rotate(0,0, -timer*Time.deltaTime);
        
    }
}
