using UnityEngine;
using System.Collections;

public class gunController : MonoBehaviour {
    private Vector2 lookDirection = Vector2.zero;
    private Vector3 direction;
    public GameObject bulletPrefab;
    public GameObject gun;
    public float bulletSpeed;
 

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = (mousePos - (Vector2)transform.position).normalized;
        transform.right = lookDirection;
        direction = this.transform.localScale;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("bang!");
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.rotation = this.transform.rotation;
            newBullet.transform.position = gun.transform.position;
            newBullet.GetComponent<Rigidbody2D>().velocity = (bulletSpeed) * lookDirection;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = Mathf.Abs(direction.x);
            this.transform.localScale = direction;

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -Mathf.Abs(direction.x);
            this.transform.localScale = direction;
        }

    }

  
}
