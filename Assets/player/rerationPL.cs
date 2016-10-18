using UnityEngine;
using System.Collections;

//ドッスンの攻撃判定
//着地時に勇者なら攻撃判定などを送る
//落ちたときの「どーん」もここ
public class rerationPL : MonoBehaviour {

    public GameObject hitparticle;

    private PlayerSEManager pSEM;
    PlayerCT PCT;
	// Use this for initialization
	void Start () {
        PCT = GetComponentInParent<PlayerCT>();
        pSEM = GetComponentInParent<PlayerSEManager>();
       
	
	}
	
	// 基本使わない
	void Update () {
	}

    void OnCollisionEnter2D( Collision2D  col )
    {
        //Debug.Log("Find something");
        pSEM.playHitGnd();

        if( col.gameObject.tag == "yusya")
        {
            
            Debug.Log("hit yusya");

            foreach(ContactPoint2D cp in col.contacts)
            {
                Vector2 hpt = cp.point;
                Quaternion rt = new Quaternion();
                GameObject PObj = Instantiate(hitparticle,hpt,rt) as GameObject;
                ParticleSystem pt = PObj.GetComponent<ParticleSystem>();
                pt.Emit(10);
            }
            Destroy(col.gameObject);
            GameObject GCT = GameObject.FindGameObjectWithTag("GameController");
            CT GGCT = GCT.GetComponent<CT>();
            GGCT.SendMessage("gameClear");

        }else if(col.gameObject.tag == "floor")
        {
            PCT.modeChange(PlayerCT.state.idle);
        }
        
    }


}
