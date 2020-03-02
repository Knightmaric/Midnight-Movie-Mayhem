using UnityEngine;
using System.Collections;

public class DetermineTextObject : MonoBehaviour
{
    public GameObject TextObject;
    public GameObject Player;

    public bool facing;
    public bool colliding;

    public static bool displayText;
    public static float textWaitTimer = 0f;
    public static bool go = false;

    //Detect if player is close enough to object to interact with it
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            colliding = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            colliding = false;
        }
    }




    private void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    go = true;
        //}
        if (go) { 
            textWaitTimer -= Time.deltaTime;
        }
        //check if textWaitTimer is not 0
        if (textWaitTimer <= 0)
        {
            textWaitTimer = 0;
            go = false;
        }

        //check if the player is facing the interactable object
        IsFacingObject();

        if ((facing) && (colliding) && (Input.GetKey(KeyCode.Space)) && (Player.GetComponent<TankControls>().inputEnabled == true) && (textWaitTimer == 0))
        {
            TextObject.GetComponent<TW_Regular>().StartTypewriter();
            Player.GetComponent<TankControls>().inputEnabled = false;
            displayText = true;
        }
    }

    private bool IsFacingObject()
    {
        // Check if the player is facing this object
        Vector3 forward = Player.transform.forward;
        Vector3 toOther = (transform.position - Player.transform.position).normalized;

        if (Vector3.Dot(forward, toOther) < 0.7f)
        {
            Debug.Log("Not facing the object");
            facing = false;
            return false;
        }

        
        Debug.Log("Facing the object");
        facing = true;
        return true; 
    }
}
