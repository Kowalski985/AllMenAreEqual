using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    private Transform bigGuy;
    private Transform smallGuy;

    // Use this for initialization
    void Start () {
        bigGuy = GameObject.Find("BigGuy").transform;
        smallGuy = GameObject.Find("smallGuy").transform;	
	}
	
	// Update is called once per frame
	void Update () {
        if (bigGuy != null && smallGuy != null)
        {
            transform.position = new Vector3(Mathf.Clamp((bigGuy.position.x + smallGuy.position.x) / 2, xMin, xMax),
                Mathf.Clamp((bigGuy.position.y + smallGuy.position.y) / 2, yMin, yMax), transform.position.z);

        }
	
	}
}
