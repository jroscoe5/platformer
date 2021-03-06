using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	public bool crouch = false;
    public bool knock = false;

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonUp("Active"))
        {
            OnKocking(false);
            StartCoroutine(KnockingTrue());
        }

        if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
        if (Input.GetButtonDown("Active"))
        {
            OnKocking(true);
        }
    }

    IEnumerator KnockingTrue()
    {
        // make player wait to finish knock before "knocking"
        yield return new WaitForSeconds(.7f);
        knock = true;
        yield return new WaitForSeconds(.1f);
        knock = false;

    }



	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

    public void OnKocking (bool isKnocking)
    {
        animator.SetBool("IsKnocking", isKnocking);
    }

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
