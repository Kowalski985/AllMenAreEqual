using UnityEngine;
using System.Collections;

public class Hold : MonoBehaviour
{
	public bool isOn = false;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
			isOn = true;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
			isOn = false;
	}
}

