using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class doorController : MonoBehaviour {

    public Sprite open;
    public Sprite closed;
    private SpriteRenderer SR;
    private bool bigGuy;
    private bool smallGuy;
    public int sceneIndex;

    // Use this for initialization
    void Start () {
        bigGuy = false;
        smallGuy = false;
        SR = this.gameObject.GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        if (bigGuy && smallGuy)
        {
            SR.sprite = open;
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.S))
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
        else
        {
            SR.sprite = closed;
        }
        


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //print(onGround);
        if (other.gameObject.name == "BigGuy")
        {
            //print(onGround);
            bigGuy = true;
        }
        else if (other.gameObject.name == "smallGuy")
        {
            smallGuy = true;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        //print(onGround);
        if (other.gameObject.name == "BigGuy")
        {
            //print(onGround);
            bigGuy = false;
        }
        else if (other.gameObject.name == "smallGuy")
        {
            smallGuy = false;
        }


    }
}
