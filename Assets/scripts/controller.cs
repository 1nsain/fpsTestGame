using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class controller : MonoBehaviour {
    /// <summary>
    /// variabel in swedish vinkel and lasvinkel = angle lock angle
    /// </summary>
    //public speed som man kan ändra i unity
    public float movementSpeed, mouseSpeed, vinkel, lasvinkel, mY, acceleration;
    public float jumpSpeed ;
    public float gravity;
    private bool grounded = false;
    private Vector3 moveDirection = Vector3.zero;
    
    /// <summary>
    /// gets the charachter controller
    /// </summary>
	// Use this for initialization
	void Start () {
        CharacterController cc = GetComponent<CharacterController>();
	}
    
	
	// Update is called once per frame
	void Update () {
        
        ///<summary>
        /// mus rotaation x
        ///</summary
        //mus rotation höger vänster
        float mX = Input.GetAxis("Mouse X")* mouseSpeed;
        transform.Rotate(0, mX, 0);
        ///<summary>
        /// mus rotaation Y
        ///</summary

        //kamera up och ner
        mY -= Input.GetAxis("Mouse Y") * mouseSpeed;
        mY = Mathf.Clamp(mY, -lasvinkel, lasvinkel);
        Camera.main.transform.localRotation = Quaternion.Euler(mY,0,0);
        //<summary>
        /// charachter movment forward and sideways
        ///</summary
		//variabler (hastighet)
        float speedForward = Input.GetAxis("Vertical")* movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;


        ///<summary>
        ///jump and groundcheck
        ///</summary>
        if (grounded)
        {
            //movediraction gör om till en fin hopp rörelse
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= movementSpeed;

            if (Input.GetButton("Jump")) moveDirection.y = jumpSpeed;
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        CharacterController controller = (CharacterController)GetComponent(typeof(CharacterController));
        CollisionFlags flags = controller.Move(moveDirection * Time.deltaTime);
        grounded = ((controller.collisionFlags & CollisionFlags.Below) != 0);

        Vector3 speed = new Vector3(sideSpeed, acceleration, speedForward); // YXZ


        CharacterController cc = GetComponent<CharacterController>();
        cc.Move(speed * Time.deltaTime);
        //kontrollera knapp
        
	}
    
    

}
