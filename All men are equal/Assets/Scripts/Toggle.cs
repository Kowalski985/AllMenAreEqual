using UnityEngine;
using System.Collections;

public class Toggle : MonoBehaviour
{
	public bool isOn = false;
    public Sprite depressed;
    public Sprite raised;
    private SpriteRenderer SR;
    // Use this for initialization
    void Start ()
	{
        SR = this.gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if ((other.gameObject.CompareTag ("Player"))|| (other.gameObject.CompareTag("bullet")))
		{
            Debug.Log(isOn);
            if (isOn == false)
            {
                SR.sprite = depressed;
                isOn = true;
            }
            else
            {
                SR.sprite = raised;
                isOn = false;
            }
		}
	}
}

