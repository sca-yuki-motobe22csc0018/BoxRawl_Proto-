using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using Spine;

public class LevelUpWindow : MonoBehaviour
{
    public GameObject LevelUpBack;
    public GameObject LevelUp01;
    public GameObject LevelUp02;
    public GameObject LevelUp03;
    public GameObject LevelUp01Back;
    public GameObject LevelUp02Back;
    public GameObject LevelUp03Back;
    public SpriteRenderer levelUp1Back;
    public SpriteRenderer levelUp2Back;
    public SpriteRenderer levelUp3Back;

    bool levelUp;

    // Start is called before the first frame update
    void Start()
    {
        LevelUpBack.transform.DOScale(new Vector2(0, 0), 0);
        levelUp = false;
        levelUp1Back.DOFade(0, 0);
        levelUp2Back.DOFade(0, 0);
        levelUp3Back.DOFade(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!levelUp)
            {
                LevelUp();
                levelUp = true;
            }
            else
            {
                LevelUpEnd();
                levelUp = false;
            }
        }
    }

    public void LevelUp()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(LevelUpBack.transform.DOScale(new Vector3(1, 13, 1), 0.2f).SetEase(Ease.InQuint));
        sequence.JoinCallback(() => WindowSE());

        sequence.Append(LevelUpBack.transform.DOScale(new Vector3(0.5f, 13, 1), 0.1f).SetEase(Ease.InQuint));

        sequence.Append(LevelUpBack.transform.DOScale(new Vector3(28, 12, 1), 0.15f).SetEase(Ease.InQuint));

        sequence.Append(LevelUpBack.transform.DOScale(new Vector3(25, 12, 1), 0.1f));

        sequence.Append(LevelUp01Back.transform.DOMoveY(LevelUp01Back.transform.position.y - 15, 0.15f));
        sequence.Join(levelUp1Back.DOFade(1, 0.15f));
        sequence.JoinCallback(() => CardSE());

        sequence.Append(LevelUp02Back.transform.DOMoveY(LevelUp02Back.transform.position.y - 15, 0.15f));
        sequence.Join(levelUp2Back.DOFade(1, 0.15f));
        sequence.JoinCallback(() => CardSE());

        sequence.Append(LevelUp03Back.transform.DOMoveY(LevelUp03Back.transform.position.y - 15, 0.15f));
        sequence.Join(levelUp3Back.DOFade(1, 0.15f));
        sequence.Join(LevelUp01Back.transform.DORotate(new Vector3(0, 90, 0), 0.15f));
        sequence.JoinCallback(() => CardSE());


        sequence.Append(LevelUp01.transform.DORotate(new Vector3(0, 0, 0), 0.15f));
        sequence.Join(LevelUp02Back.transform.DORotate(new Vector3(0, 90, 0), 0.15f));
        sequence.JoinCallback(() => CardSE2());

        sequence.Append(LevelUp02.transform.DORotate(new Vector3(0, 0, 0), 0.15f));
        sequence.Join(LevelUp03Back.transform.DORotate(new Vector3(0, 90, 0), 0.15f));
        sequence.JoinCallback(() => CardSE2());

        sequence.Append(LevelUp03.transform.DORotate(new Vector3(0, 0, 0), 0.15f));
        sequence.JoinCallback(() => CardSE2());
    }

    public void LevelUpEnd()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(LevelUp01.transform.DORotate(new Vector3(0, 90, 0), 0.15f));
        sequence.JoinCallback(() => CardSE3());

        sequence.Append(LevelUp02.transform.DORotate(new Vector3(0, 90, 0), 0.15f));
        sequence.Join(LevelUp01Back.transform.DORotate(new Vector3(0, 0, 0), 0.15f));
        sequence.JoinCallback(() => CardSE3());

        sequence.Append(LevelUp01Back.transform.DOMoveY(LevelUp01.transform.position.y + 15, 0.15f));
        sequence.Join(levelUp1Back.DOFade(0, 0.15f));
        sequence.Join(LevelUp02Back.transform.DORotate(new Vector3(0, 0, 0), 0.15f));
        sequence.Join(LevelUp03.transform.DORotate(new Vector3(0, 90, 0), 0.15f));
        sequence.JoinCallback(() => CardSE());
        sequence.JoinCallback(() => CardSE3());

        sequence.Append(LevelUp02Back.transform.DOMoveY(LevelUp02.transform.position.y + 15, 0.15f));
        sequence.Join(levelUp2Back.DOFade(0, 0.15f));
        sequence.Join(LevelUp03Back.transform.DORotate(new Vector3(0, 0, 0), 0.15f));
        sequence.JoinCallback(() => CardSE());

        sequence.Append(LevelUp03Back.transform.DOMoveY(LevelUp03.transform.position.y + 15, 0.15f));
        sequence.Join(levelUp3Back.DOFade(0, 0.15f));
        sequence.Join(LevelUpBack.transform.DOScale(new Vector3(27, 12, 1), 0.15f).SetEase(Ease.InQuint));
        sequence.JoinCallback(() => CardSE());

        sequence.Append(LevelUpBack.transform.DOScale(new Vector3(0, 12, 1), 0.15f).SetEase(Ease.InQuint));
        sequence.JoinCallback(() => WindowSE());

        sequence.Append(LevelUpBack.transform.DOScale(new Vector3(0, 0, 1), 0f).SetEase(Ease.InQuint));
    }

    private void WindowSE()
    {

        SEController.window = true;
    }

    private void CardSE()
    {
        SEController.jump = true;
    }

    private void CardSE2()
    {
        SEController.powerupcard = true;
    }

    private void CardSE3()
    {
        SEController.changeCard = true;
    }
}
