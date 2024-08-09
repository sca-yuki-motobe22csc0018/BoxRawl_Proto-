using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip parySE;
    public AudioClip jumpSE;
    public AudioClip drop1SE;
    public AudioClip dorp2SE;
    public AudioClip damageSE;
    public AudioClip deadSE;
    public AudioClip windowSE;
    public AudioClip powerUpCardSE;
    public AudioClip changeCardSE;
    public AudioClip selectSE;
    public AudioClip getSE;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (pary)
        {
            audioSource.PlayOneShot(parySE);
            pary = false;
        }
        if (jump)
        {
            audioSource.PlayOneShot(jumpSE);
            jump = false;
        }
        if (drop1)
        {
            audioSource.PlayOneShot(drop1SE);
            drop1 = false;
        }
        if (drop2)
        {
            audioSource.PlayOneShot(parySE);
            drop2 = false;
        }
        if (damage)
        {
            audioSource.PlayOneShot(damageSE);
            damage = false;
        }
        if (dead)
        {
            audioSource.PlayOneShot(deadSE);
            dead = false;
        }
        if (window)
        {
            audioSource.PlayOneShot(windowSE);
            window = false;
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
    }
}
