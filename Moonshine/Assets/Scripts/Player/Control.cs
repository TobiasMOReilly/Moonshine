using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    [SerializeField] private Player player;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private GameEvent cycleInventoryEvent;
    [SerializeField] private GameEvent itemThrownLeftEvent;
    [SerializeField] private GameEvent itemThrownRightEvent;
    [SerializeField] private GameEvent itemConsumedEvent;
    //[SerializeField] private FloatReference accelerateForce;    //Force multiplier for acceleration / reverse
    [SerializeField] private FloatReference turnForce;          //Force multiplier for steering

    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider rearLeft;
    [SerializeField] private WheelCollider rearRight;

    private float currentAccelerateForce;

    private float leftStickMovementVert;        //Stores stick movement amount
    private float rightStickMovementVert;       // ""
    private float leftStickMovementHor;         // ""
    private float rightStickMovementHor;        // ""

    [SerializeField] private string leftStickVertical;           //Player 1 accelerate joyestick ref
    [SerializeField] private string leftStickHorizontal;         //Player 1 Steer joyestick ref
    [SerializeField] private string rightStickVertical;          //Player 2 accelerate joyestick ref
    [SerializeField] private string rightStickHorizontal;        //Player 2 Steer joyestick ref
    [SerializeField] private string leftThrow;                   //Player 1 throw ref
    [SerializeField] private string rightThrow;                  //Player 2 throw ref
    [SerializeField] private string leftConsume;                 //Player 1 consume pick up ref
    [SerializeField] private string rightConsume;                //Player 2 consume pick up ref
    [SerializeField] private string leftCyclePickUp;             //Player 1 cycle pickups ref
    [SerializeField] private string rightCyclePickUp;            //Player 2 cycle pickups ref
    [SerializeField] private string reset;                       //Reset the car
    [SerializeField] private string pause;                       //Pause ref

    private bool contolsEnabled;

    // Use this for initialization
    void Start () {
        contolsEnabled = false;
        player.ResetAccelerateForce();
        currentAccelerateForce = player.GetCurrentAccelerateForce();
        player.SetCurrentTransform(this.gameObject.transform);
        print(player.GetCurrentCheckPoint());
        player.ResetCurrentLives();
    }
	
	// Update is called once per frame
	void Update () {
        player.UpdateCurrentPosition(transform.position);
        player.SetCurrentTransform(this.gameObject.transform);

        if (contolsEnabled)
        {
            Accelerate();
            Steer();
            Throw();
            Consume();
            CyclePickups();
            PauseMenu();
            ResetCar();
        }
    }

    private void Accelerate()
    {
        //Get left joystick vertical movement
        leftStickMovementVert = Input.GetAxis(leftStickVertical) * currentAccelerateForce;
        //Get right joystick vertical movement
        rightStickMovementVert = Input.GetAxis(rightStickVertical) * currentAccelerateForce;
        //Check if invert control is active or not
        if (!player.GetInvertControl())
        {
            //Apply left joystick movement * accelerateForce to left rear wheel 
            rearLeft.motorTorque = leftStickMovementVert;
            //Apply right joystick movement * accelerateForce to right rear wheel
            rearRight.motorTorque = rightStickMovementVert;
        }
        else
        {
            //Apply left joystick movement * accelerateForce to right rear and invert 
            rearLeft.motorTorque = -rightStickMovementVert;
            //Apply right joystick movement * accelerateForce to left rear and invert
            rearRight.motorTorque = -leftStickMovementVert;
        }
    }
    private void Steer()
    {
        //Get left joystick Horizontal movement * accelerateForce to right front
        leftStickMovementHor = Input.GetAxis(leftStickHorizontal) * turnForce.Value;
        //Get right joystick Horizontal movement * accelerateForce to right front
        rightStickMovementHor = Input.GetAxis(rightStickHorizontal) * turnForce.Value;
        //Check if invert control is active or not
        if (!player.GetInvertControl())
        {
            //Apply left joystick movement
            frontLeft.steerAngle = leftStickMovementHor;
            //Apply right joystick movement 
            frontRight.steerAngle = rightStickMovementHor;
        }
        else
        {
            //Apply left joystick movement to right wheel and invert
            frontLeft.steerAngle = -rightStickMovementHor;
            //Apply right joystick movement to left wheel and invert
            frontRight.steerAngle = -leftStickMovementHor;
        }
    }

    private void Throw()
    {
        float leftTrigger = Input.GetAxis(leftThrow);
        float rightTrigger = Input.GetAxis(rightThrow);
        //Check if left trigger pressed
        if (leftTrigger > 0)
        {
            //Throw
            player.SetThrowForce(leftTrigger);
            //print("Left: " + leftTrigger);
            itemThrownLeftEvent.Raise(); //Player Inventory Prefab listening
        }
        //Check if right trigger pressed
        if (rightTrigger > 0)
        {
            //Throw
            player.SetThrowForce(rightTrigger);
            //print("Right: " + rightTrigger);
            itemThrownRightEvent.Raise(); //Player Inventory Prefab listening
        }
    }

    private void Consume()
    {
        //if either player pressed their consume button
        if(Input.GetButtonDown(leftConsume) || Input.GetButtonDown(rightConsume))
        {
            if (inventory.GetItemCount() > 0)
            {
                //Consume the first pick up in the list
                //print("!TASTY MOONSHINE!");
                itemConsumedEvent.Raise(); //Player Inventory Prefab listening
            }
        }
    }
    private void CyclePickups()
    {
        //if either the left or right bumper was pressed cycle to the next pickup
        if(Input.GetButtonDown(leftCyclePickUp) || Input.GetButtonDown(rightCyclePickUp))
        {
            //print("CycleInventory");
            cycleInventoryEvent.Raise(); //Player Inventory Prefab listening
        }
    }
    private void PauseMenu()
    {
        //if the y button is pressed pause the game and display menu
        if(Input.GetButtonDown(pause))
        {
            //print("PAUSE GAME");
            player.RaisePauseGameEvent();
        }
    }

    private void ResetCar()
    {
        if(Input.GetButtonDown(reset))
        {
            //print("RESETING");
            player.RaiseResetPlayerEvent();
        }
    }

    //Set enable control bool
    public void EnableControl()
    {
        contolsEnabled = !contolsEnabled;
    }
}
