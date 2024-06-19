using UnityEngine;

public class StageSelect : MonoBehaviour
{
    GameObject[,] stages = null;
    [SerializeField]int x, y;
    bool escape;
    [SerializeField] private GameObject selector;
    [SerializeField] private GameObject cancel;
    public static int selectNumber;
    // Start is called before the first frame update
    void OnEnable()
    {
        stages = new GameObject[3, 3];
        x = 0;
        y = 0;
        selectNumber = 0;
        escape = false;
        StageSet();
    }

    // Update is called once per frame
    void Update()
    {
        escape = y == -1;
        if (y != -1)
        {
            selector.transform.position = stages[x, y].transform.position;
        }
        else
        {
            selector.transform.position = cancel.transform.position;
        }
        if (!escape)
        {
            if (Input.GetKeyDown(KeyCode.A))
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
            if (Input.GetKeyDown(KeyCode.D))
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (y == -1)
            {
                y = 2;
            }
            else
            {
                y--;
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            if(y==-1)
            {
                y = 0;
            }
            else if(y==2)
            {
                y = -1;
            }
            else
            {
                y++;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if ((y == -1))
            {
                ButtonManager.sceneCheck = false;
                ButtonManager.stageSelect = false;
            }
            else
            {
                selectNumber = int.Parse(stages[x, y].gameObject.name);
            }
        }
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
}
