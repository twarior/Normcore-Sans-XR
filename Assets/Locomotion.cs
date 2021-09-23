using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour {

    public Vector3 movement;
    public float movementX;
    public float movementY;
    public float speed = 5f;



    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        LocalUpdate(); ;
    }
    private void LocalUpdate() {
        OVRInput.Update();
        
        Movement();
    }

    private void LocalFixedUpdate() {
        OVRInput.FixedUpdate();
    }


    void Movement() {
        //first movement type: WASD Inputs; runs every frame; 
        //need to find way to shut it off if the player is using vr
        KeyboardInput();

        //if nothing is received from the keyboard, run the VR movement
        if (movementX == 0 && movementY == 0) {
            
                VRThumbstickInput();
        }

        movement = new Vector3(movementX, 0.0f, movementY);

        transform.Translate(movement * Time.deltaTime * speed);
    }


    //Takes in WASD and adds force to the front/back and left/right axes.
    //Need to run this before the VR input sliding because it overwrites the movementX and Y.
    //Could potentially check to see if they are 0 after running the vr thumbstick method, 
    //but if there is drift in the thumbstick, you wouldn't be able to move via WASD.
    void KeyboardInput() {
        var tempFB = 0f;
        var tempLR = 0f;

        if (Input.GetKey(KeyCode.W)) {
            tempFB += 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            tempFB -= 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            tempLR -= 1;
        }
        if (Input.GetKey(KeyCode.D)) {
            tempLR += 1;
        }
        movementX = tempLR;
        movementY = tempFB;
    }

    //Takes in the Left VR Thumbstick from Oculus controllers and turns that into 2 
    //floats for front/back and left/right movement. 
    //Just checks for the left thumbstick for now; could check for both
    private void VRThumbstickInput() {
        var tempLeft = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        //check if the thumbstick is being pressed in any direction
        //if (tempLeft != new Vector2(0f, 0f)) {
        movementX = tempLeft.x;
        movementY = tempLeft.y;
        
        //}
    }

}
