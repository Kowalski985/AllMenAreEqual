using UnityEngine;
using System.Collections;

public class platfromController : MonoBehaviour {
    public Transform target;
    public Transform start;
    public GameObject buttonToggle = null;
    public GameObject buttonHold = null;
    public float speed;
    private bool isActive = false;
    private Toggle toggleScript;
    private Hold holdScript;
    private bool stuck = false;
    // Use this for initialization
    void Start () {
        if (buttonToggle)
        {
            toggleScript = buttonToggle.GetComponent<Toggle>();        
        }
        else if (buttonHold)
        {
            holdScript = buttonHold.GetComponent<Hold>();
        }
        else
        {
            isActive = true;
        }
	
	}

    // Update is called once per frame

    void Update()
    {
        if (buttonToggle)
        {
            isActive = toggleScript.isOn;
        }
        else if (buttonHold)
        {
            isActive = holdScript.isOn;
        }
        if (isActive || stuck)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            if (stuck && transform.position == target.position) stuck = false;
        }
        else
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, start.position, step);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.position.y < transform.position.y)
        {
            print("bump");
            stuck = true;
        }
    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.transform.position.y < transform.position.y)
    //    {
    //        print("whew");
    //        stuck = false;
    //    }
    //}

    //void OnCollisionEnter2D(Collider2D other)
    //{
    //    if (other.transform.position.y < transform.position.y)
    //    {
    //        print("bump2");
    //        move up since collision with object at low
    //    }
    //}
}
