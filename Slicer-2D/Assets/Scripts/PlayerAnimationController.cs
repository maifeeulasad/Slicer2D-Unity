using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    Animator playerAnimator;
    float horizontal;
    float vertical;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0.1f)
        {
            AllAnimationStop();
            playerAnimator.SetBool("left2right", true);
        }
        else if (horizontal < -0.1f)
        {
            AllAnimationStop();
            playerAnimator.SetBool("right2left", true);
        }
        else
        {
            AllAnimationStop();
        }

        if (PlayerMovementController.ladderTouched && vertical!=0)
        {
            AllAnimationStop();
            playerAnimator.SetBool("climb", true);
        }
    }

    void AllAnimationStop()
    {
        playerAnimator.SetBool("right2left", false);
        playerAnimator.SetBool("left2right", false);
        playerAnimator.SetBool("climb", false);
    }


}
