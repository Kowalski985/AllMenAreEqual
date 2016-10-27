using UnityEngine;
using System.Collections;

public class bulletController : MonoBehaviour {

    public float lifeTime=1000;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }

	}

    void OnTriggerEnter2D()
    {
        Destroy(this.gameObject);
    }
}
