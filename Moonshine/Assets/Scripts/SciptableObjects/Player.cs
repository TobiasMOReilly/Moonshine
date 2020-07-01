using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player/Player")]

public class Player : ScriptableObject
{

    [SerializeField] private string playerName;
    [SerializeField] private FloatReference maxLives;
    [SerializeField] private FloatReference accelerateForce;
    [SerializeField] private FloatReference turnForce;
    [SerializeField] private FloatReference throwForce;

    [SerializeField] private GameEvent playerOffScreenEvent;
    [SerializeField] private GameEvent outOfBoundsEvent;
    [SerializeField] private GameEvent pauseGameEvent;
    [SerializeField] private GameEvent resetPlayerEvent;
    [SerializeField] private GameEvent PlayerDeadEvent;
    [SerializeField] private GameEvent resetTransformEvent;

    public float currentLives;
    public float currentAccelerateForce;
    private float currentTurnForce;
    private float currentThrowForce;
    private bool invertControl = false;
    private Vector3 currentPosition;
    private Vector3 resetPosition;
    private Transform resetTransform;
    private Transform currentTransform;
    private bool isDead;
    public bool onTrack { get; set; }
    public bool isWinner { get; set; }
    private GameObject currentCheckPoint;
    public int jugsCollected { get; set; }
    public int jugsThrown { get; set; }
    public int jugsConsumed { get; set; }
    public string timeToFinish { get; set; }

    private void OnEnable()
    {
        currentAccelerateForce = accelerateForce.Value;
        currentTurnForce = turnForce.Value;
        currentThrowForce = throwForce.Value;
        currentLives = maxLives.Value;
        invertControl = false;
        isDead = false;
        onTrack = true;
        currentCheckPoint = null;
        jugsCollected = 0;
        jugsThrown = 0;
        jugsConsumed = 0;
        isWinner = false;
    }
    private void OnDisable()
    {
        currentAccelerateForce = accelerateForce.Value;
        currentTurnForce = turnForce.Value;
        currentThrowForce = throwForce.Value;
        currentLives = maxLives.Value;
        invertControl = false;
        isDead = false;
        onTrack = true;
        currentCheckPoint = null;
        jugsCollected = 0;
        jugsThrown = 0;
        jugsConsumed = 0;
        isWinner = false;
    }
    //Set / Get methods
    //Get set throw force
    public void SetThrowForce(float amount)
    {
        currentThrowForce = amount;
    }
    public float GetThrowForce()
    {
        return currentThrowForce;
    }
    //Get Set Reset current acceleration force
    public void SetCurrentAccelerateForce(float amount)
    {
        currentAccelerateForce = accelerateForce.Value + amount;
    }
    public void ResetAccelerateForce()
    {
        currentAccelerateForce = accelerateForce.Value;
    }
    public float GetCurrentAccelerateForce()
    {
        return currentAccelerateForce;
    }
    //Get Set Invert control
    public bool GetInvertControl()
    {
        return invertControl;
    }
    public void InvertControl()
    {
        invertControl = !invertControl;
    }
    //Update  Get Current Position Vector
    public void UpdateCurrentPosition(Vector3 position)
    {
        currentPosition = position;
    }
    public Vector3 GetCurrentPosition()
    {
        return currentPosition;
    }
    //Get Decrement current lives
    public float GetCurrentLives()
    {
        return currentLives;
    }
    public void DecrementLives()
    {
        currentLives--;

        if(currentLives < 0)
        {
            isDead = true;
        }
    }
    public void ResetCurrentLives()
    {
        currentLives = maxLives.Value;
    }
    //Get Set Reset Position Vector3
    public void SetResetPosition(Vector3 position)
    {
        //Set reset position to position - player length
        resetPosition = position;
    }
    public Vector3 GetResetPosition()
    {
        return resetPosition;
    }
    //Get Set Current Transform
    public void SetCurrentTransform(Transform current)
    {
        currentTransform = current;
    }
    public Transform GetCurrentTransform()
    {
        return currentTransform;
    }
    //Get Set Reset Transform
    public void SetResetTransform(Transform transform)
    {
        resetTransform = transform;
    }
    public Transform GetResetTransform()
    {
        return resetTransform;
    }
    //Get Set isDead
    public void SetIsDead()
    {
        isDead = true;
    }
    public bool IsDead()
    {
        return isDead;
    }
    //Get Set current checkpoint
    public void SetCurrentCheckPoint(GameObject checkPoint)
    {
        currentCheckPoint = checkPoint;
    }
    public GameObject GetCurrentCheckPoint()
    {
        return currentCheckPoint;
    }
    //Event Call Methods
    public void RaisePlayerOffScreenEvent()
    {
        playerOffScreenEvent.Raise();
    }
    public void RaiseOutOfBoundsEvent()
    {
        outOfBoundsEvent.Raise();
    }
    public void RaisePauseGameEvent()
    {
        pauseGameEvent.Raise();
    }
    public void RaiseResetPlayerEvent()
    {
        resetPlayerEvent.Raise();
    }
    public void RaisePlayerDeadEvent()
    {
        PlayerDeadEvent.Raise();
    }
    public void RaiseResetTransformEvent()
    {
        resetTransformEvent.Raise();
    }
}
