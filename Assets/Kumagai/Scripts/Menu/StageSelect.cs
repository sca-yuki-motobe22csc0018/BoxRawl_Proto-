using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public static GameObject[,] stages = null;
    public static int x, y;
    bool escape;
    [SerializeField] private GameObject selector;
    [SerializeField] private GameObject cancel;
    public static int selectNumber;
    [SerializeField] private GameObject descriptionWindow;
    public static  bool descriptionFlag;
    public static bool onCursor;
    // Start is called before the first frame update
    void OnEnable()
    {
        onCursor = false;
        stages = new GameObject[3, 3];
        StageDscript.nextScene = false;
        x = 0;
        y = 0;
        selectNumber = 0;
        escape = false;
        descriptionFlag = false;
        StageSet();
    }

    // Update is called once per frame
    void Update()
    {
        if (!descriptionWindow.activeSelf)
        {
            StageSelection();
        }
        selector.SetActive(!descriptionWindow.activeSelf);
        descriptionWindow.SetActive(descriptionFlag);
        
    }

    private void StageSet()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                stages[x, y] = this.transform.GetChild(y * 3 + x).gameObject;
            }
        }
    }

    private void StageSelection()
    {
        escape = (y == -1);
        if (!descriptionFlag)
        {
            
                if (y != -1)
                {
                    selector.transform.position = stages[x, y].transform.position;
                }
                else
                {
                    selector.transform.position = cancel.transform.position;
                }
            if (!onCursor)
            {
                if (!escape)
                {
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (x == 0)
                        {
                            x = 2;
                        }
                        else
                        {
                            x--;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if (x == 2)
                        {
                            x = 0;
                        }
                        else
                        {
                            x++;
                        }
                    }
                }
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (y == -1)
                    {
                        y = 0;
                    }
                    else if (y == 0)
                    {
                        //y--;
                        y = -1;
                    }
                }
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (y == -1)
                    {
                        y = 0;
                    }
                    else if (y == 2)
                    {
                        y = -1;
                    }
                    else
                    {
                        y = -1;
                    }
                }
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                getKeySpace();
            }
           
        }
        //if(Input.GetKeyDown(KeyCode.Space)&&StageDscript.nextScene)
        //{
        //    SceneManager.LoadScene("Main Game");
        //}
    }
    public static void getKeySpace()
    {
            if (!descriptionFlag)
            {
                if ((y == -1))
                {
                    ButtonManager.sceneCheck = false;
                    ButtonManager.stageSelect = false;
                }
                else if (y != 1 || x != 1)
                {
                    selectNumber = int.Parse(stages[x, y].gameObject.name);
                    descriptionFlag = true;
                    //
                }
            }
    }
   
}
