using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelUpWindow : MonoBehaviour
{
    public GameObject LevelUpBack;
    public GameObject LevelUp01;
    public GameObject LevelUp02;
    public GameObject LevelUp03;
    // Start is called before the first frame update
    void Start()
    {
        LevelUpBack.transform.DOScale(new Vector2(1, 0), 0);
        LevelUp();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LevelUp()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(LevelUpBack.transform.DOScale(new Vector3(1, 12, 1), 0.25f));
        sequence.Append(LevelUpBack.transform.DOScale(new Vector3(25, 12, 1), 0.25f));
    }
}
