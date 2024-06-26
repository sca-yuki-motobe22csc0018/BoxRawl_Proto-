using System.Collections;
using UnityEngine;

public class FadeIO : MonoBehaviour
{
    [SerializeField] private GameObject fadePanel;
    public static GameObject fader;
    // Start is called before the first frame update
    void Start()
    {
        alpha = 1;
        fader = fadePanel;
        StartCoroutine(FadeIn());
        Debug.Log("åƒÇ—èoÇ≥ÇÍÇ‹ÇµÇΩ");
    }

    // Update is called once per frame
    void Update()
    {
        color.a = alpha;
        fadePanel.GetComponent<SpriteRenderer>().color = color;
        fader.GetComponent<SpriteRenderer>().color = color;
    }

    public static float alpha;
    private Color color;
    private IEnumerator FadeIn()
    {
        while (alpha > 0)
        {
            alpha -= Time.deltaTime / 2;
            yield return null;
        }
        yield return null;
    }
    public static void FadeOut()
    {
                alpha += Time.deltaTime / 2;
            
    }
}
