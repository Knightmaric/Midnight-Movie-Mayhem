using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    //initialize variables... public, type, name of variable
    public GameObject thePlayer;
    public bool isMoving;
    public float horizontalMove;
    public float verticalMove;
    public bool isRunning;
    public bool backwardsCheck = false;
    public bool inputEnabled = true;

    void Update()
    {
        if (inputEnabled)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }

            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            { //if a movement key is pressed
                isMoving = true;
                if (Input.GetButton("Walk Back"))
                {
                    backwardsCheck = true;
                    thePlayer.GetComponent<Animator>().Play("Walk_Back"); //walk back animation
                }
                else
                {
                    backwardsCheck = false;

                    if (!isRunning)
                    {
                        thePlayer.GetComponent<Animator>().Play("Walk"); //walk animation
                    }
                    else
                    {
                        thePlayer.GetComponent<Animator>().Play("Run"); //run animation
                    }
                }
                if (!isRunning)
                {
                    verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 7; //decrease step back speed, regardless of if sprint is held
                }
                if ((isRunning) && !backwardsCheck)
                {
                    verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 17; //increase move speed when running
                }

                horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 220; //turning the player
                thePlayer.transform.Rotate(0, horizontalMove, 0);
                thePlayer.transform.Translate(0, 0, verticalMove);
            }
            else
            {
                isMoving = false;
                thePlayer.GetComponent<Animator>().Play("Idle"); //idle animation
                //horizontalMove = 0;
                //verticalMove = 0;
            }
        }
        else
        {
            thePlayer.GetComponent<Animator>().Play("Idle"); //idle animation
        }
    }
}
