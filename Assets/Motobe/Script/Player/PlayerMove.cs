using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    //Rigidbody
    private Rigidbody2D rb;

    //プレイヤーの見た目のオブジェクト
    public GameObject PlayerSkinObject;

    //ジャンプできるか確認するためのオブジェクト
    public GameObject JumpChecker;

    //ヒップドロップで敵を倒す判定のオブジェクト
    public GameObject DropObject;

    //体力表示用のオブジェクト
    public GameObject[] HpObject;

    //ジャンプの高さ関係
    public float DefaultJumpForce;
    public static float PlusJumpForce;
    private float JumpForce;

    //速さ関係
    public float DefaultSpeed;
    public static float PlusSpeed;
    private float Speed;

    //体力関係
    //private int DefaultHp=5;
    //[SerializeField] public int PlusHp;
    [SerializeField] public static int Hp;

    //空中に居るかの判定
    public static int JumpCount;

    //壁に触れているかの判定
   [SerializeField]private bool OnWall;
   public  bool right;

    //連続壁ジャンプをしないようにする
    private bool DoubleWall;

    //ヒップドロップをしているかの判定
    public static bool Drop;

    //ダメージを受けているかの確認
    public static bool blink;
    private bool blinkCheck;
    float blinkCount;

    //ダメージを受けた後の無敵時間
    //invincibleTime*0.05秒無敵時間(invincibleTime==8なら0.4秒)
    public int DefaultInvincibleTime;
    public static int PlusInvincibleTime;
    private int InvincibleTime;
    int invincibleTimeCheck;

    //スタート処理
    bool startRota;
    public Image[] Count;
    public GameObject EnemySpawnner;

    //パリィ処理
    public GameObject ParyObject;
    public static bool paryCheck;

    //ダメージ演出
    public Image damageEffect;

    //死亡判定
    public static bool PlayerDead;
    bool death;
    bool deathBlink;
    private bool onGround;
    //経験値倍率
    public static int EXPUP;

    //天井
    public GameObject Ceiling01;
    //public GameObject Ceiling02;
    //public GameObject Ceiling03;

    //LevelUpWindowを出すためのbool
    public static bool LevelUpWindowSet;
    int moveVec=1;
    //フェード
    bool fadeFlag;
    //死亡演出
    [SerializeField] GameObject deathPrefab;
    [SerializeField] Camera cameraObj;

    public GameObject timerText;

    public static bool ParyJump;

    public GameObject Barrier;
    public static bool barrier;

    public static bool heal;

    // Start is called before the first frame update
    void Start()
    {
        barrier = false;
        heal = false;
        Barrier.SetActive(false);
        if(timerText!=null)
        timerText.SetActive(false);
        //dekoi.SetActive(false);
        ParyJump = false;
        moveVec = 1;
        if (Ceiling01 != null)
        {
            Ceiling01.SetActive(false);
        }/*
        if (Ceiling02 != null)
        {
            Ceiling02.SetActive(false);
        }
        if (Ceiling03 != null)
        {
            Ceiling03.SetActive(false);
        }*/
        LevelUpWindowSet = false;
        EXPUP = 1;
        PlayerDead = false;
        JumpCount = 0;
        blink = false;
        blinkCheck = false;
        rb = GetComponent<Rigidbody2D>();
        PlayerSkinObject.SetActive(true);
        DropObject.SetActive(false);
        blinkCount = 0;
        invincibleTimeCheck = 0;
        startRota = false;
        if(EnemySpawnner!=null)
        EnemySpawnner.SetActive(false);
        PlusSpeed = 0;
        PlusJumpForce = 0;
        death = false;
        deathBlink = false;
        fadeFlag = false;
        onGround = false;
        Hp = 5;//DefaultHp + PlusHp;

        for(int i = 0; i < 5; i++)
        {
            HpObject[i].SetActive(false);
        }
        for (int i = 0; i < Hp; i++)
        {
            HpObject[i].SetActive(true);
        }

        ButtonManager.sceneCheck = false;
        ParyObject.SetActive(false);
        paryCheck = false;

        if (SceneManager.GetActiveScene().name == "Main Game")
        {
            if (StageSelect.selectNumber == 1)
            {
                this.transform.position = new Vector3(-70, 35, 0);
            }
            if (StageSelect.selectNumber == 2)
            {
                this.transform.position = new Vector3(0, 35, 0);
            }
            if (StageSelect.selectNumber == 3)
            {
                this.transform.position = new Vector3(70, 35, 0);
            }
            if (StageSelect.selectNumber == 4)
            {
                this.transform.position = new Vector3(-100, -52, 0);
            }
            if (StageSelect.selectNumber == 5)
            {
                this.transform.position = new Vector3(-50, -42, 0);
            }
            if (StageSelect.selectNumber == 6)
            {
                this.transform.position = new Vector3(0, -42, 0);
            }
            if (StageSelect.selectNumber == 7)
            {
                this.transform.position = new Vector3(50, -42, 0);
            }
            if (StageSelect.selectNumber == 8)
            {
                this.transform.position = new Vector3(100, -46, 0);
            }
            if (StageSelect.selectNumber == 9)
            {
                this.transform.position = new Vector3(0, -42, 0);
            }
        }
        else if (SceneManager.GetActiveScene().name == "a")
        {
            this.transform.position = new Vector3(0, 0, 0);
        }



        if (StatusUp.selectTypeNumber == 0)
        {
            PlusJumpForce = 0;
            PlusSpeed=0;
            PlusInvincibleTime=4;
        }
        else if (StatusUp.selectTypeNumber==1)
        {
            PlusJumpForce = -2;
            PlusSpeed = 0;
            PlusInvincibleTime = 20;
        }
        else if (StatusUp.selectTypeNumber==2)
        {
            PlusJumpForce = 0;
            PlusSpeed = 4;
            PlusInvincibleTime = 0;
        }
        else
        {
            PlusJumpForce = 4;
            PlusSpeed = -2;
            PlusInvincibleTime = 4;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        //if(PlayerDead)
        //Debug.Log(PlayerDead);

        FadeIO.FadeOut(fadeFlag);

        //ステータスを入力
        JumpForce = DefaultJumpForce + PlusJumpForce;
        Speed = DefaultSpeed + PlusSpeed;
        InvincibleTime = DefaultInvincibleTime + PlusInvincibleTime;

        if (EXPUP >= 3)
        {
            EXPUP = 3;
        }

        
        //ダメージを受けた時の点滅
        if (blink)
        {
            //点滅
            if (blinkCount > 0.05f)
            {
                if (blinkCheck)
                {
                    PlayerSkinObject.SetActive(true);
                    blinkCheck = false;
                    invincibleTimeCheck++;
                }
                else
                {
                    PlayerSkinObject.SetActive(false);
                    blinkCheck = true;
                    invincibleTimeCheck++;
                }
                if (invincibleTimeCheck >= InvincibleTime)
                {
                    blink = false;
                    invincibleTimeCheck = 0;
                }
                blinkCount = 0;
            }
            else
            {
                blinkCount += Time.deltaTime;
            }
        }
        if (!blink)
        {
            if (death&&!deathBlink)
            {
                blink = true;
                deathBlink = true;
                DamageEffect();
                return;
            }
            PlayerSkinObject.SetActive(true);
            blinkCount = 0;
        }
        if (PlayerDead)
        {
            if (EnemySpawnner != null)
                EnemySpawnner.SetActive(false);
        }
        if (PlayerDead)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0);
            return;
        }
        else
        {
            rb.gravityScale = 5;
        }

        if (barrier)
        {
            Barrier.SetActive(true);
        }
        if (heal)
        {
            heal = false;
            if (Hp < 5)
            {
                HpObject[Hp].SetActive(true);
                Hp += 1;
            }
        }

        //壁めり込み防止
        if (Input.GetKeyDown(KeyCode.A) && !right)
        {
            OnWall = false;
            moveVec = -1;
        }
        if (Input.GetKeyDown(KeyCode.D) && right)
        {
            OnWall = false;
            moveVec = 1;
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            if(Input.GetKey(KeyCode.D))
            {
                moveVec = 1;
            }
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.A))
            {
                moveVec = -1;
            }
        }

        
        if (!ButtonManager.sceneCheck)
        {
            if (startRota)
            {
                if (SceneManager.GetActiveScene().name == "Main")
                    EnemySpawnner.SetActive(true);
                if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.S))
                {
                    //Debug.Log(ParyController.parySet);
                    //空中にいるとき
                    if (!Drop)
                    {
                        if (JumpCount == 1 || ParyController.paryJump)
                        {
                            DropSystem();
                        }
                        if (!onGround)
                        {
                            DropSystem();
                        }
                    }

                }
                bool jumpKey = Input.GetKeyDown(KeyCode.Space);
                //Debug.Log(jumpKey);
                //ジャンプ
                if (Input.GetMouseButton(0)&&!Drop||Input.GetKey(KeyCode.Space)&&!Drop)
                {
                    onGround = false;
                    if (JumpCount == 0)
                    {
                        //壁での連続ジャンプ防止
                        if (OnWall)
                        {
                            if (!DoubleWall)
                            {
                                rb.velocity = new Vector3(0, JumpForce, 0);
                                DoubleWall = true;
                                SEController.jump = true;
                            }
                        }
                        else
                        {
                            rb.velocity = new Vector3(0, JumpForce, 0);
                            SEController.jump = true;
                        }
                    }
                }

                if (!Drop && ParyJump)
                {
                    rb.velocity = new Vector3(0, JumpForce, 0);
                    SEController.jump = true;
                    ParyJump = false;
                }
            


                //左移動
                if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
                {
                    if(!Drop&&!OnWall)
                    {
                        this.transform.position += new Vector3(moveVec * Speed * Time.deltaTime, 0, 0);
                    }
                    
                    if (Input.GetKey(KeyCode.A))
                    {
                        
                        //壁に触れたまま移動しない
                        if (!OnWall)
                        {
                            right = true;
                            //ヒップドロップ中に移動しない
                            if (!Drop)
                            {
                                PlayerSkin.rota = 1;

                              
                            }
                        }
                    }
                    //右移動
                    if (Input.GetKey(KeyCode.D))
                    {
                        //壁に触れたまま移動しない
                        if (!OnWall)
                        {
                            right = false;
                            //ヒップドロップ中に移動しない
                            if (!Drop)
                            {
                                PlayerSkin.rota = -1;

                               
                            }
                        }
                    }
                }
                
                //ヒップドロップ
                if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.S))
                {
                    //Debug.Log(ParyController.parySet);
                    //空中にいるとき
                    if (!Drop)
                    {
                        if (JumpCount == 1||ParyController.paryJump)
                        {
                            DropSystem();
                        }
                    }
                    
                }
                //ジャンプ可能か確認用オブジェクトの表示非表示
                if (JumpCount == 0)
                {
                    if (!DoubleWall)
                    {
                        JumpChecker.SetActive(true);
                    }
                    else
                    {
                        JumpChecker.SetActive(false);
                    }
                }
                else
                {
                    JumpChecker.SetActive(false);
                }
            }
            //ヒップドロップの判定
            if (!Drop)
            {
                DropObject.SetActive(false);
            }
        }
        if (Trigger.EnemyTrigger)
        {
            if (!Drop)
            {
                if (!blink)
                {
                    if (!barrier)
                    {
                        if (Hp > 1)
                        {
                            HpObject[Hp - 1].SetActive(false);
                            Hp -= 1;
                            blink = true;
                            CameraMove.damageSway = true;
                            DamageEffect();
                            SEController.damage = true;
                        }
                        else
                        {
                            if (SceneManager.GetActiveScene().name == "Tutorial")
                            {
                                Hp = 5;
                                for (int i = 0; i < 5; i++)
                                {
                                    HpObject[i].SetActive(false);
                                }
                                for (int i = 0; i < Hp; i++)
                                {
                                    HpObject[i].SetActive(true);
                                }
                                return;
                            }
                            if (!death)
                            {
                                death = true;
                                CameraMove.damageSway = true;
                                DamageEffect();
                                SEController.dead = true;
                                Dead();
                                blink = true;
                            }
                        }
                    }
                    else
                    {
                        Barrier.SetActive(false);
                        barrier = false;
                        blink = true;
                        CameraMove.damageSway = true;
                        DamageEffect();
                        SEController.damage = true;
                    }
                }
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Groundにふれたとき
        if (other.gameObject.CompareTag("Ground")||other.gameObject.CompareTag("Button"))
        {
            if (!PlayerDekoi.dekoiDrop)
            {
                PlayerDekoi.dekoiDestroy = true;
            }
            onGround = true;
            LevelUpWindowSet = true;
            if (!startRota&&SceneManager.GetActiveScene().name!="Menu")
            {
                PlayerSkin.Rota = false;
                StartCount();
                if (Ceiling01 != null)
                {
                    Ceiling01.SetActive(true);
                }/*
                if (Ceiling02 != null)
                {
                    Ceiling02.SetActive(true);
                }
                if (Ceiling03 != null)
                {
                    Ceiling01.SetActive(true);
                }*/

                //Time.timeScale = 0;
            }
            else if(SceneManager.GetActiveScene().name=="Menu")
            {
                PlayerSkin.Rota = false;
                startRota = true;
            }
            DoubleWall = false;
            //ヒップドロップで触れたらカメラを揺らす
            if (Drop)
            {
                CameraMove.dropSway = true;
                SEController.drop2 = true;
            }
            EXPUP = 1;
        }
        if(other.gameObject.CompareTag("Button"))
        {
            if (Drop)
            {
                CameraMove.dropSway = true;
            }
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            OnWall = true;
            PlayerSkin.rota = 0;
            PlayerSkin.Rota = false;
            if(moveVec==1)
            {
                right = false;
            }
            if(moveVec==-1)
            {
                right = true;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //壁に触れている間
        if (collision.gameObject.CompareTag("Wall"))
        {
            
            JumpCount = 0;
            ParyObject.SetActive(false);
        }
        //地面に触れている間
        if (collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("Button"))
        {
            Time.timeScale = 1.0f;
            Drop = false;
            PlayerSkin.rota = 0;
            PlayerSkin.Rota = false;
            JumpCount = 0;
            ParyObject.SetActive(false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        //壁から離れたとき
        if (collision.gameObject.CompareTag("Wall"))
        {
            JumpCount = 1;
            if (ParyObject != null)
                ParyObject.SetActive(true);
            PlayerSkin.Rota = true;
            OnWall = false;
            DoubleWall = false;
        }
        //地面から離れたとき
        if (collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("Button"))
        {
            LevelUpWindowSet = false;
            //Time.timeScale = 0.1f;
            JumpCount = 1;
            if(ParyObject!=null)
            ParyObject.SetActive(true);
            PlayerSkin.Rota = true;
        }
    }
    public void DropSystem()
    {
        var sequence = DOTween.Sequence();
        rb.velocity = new Vector3(0, JumpForce, 0);
        Drop = true;
        SEController.drop1 = true;
        if (PlayerSkin.rota==0)
        {
            PlayerSkin.rota = 1;
        }
        PlayerSkin.rota *= -2;
        sequence.AppendInterval(0.2f);
        sequence.AppendCallback(() => DropSystem2());
    }
    public void DropSystem2()
    {
        DropObject.SetActive(true);
        PlayerSkin.Rota = false;
        PlayerSkin.rota =0;
        rb.velocity = new Vector3(0, -JumpForce *  2, 0);
    }

    public void StartCount()
    {
        if (SceneManager.GetActiveScene().name!="Main Game")
        {
            StartEnd();
            return;
        }
        else
        {
            var sequence = DOTween.Sequence();
            var img3 = Count[3];
            var c3 = img3.color;
            c3.a = 0.0f;
            img3.color = c3;
            var img2 = Count[2];
            var c2 = img2.color;
            c2.a = 0.0f;
            img2.color = c2;
            var img1 = Count[1];
            var c1 = img1.color;
            c1.a = 0.0f;
            img1.color = c1;
            var imgGo = Count[0];
            var cGo = imgGo.color;
            cGo.a = 0.0f;
            imgGo.color = cGo;
            sequence.Append(DOTween.ToAlpha(() => img3.color, color => img3.color = color, 1, 0.25f));
            sequence.Append(DOTween.ToAlpha(() => img3.color, color => img3.color = color, 0, 0.25f));
            sequence.Append(DOTween.ToAlpha(() => img2.color, color => img2.color = color, 1, 0.25f));
            sequence.Append(DOTween.ToAlpha(() => img2.color, color => img2.color = color, 0, 0.25f));
            sequence.Append(DOTween.ToAlpha(() => img1.color, color => img1.color = color, 1, 0.25f));
            sequence.Append(DOTween.ToAlpha(() => img1.color, color => img1.color = color, 0, 0.25f));
            sequence.Append(DOTween.ToAlpha(() => imgGo.color, color => imgGo.color = color, 1, 0.25f));
            sequence.Append(DOTween.ToAlpha(() => imgGo.color, color => imgGo.color = color, 0, 0.25f));
            sequence.AppendCallback(() => StartEnd());
        }
       
    }

    public void StartEnd()
    {
        startRota = true;
        if(EnemySpawnner!=null)
            EnemySpawnner.SetActive(true);
        if (timerText != null)
            timerText.SetActive(true);
    }

    public void DamageEffect()
    {

        if (SceneManager.GetActiveScene().name == "a")
        {
            return;
        }
        var sequence = DOTween.Sequence();
        var img = damageEffect;
        var color = damageEffect.color;
        color.a = 0;
        for (int i=5/*DefaultHp+PlusHp*/;i>Hp;i--)
        {
            sequence.Append(DOTween.ToAlpha(() => img.color, color => img.color = color, 0.8f, 0.1f));
            sequence.Append(DOTween.ToAlpha(() => img.color, color => img.color = color, 0, 0.1f));
        }
    }

    public void Dead()
    {
        var sequence = DOTween.Sequence();
        //PlayerSkinObject.SetActive(false);
        HpObject[0].SetActive(false);
        Hp = 0;
        PlayerDead = true;
        if(EnemySpawnner!=null)
        EnemySpawnner.SetActive(false);
        Destroy(rb);
        PlayerSkin.Rota = false;
        fadeFlag = true;
        Instantiate(deathPrefab,this.gameObject.transform.position,Quaternion.identity);
        cameraObj.transform.parent = null;
        this.gameObject.SetActive(false);
        sequence.AppendInterval(3.0f);
        sequence.AppendCallback(() => SceneChange());
    }

    

    public void SceneChange()
    {
        SceneManager.LoadScene("Result");
    }
}
