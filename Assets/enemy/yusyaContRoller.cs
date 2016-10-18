using UnityEngine;
using System.Collections;

public class yusyaContRoller : MonoBehaviour {

    //勇者の基本設定　インスペクター上で操作可能
    public float speed = 1.0f;
    public Vector2 jPow = new Vector2(0.0f,1.0f);

    [SerializeField]
    private bool IsGround = true;

    //物理挙動管理
    private Rigidbody2D yusyaPhys;

    //オーディオ・SE関係
    private yusyaSEManager ySEM;

    //アニメーション関係
    private Animator anmt;
    private bool anmkey;
    private bool anmjmp;
    private float locScX;


	// Use this for initialization
    //常用コンポーネントの関係づけ
	void Start () {

        yusyaPhys = GetComponent<Rigidbody2D>();
        anmt = GetComponent<Animator>();
        locScX = gameObject.transform.localScale.x;
        ySEM = GetComponent<yusyaSEManager>();
	
	}
	
	// Update is called once per frame
    //基本Update内に主な処理は書かない
    //関数で表記
	void Update () {

        //モーション
        if (Input.GetButton("yusyaL"))
        {
            yMoveL();
            anmkey = true;
            if (IsGround)
            {
                ySEM.playWalkInterval();
            }
            
        }
        else if (Input.GetButton("yusyaR"))
        {
            yMoveR();
            anmkey = true;
            if (IsGround)
            {
                ySEM.playWalkInterval();
            }
            
        }
        else
        {
            anmkey = false;
        }

        if (Input.GetButtonDown("yusyaJ") && IsGround)
        {
            yJump();
            ySEM.playJump();
        }

        //アニメーションアップデート
        animationUpdate();
	
	}

    public void yMoveL()
    {
        gameObject.transform.Translate(-speed * Time.fixedDeltaTime, 0, 0);
        gameObject.transform.localScale = new Vector2(-locScX, gameObject.transform.localScale.y);
    }

    public void yMoveR()
    {
        gameObject.transform.Translate(speed * Time.fixedDeltaTime, 0, 0);
        gameObject.transform.localScale = new Vector2(locScX, gameObject.transform.localScale.y);
    }

    public void yJump()
    {
        yusyaPhys.AddForce(jPow);
        IsGround = false;
    }

    public void Death()
    {
        ySEM.playDeath();
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        //Debug.Log("yusya:findSome "+ col.gameObject.tag);
        if(col.gameObject.tag == "floor")
        {
            IsGround = true;
        }
    }

    private void animationUpdate()
    {
        anmt.SetBool("key", anmkey);
        anmt.SetBool("gnd", IsGround);
    }
}
