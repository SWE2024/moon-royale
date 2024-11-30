using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator playerAnimation;
    public Rigidbody playerRigid;
    public bool walking;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnimation.SetTrigger("walk");
            playerAnimation.ResetTrigger("idle");
            walking = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnimation.ResetTrigger("walk");
            playerAnimation.SetTrigger("idle");
            walking = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnimation.SetTrigger("walkBack");
            playerAnimation.ResetTrigger("idle");
            walking = true;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnimation.ResetTrigger("walkBack");
            playerAnimation.SetTrigger("idle");
            walking = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 10f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 10f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * 10f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 10f);
        }
    }
}