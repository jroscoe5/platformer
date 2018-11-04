using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{

    public AIController controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public int direction = 1;
    void Start()
    {
        StartCoroutine(directionSwap());
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = .2f * runSpeed;
    }

    IEnumerator directionSwap()
    {
        yield return new WaitForSeconds(2f);
        direction *= -1;
        StartCoroutine(directionSwap());
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime * direction, crouch, jump);
        jump = false;
    }
}
