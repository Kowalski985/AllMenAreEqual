using UnityEngine;
using System.Collections;

public class walk : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        {
            
        }
	}

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Contact", false);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("Contact", true);
        }





        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * 3 * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
            
            anim.SetBool("Walking", true);
        }

        if(Input.GetKeyUp(KeyCode.D)) {
            anim.SetBool("Walking", false);
        }


        
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.right * 3 * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, -180);

            anim.SetBool("Walking", true);
        }

        if (Input.GetKeyUp(KeyCode.A)) {
            anim.SetBool("Walking", false);
        }

    }

}
