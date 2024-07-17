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

    bool levelUp;

    // Start is called before the first frame update
    void Start()
    {
        LevelUpBack.transform.DOScale(new Vector2(0, 0), 0);
        levelUp = false;
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
        sequence.Append(LevelUpBack.transform.DOScale(new Vector3(0.5f, 13, 1), 0.1f).SetEase(Ease.InQuint));
        sequence.Append(LevelUpBack.transform.DOScale(new Vector3(25, 12, 1), 0.15f).SetEase(Ease.InQuint));
        sequence.Append(LevelUp01.transform.DOMoveY(LevelUp01.transform.position.y - 15, 0.15f));
        sequence.Append(LevelUp02.transform.DOMoveY(LevelUp01.transform.position.y - 15, 0.15f));
        sequence.Append(LevelUp03.transform.DOMoveY(LevelUp01.transform.position.y - 15, 0.15f));
    }

    public void LevelUpEnd()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(LevelUp01.transform.DOMoveY(LevelUp01.transform.position.y + 15, 0.15f));
        sequence.Append(LevelUp02.transform.DOMoveY(LevelUp01.transform.position.y + 15, 0.15f));
        sequence.Append(LevelUp03.transform.DOMoveY(LevelUp01.transform.position.y + 15, 0.15f));
        sequence.Append(LevelUpBack.transform.DOScale(new Vector3(27, 12, 1), 0.15f).SetEase(Ease.InQuint));
        sequence.Append(LevelUpBack.transform.DOScale(new Vector3(0, 12, 1), 0.15f).SetEase(Ease.InQuint));
    }
}
