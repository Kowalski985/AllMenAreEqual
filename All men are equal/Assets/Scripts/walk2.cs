using UnityEngine;
using System.Collections;

public class walk2 : MonoBehaviour
{
    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * 2 * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);

            anim.SetBool("Walking", true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            anim.SetBool("Walking", false);
        }



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.right * 2 * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, -180);

            anim.SetBool("Walking", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            anim.SetBool("Walking", false);
        }

    }

}
