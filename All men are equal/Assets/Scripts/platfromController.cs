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
        if (isActive)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
        else
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, start.position, step);
        }
    }
}
