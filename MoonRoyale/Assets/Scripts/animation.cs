using System.IO;
using UnityEngine;

public class animation : MonoBehaviour
{
    public Animator playerAnimation;
    public Rigidbody playerRigid;
    public float w_speed, olw_speed, rn_speed, ro_speed;
    public bool walking;
    public Transform playerTrans;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnimation.SetTrigger("walk");
            playerAnimation.ResetTrigger("idle");
            playerRigid.linearVelocity = transform.forward * w_speed * Time.deltaTime;
            walking = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnimation.ResetTrigger("walk");
            playerAnimation.SetTrigger("idle");
            playerRigid.linearVelocity = new Vector3(0, 0, 0);
            walking = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnimation.SetTrigger("walkBack");
            playerAnimation.ResetTrigger("idle");
            playerRigid.linearVelocity = -transform.forward * w_speed * Time.deltaTime;
            walking = true;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnimation.ResetTrigger("walkBack");
            playerAnimation.SetTrigger("idle");
            playerRigid.linearVelocity = new Vector3(0,0,0);
            walking = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
            {
                if (walking)
                {
                    if (Input.GetKeyDown(KeyCode.LeftShift))
                    {
                        w_speed = w_speed + rn_speed;
                        playerAnimation.SetTrigger("run");
                        playerAnimation.ResetTrigger("walk");
                    }
                    if (Input.GetKeyUp(KeyCode.LeftShift))
                    {
                        w_speed = olw_speed;
                        playerAnimation.ResetTrigger("run");
                        playerAnimation.SetTrigger("walk");
                    }
                }

            }
        }
    }

    void Update()
    {
        
    }
}