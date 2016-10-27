using UnityEngine;
using System.Collections;

public class SmallGuyController : MonoBehaviour
{
    public float speed = 10;
    public float jump = 200;
    public BoxCollider2D player2Coll;

    private Rigidbody2D rb2d;
    private Vector3 direction;

    bool onGround = false;
    Animator anim;


    // Use this for initialization
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        direction = this.transform.localScale;
        anim = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        Vector2 velo = rb2d.velocity;
        //left-right movements
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (onGround)
            {
                velo.y = jump * Time.deltaTime;
                rb2d.velocity = velo;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velo.x = speed * Time.deltaTime;
            rb2d.velocity = velo;
            anim.SetBool("Walking", true);
            direction.x = Mathf.Abs(direction.x);
            this.transform.localScale = direction;

        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("Walking", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velo.x = -speed * Time.deltaTime;
            rb2d.velocity = velo;
            anim.SetBool("Walking", true);
            direction.x = -Mathf.Abs(direction.x);
            this.transform.localScale = direction;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("Walking", false);
        }


    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (Input.GetKeyUp(KeyCode.DownArrow))
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

    void OnTriggerEnter2D(Collider2D other)
    {
        //print(onGround);
        if (other.gameObject.CompareTag("floor"))
        {
            //print(onGround);
            onGround = true;
        }
  
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            //print(onGround);
            onGround = false;
        }


    }
}
