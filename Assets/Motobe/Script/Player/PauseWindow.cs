using UnityEngine;
using DG.Tweening;

public class PauseWindow : MonoBehaviour
{
    public GameObject PauseBack;
    public GameObject timeText;
    public GameObject pauseSel;
    public GameObject fade01;
    public GameObject fade02;
    bool pause;
    public static bool pauseEnd;
    public GameObject back;

    // Start is called before the first frame update
    void Start()
    {
        pauseSel.SetActive(false);
        fade01.SetActive(true);
        fade02.SetActive(false);
        pause = false;
        PauseBack.transform.DOScale(new Vector2(0, 0), 0);
        pauseEnd = false;
        back.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(!pause&&PlayerMove.start)
            {
                Pause();
                pause = true;
                PauseSelect.posNum = 1;
                timeText.SetActive(false);
            }
        }
        if (pauseEnd)
        {
            pauseEnd = false;
            PauseEnd();
        }
    }

    public void Pause()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(PauseBack.transform.DOScale(new Vector3(1, 13, 1), 0.2f).SetEase(Ease.InQuint));
        sequence.JoinCallback(() => WindowSE());
        sequence.JoinCallback(() => pd());

        sequence.Append(PauseBack.transform.DOScale(new Vector3(0.5f, 13, 1), 0.1f).SetEase(Ease.InQuint));

        sequence.Append(PauseBack.transform.DOScale(new Vector3(28, 12, 1), 0.15f).SetEase(Ease.InQuint));

        sequence.Append(PauseBack.transform.DOScale(new Vector3(25, 12, 1), 0.1f));
        sequence.JoinCallback(() => sel());

    }

    public void PauseEnd()
    {
        var sequence = DOTween.Sequence();
        
        sequence.Append(PauseBack.transform.DOScale(new Vector3(27, 12, 1), 0.15f).SetEase(Ease.InQuint));

        sequence.Append(PauseBack.transform.DOScale(new Vector3(0, 12, 1), 0.15f).SetEase(Ease.InQuint));
        sequence.JoinCallback(() => WindowSE());

        sequence.Append(PauseBack.transform.DOScale(new Vector3(0, 0, 1), 0f).SetEase(Ease.InQuint));
        sequence.JoinCallback(() => pd());
        sequence.JoinCallback(() => pE());
    }

    private void WindowSE()
    {

        SEController.window = true;
    }

    private void pd()
    {
        PlayerMove.PlayerDead = !PlayerMove.PlayerDead;
    }

    private void sel()
    {
        pauseSel.SetActive(true);
    }
    private void pE()
    {
        pause = false;
    }
}
