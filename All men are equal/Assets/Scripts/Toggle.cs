using UnityEngine;
using System.Collections;

public class Toggle : MonoBehaviour
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
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
            Debug.Log(isOn);
			if (isOn == false)
				isOn = true;
			else
				isOn = false;
		}
	}
}

