
 using UnityEngine;
 using System.Collections;
 
 public class HeroMovement : MonoBehaviour
{
    //Variables
    public float speed = 6.0F;
    public float runSpeed = 8.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;


    private Vector3 moveDirection = Vector3.zero;

    //State

    private bool isOpenEditor = false;
    private bool isCutScene = false;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();


            // is the controller on the ground?
            if (controller.isGrounded)
            {

                //Feed moveDirection with input.
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


                if (moveDirection != Vector3.zero)
                    this.transform.rotation = Quaternion.LookRotation(moveDirection);

                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        this.GetComponent<Animator>().Play("run");
                        moveDirection *= runSpeed;
                    }
                    else
                    {
                        this.GetComponent<Animator>().Play("walk");
                        moveDirection *= speed;
                    }


                }
                else { this.GetComponent<Animator>().Play("idle"); }





                //Jumping
                if (Input.GetButton("Jump"))
                {
                    this.GetComponent<Animator>().Play("jump");
                    moveDirection.y = jumpSpeed;
                }




            }

            //Applying gravity to the controller
            moveDirection.y -= gravity * Time.deltaTime;

            if (!isCutScene && !isOpenEditor)
            {
                //Making the character move
                controller.Move(moveDirection * Time.deltaTime);
            }
            else
            {
            controller.Move(moveDirection * 0);

        }

        

    }

    public void setCheckCutScene(bool Status)
    {

       isCutScene = Status;
    }

    public void setIsOpenEditor(bool input)
    {
        isOpenEditor = input;
    }



}