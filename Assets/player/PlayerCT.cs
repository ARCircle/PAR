using UnityEngine;
using System.Collections;

//プレーヤードッスンの入力を処理
//ワンタッチで各種処理を自動実行するタイプなんでUpdateはステート管理くらい

public class PlayerCT : MonoBehaviour {

    //ステート
    public enum state {wait,hold,falling,idle ,set};
    public state mode = state.wait;

    
    Rigidbody2D rgbd;

    //落下パワー
    public Vector2 power = new Vector2(0, 1.0f);

    //元の位置に戻るまでの速さ
    public float spd = 1.0f;

    [SerializeField]
    private Vector3 startpos = new Vector3(0,0);


    //アニメーション、SE関係
    private Animator planm;
    private int anmId;

    private PlayerSEManager pSEM;

	// Use this for initialization
	void Start () {
        mode = state.wait;
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        planm = GetComponent<Animator>();
        startpos = gameObject.transform.position;
        pSEM = GetComponent<PlayerSEManager>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        inputManager();


        //ステートによって処理内容を決定
        switch (mode)
        {
            case state.wait:    waitMode(); anmId = 1; break;
            case state.falling: DropDown(); anmId = 2; break;
            case state.idle:                break;
            case state.set:     setposition();  anmId = 3; break;

            default: Debug.LogWarning("No state selected"); break;
        }

        //アニメ
        SetAnmState(anmId);
	
	}

    //入力をステートに反映させる
    void inputManager()
    {
        if (Input.GetButtonDown("go"))
        {
            mode = state.falling;
        }
        if (Input.GetButtonDown("back")){
            mode = state.set;
        }
    }


    //初期位置にドッスンを戻す
    void setposition()
    {
        rgbd.gravityScale = 0.0f;
        Vector3 direction = startpos - this.transform.position;

        rgbd.MovePosition( transform.position + direction.normalized * spd *Time.fixedDeltaTime);

        if( Mathf.Abs(Vector3.Magnitude( this.transform.position - startpos ) )< 0.5f)
        {
            mode = state.wait;
            rgbd.gravityScale = 2.0f;
        }
    }

    void waitMode()
    {
        //Debug.Log("Dosun.wait");
        rgbd.MovePosition(startpos);
    }

    void DropDown()
    {
        rgbd.AddForce(power);
    }



    public void modeChange(state newst)
    {
        mode = newst;
    }


    void SetAnmState(int mode)
    {
        planm.SetInteger("mode", mode);
    }

}
