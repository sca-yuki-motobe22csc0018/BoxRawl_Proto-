using UnityEngine;
using DG.Tweening;

public class PauseWindow : MonoBehaviour
{
    public GameObject PauseBack;
    bool pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        PauseBack.transform.DOScale(new Vector2(0, 0), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(!pause)
            {
                Pause();
                pause = true;
            }else
            {
                PauseEnd();
                pause = false;
            }
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

    }

    public void PauseEnd()
    {
        var sequence = DOTween.Sequence();
        
        sequence.Append(PauseBack.transform.DOScale(new Vector3(27, 12, 1), 0.15f).SetEase(Ease.InQuint));

        sequence.Append(PauseBack.transform.DOScale(new Vector3(0, 12, 1), 0.15f).SetEase(Ease.InQuint));
        sequence.JoinCallback(() => WindowSE());

        sequence.Append(PauseBack.transform.DOScale(new Vector3(0, 0, 1), 0f).SetEase(Ease.InQuint));
        sequence.JoinCallback(() => pd());
    }

    private void WindowSE()
    {

        SEController.window = true;
    }

    private void size()
    {
        LevelSelect.size = !LevelSelect.size;
        LevelSelect.posNum = 1;
    }

    private void pd()
    {
        PlayerMove.PlayerDead = !PlayerMove.PlayerDead;

        PlayerMove.blink = true;
    }
}
