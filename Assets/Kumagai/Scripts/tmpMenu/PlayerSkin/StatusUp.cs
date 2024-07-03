using UnityEngine.SceneManagement;
using UnityEngine;

public class StatusUp : MonoBehaviour
{
    public static string nowPlayerType;
    [SerializeField]private string selectPlayerType;
    private int nowTypeNumber;
    public static int tmpTypeNumber;
    public static int selectTypeNumber;
    public static bool selectType;
    [SerializeField] private GameObject window;
    [SerializeField] private GameObject[] type;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject selector;
    [SerializeField] private GameObject cancel;
    [SerializeField] private GameObject setSkin;
    void OnEnable()
    {
        nowTypeNumber = 0;
        tmpTypeNumber = 0;
        selectType = true;
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        window.SetActive(selectType);
        selector.SetActive(selectType);
        player.SetActive(!selectType);
        if (selectType)
        {
            PlayerMove.Drop = false;
            PlayerTypeSelection();
        }
      
    }

    private void PlayerTypeSet()
    {
        switch (selectTypeNumber)
        {
            case 0:
                {
                    selectPlayerType = "Defult";
                }
                break;
            case 1:
                {
                    selectPlayerType = "Speed";
                }
                break;
            case 2:
                {
                    selectPlayerType = "Hp";
                }
                break;
            case 3:
                {
                    selectPlayerType = "Jump";
                }
                break;
            case -1:
                {
                   
                }
                break;
            default:
                {
                    Debug.Log("A");
                }
                break;
        }
    }

    private void PlayerTypeSelection()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(tmpTypeNumber==1)
            {
                tmpTypeNumber = -1;
            }
           else if(tmpTypeNumber<=3)
            {
                tmpTypeNumber = 0;
            }
            if(tmpTypeNumber==100)
            {
                tmpTypeNumber = 2;
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
          if(tmpTypeNumber==0)
            {
                tmpTypeNumber = 2;
            }
          else if(tmpTypeNumber>0)
            {
                tmpTypeNumber = 100;
            }
          else if(tmpTypeNumber==-1)
            {
                tmpTypeNumber = 1;
            }
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            if (tmpTypeNumber <= 1 || tmpTypeNumber == 100)
            {
                tmpTypeNumber = -1;
            }
            else
            {
                tmpTypeNumber--;
            }
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            if (tmpTypeNumber == -1)
            {
                tmpTypeNumber = 0;
            }
            else if(tmpTypeNumber<=2&&tmpTypeNumber>0)
            {
                tmpTypeNumber++;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(tmpTypeNumber!=100&&tmpTypeNumber!=-1)
            {
                selectTypeNumber = tmpTypeNumber;
            }
            else if(tmpTypeNumber==100)
            {
                nowTypeNumber=selectTypeNumber;
                nowPlayerType = selectPlayerType;
                selectType = false;
                ButtonManager.sceneCheck = false;
                //selectTypeNumber = 0;
            }
            else
            {
                ButtonManager.sceneCheck = false;
                selectType = false;
                //selectTypeNumber=0;
            }
            PlayerTypeSet();
        }
    }


}
