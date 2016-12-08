using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float speed = 10;
	public float jump = 200;
	public float throwSpeed = 50;
    public BoxCollider2D player1Coll;

    private Rigidbody2D rb2d;

	private Rigidbody2D player2rb2d;
    private Vector3 direction;
    private SmallGuyController p2script;
    bool onGround = false;
    bool throwReady;
    Animator anim;

    // Use this for initialization
    void Start () {

		player2rb2d = GameObject.Find("smallGuy").GetComponent<Rigidbody2D>();
        p2script = GameObject.Find("smallGuy").GetComponent<SmallGuyController>();
        rb2d = this.GetComponent<Rigidbody2D>();
        direction = this.transform.localScale;
        anim = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update() {
        Vector2 velo = rb2d.velocity;
        //left-right movements
        if (Input.GetKey(KeyCode.W))
        { if (onGround) {
                velo.y = jump * Time.deltaTime;
                rb2d.velocity = velo;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            velo.x = speed*Time.deltaTime;
            rb2d.velocity = velo;
            anim.SetBool("Walking", true);
            direction.x = Mathf.Abs(direction.x);
            this.transform.localScale = direction;

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("Walking", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            velo.x = -speed * Time.deltaTime;
            rb2d.velocity = velo;
            anim.SetBool("Walking", true);
            direction.x = -Mathf.Abs(direction.x);
            this.transform.localScale = direction;

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("Walking", false);
        }

        if (Input.GetKey(KeyCode.LeftShift)){

        	if(throwReady){
                StartCoroutine("wait", velo);
                

            }
        }
	
	}

    private IEnumerator wait(Vector2 velo)
    {
        anim.Play("player1ThrowV2");
        yield return new WaitForSeconds(0.17f);
        velo.y = throwSpeed;
        player2rb2d.velocity = velo;
        print(throwReady);
        p2script.isThrown = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {   

        if (Input.GetKeyUp(KeyCode.S))
        {
            if (other.gameObject.name.Equals("L3D1"))
            {
                Debug.Log("HERE");
                //teleport gameobject(player) to L3D2
                this.gameObject.transform.position = GameObject.Find("L3D2").GetComponent<Transform>().position;
            }
            if (other.gameObject.name.Equals("L3D2"))
            {
                //teleport gameobject(player) to L3D1
                this.gameObject.transform.position = GameObject.Find("L3D1").GetComponent<Transform>().position;
            }
            if (other.gameObject.name.Equals("L4D1"))
            {
                //teleport gameobject(player) to L4D2
                this.gameObject.transform.position = GameObject.Find("L4D2").GetComponent<Transform>().position;
            }
            if (other.gameObject.name.Equals("L4D2"))
            {
                //teleport gameobject(player) to L4D1
                this.gameObject.transform.position = GameObject.Find("L4D1").GetComponent<Transform>().position;
            }
            if (other.gameObject.name.Equals("L5D1"))
            {
                //teleport gameobject(player)  to L5D2
                this.gameObject.transform.position = GameObject.Find("L5D2").GetComponent<Transform>().position;
            }
            if (other.gameObject.name.Equals("L5D2"))
            {
                //teleport gameobject(player) to L5D1
                this.gameObject.transform.position = GameObject.Find("L5D1").GetComponent<Transform>().position;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
		//print(onGround);
		if (other.gameObject.CompareTag("floor")){
			//print(onGround);
			onGround = true;
            anim.SetBool("Contact", true);
        }
		if (other.gameObject.CompareTag("Player")){
			throwReady = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag("floor")){
            //print(onGround);
            anim.SetBool("Contact", false);
            onGround = false;
		}
		if (other.gameObject.CompareTag("Player")){
			throwReady = false;
		}

	}
}
