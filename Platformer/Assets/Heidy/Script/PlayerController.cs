using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float JumpPower;
    public float MovementSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<Animator>().SetBool("Jump", false);
        transform.Translate(new Vector2(Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime, 0));
        GetComponent<Animator>().SetFloat("VelocityX", Mathf.Abs(Input.GetAxis("Horizontal")));
        GetComponent<Animator>().SetFloat("VelocityY", GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 1), new Vector2(transform.position.x, transform.position.y - 1), 0.0001f);
            if(hit)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpPower);
                GetComponent<Animator>().SetBool("Jump", true);
            }
        }
	}
}
