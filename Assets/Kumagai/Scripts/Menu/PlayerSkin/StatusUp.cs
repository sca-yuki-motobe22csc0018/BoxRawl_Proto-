using UnityEngine.SceneManagement;
using UnityEngine;

public class StatusUp : MonoBehaviour
{
    public static string nowPlayerType;
    [SerializeField] private string selectPlayerType;
    private int nowTypeNumber;
    public static int tmpTypeNumber;
    public static int selectTypeNumber;
    public static bool selectType;
    [SerializeField] private GameObject window;
    [SerializeField] private GameObject[] type;
    [SerializeField] private GameObject player;
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
        if (selectType)
        {
            Debug.Log("’Ê‰ß‚µ‚Ü‚µ‚½‚Q");
            PlayerMove.Drop = false;
        }
        PlayerTypeSet();
    }

    private void PlayerTypeSet()
    {
        nowPlayerType=selectPlayerType;
        switch (selectTypeNumber)
        {
            case 0:
                {
                    selectPlayerType = "Defult";
                }
                break;
            case 1:
                {
                    selectPlayerType = "Hp";
                }
                break;
            case 2:
                {
                    selectPlayerType = "Speed";
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

}
