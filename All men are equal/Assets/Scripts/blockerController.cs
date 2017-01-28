using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockerController : MonoBehaviour {
    public Transform target;
    public Transform start;
    public GameObject buttonToggle = null;
    public GameObject buttonHold = null;
    public float speed;
    private bool isActive = false;
    private Toggle toggleScript;
    private Toggle holdScript;
    // Use this for initialization
    void Start()
    {
        if (buttonToggle)
        {
            toggleScript = buttonToggle.GetComponent<Toggle>();
        }
        if (buttonHold)
        {
            holdScript = buttonHold.GetComponent<Toggle>();
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
    void OnTriggerEnter2D(Collider2D other)
    {
    }
}
