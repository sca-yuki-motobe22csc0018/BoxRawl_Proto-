
using UnityEngine;

public class SEController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip parySE;
    public AudioClip jumpSE;
    public AudioClip drop1SE;
    public AudioClip drop2SE;
    public AudioClip damageSE;
    public AudioClip deadSE;
    public AudioClip windowSE;
    public AudioClip powerUpCardSE;
    public AudioClip changeCardSE;
    public AudioClip selectSE;
    public AudioClip getSE;
    public AudioClip levelUpSE;
    public AudioClip cardSE;
    public static bool pary;
    public static bool jump;
    public static bool drop1;
    public static bool drop2;
    public static bool damage;
    public static bool dead;
    public static bool window;
    public static bool powerupcard;
    public static bool changeCard;
    public static bool select;
    public static bool get;
    public static bool levelUp;
    public static bool card;
    float jumpInterval;
    float timer;
    public AudioClip hnsn;
    int a;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pary = false;
        jump = false;
        drop1 = false;
        drop2 = false;
        damage = false;
        dead = false;
        window = false;
        powerupcard = false;
        changeCard = false;
        select = false;
        get = false;
        jumpInterval = 0;
        a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (pary)
        {
            audioSource.PlayOneShot(parySE);
            pary = false;
            Debug.Log("pary");
        }
        if (jump)
        {
            if (jumpInterval == 0)
            {
                audioSource.PlayOneShot(jumpSE);
            }
            jumpInterval += Time.deltaTime;
            if(jumpInterval > 0.1f)
            {
                jumpInterval = 0;
                jump = false;
            }
        }
        if (drop1)
        {
            audioSource.PlayOneShot(drop1SE);
            drop1 = false;
        }
        if (drop2)
        {
            audioSource.PlayOneShot(drop2SE);
            drop2 = false;
        }
        if (damage)
        {
            audioSource.PlayOneShot(damageSE);
            damage = false;
        }
        if (dead)
        {
            timer += Time.deltaTime;
            if (timer > 0.075f && a < 7)
            {
                audioSource.PlayOneShot(hnsn);
                a += 1;
                timer = 0;
            }
            if (a > 7)
            {
                dead = false;
            }
        }
        if (window)
        {
            audioSource.PlayOneShot(windowSE);
            window = false;
        }
        if (levelUp)
        {
            audioSource.PlayOneShot(levelUpSE);
            levelUp = false;
        }
        if (powerupcard)
        {
            audioSource.PlayOneShot(powerUpCardSE);
            powerupcard = false;
        }
        if (changeCard)
        {
            audioSource.PlayOneShot(changeCardSE);
            changeCard = false;
        }
        if (select)
        {
            audioSource.PlayOneShot(selectSE);
            select = false;
        }
        if (get)
        {
            audioSource.PlayOneShot(getSE);
            get = false;
        }
        if (card)
        {
            audioSource.PlayOneShot(cardSE);
            card = false;
        }
    }
}
