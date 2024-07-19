using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField]GameObject GroundObj;
    [SerializeField] GameObject tergetObj;

    [SerializeField] GameObject playerObj;
    Rigidbody2D rg;

    [SerializeField] GameObject EnemyObj;

    bool isJump = false;
    public static bool isStart;


    public GameObject hallObject;

    bool startFlag;

    [SerializeField] GameObject fadeObj;
    [SerializeField] GameObject ButtonImage;

    int isTutorial = -1;

    // Start is called before the first frame update
    void Start()
    {
        rg = playerObj.GetComponent<Rigidbody2D>();

        isStart = false;

        startFlag = false;

        PlayerSkin.Rota = false;
        fadeObj.SetActive(true);

        ButtonImage.SetActive(true);

        isTutorial = PlayerPrefs.GetInt("Tutorial", 0);
        Debug.Log(isTutorial);
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���X�^�[�g
        if(Input.GetKeyDown(KeyCode.Return) && !isStart
            || Input.GetKeyDown(KeyCode.Space) && !isStart
            || Input.GetMouseButton(0) && !isStart)
        {
            isStart = true;
            hallObject.SetActive(false);
            ButtonImage.SetActive(false);
            startGame();
        }

        FadeIO.FadeOut(startFlag);

        if(Input.GetKeyDown(KeyCode.Return)) 
        {
            Debug.Log(ResultManager.GetTotalScore(1,2,5,3));
        }

        if(Input.GetKeyDown (KeyCode.D)) 
        {
            isTutorial = -1;
            PlayerPrefs.DeleteKey("Tutorial");
        }
    }

    void startGame()
    {
        GroundObj.transform.DOMove(tergetObj.transform.position, 5.0f);
        if(playerObj.transform.position.x > EnemyObj.transform.position.x)
        {
            EnemyObj.transform.DOMove(EnemyObj.transform.position + (tergetObj.transform.position + GroundObj.transform.position), 5.0f);
        }
        else
        {
            EnemyObj.transform.DOMoveX(EnemyObj.transform.position.x + (GroundObj.transform.position.x - tergetObj.transform.position.x), 5.0f);
        }

        StartCoroutine(playerJump());
        
    }

    public IEnumerator playerJump()
    {
        yield return new WaitForSeconds(3.0f);
        Vector2 force = new Vector3(1.0f, 9.5f);
        rg.AddForce(force *50);
        PlayerSkin.Rota = true;

        yield return new WaitForSeconds(2.0f);
        startFlag = true;
        yield return new WaitForSeconds(2.0f);
        if(isTutorial <= 0)
        {
            SceneManager.LoadScene("Tutorial");
            isTutorial = 1;
        }
        else if (isTutorial >= 1)
        {
            SceneManager.LoadScene("Menu");
        }
        PlayerPrefs.SetInt("Tutorial", isTutorial);
        PlayerPrefs.Save();
        yield return null;
    }

    

}
