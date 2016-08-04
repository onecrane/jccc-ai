using UnityEngine;
using System.Collections;

public class CharacterSteeringMotor : MonoBehaviour {

    public float maxSpeed = 3;
    public float maxAcceleration = 1;   // Affects how much a behavior can alter velocity
    public float maxRotation = 180;     
    public float maxRotationAcceleration = 1;    // Affects how much a behavior can alter rotation

    public float alignmentInnerRadius = 2;
    public float alignmentOuterRadius = 90;

    public Vector3 FrameAcceleration { get; private set; }

    public Vector3 velocity = Vector3.zero;
    public float rotation = 0;

    private Rigidbody characterBody;

    public bool isGrounded;

    void Awake()
    {
        characterBody = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {


	}

    void Update()
    {
        FrameAcceleration = Vector3.zero;
    }

    public void Steer(float turning)
    {
        // We want to change our rotation by this amount. Have to clamp, only so much we can change at once.
        turning = Mathf.Clamp(turning, -maxRotationAcceleration * Time.deltaTime, maxRotationAcceleration * Time.deltaTime);

        rotation += turning;

    }

    // Steer in the given direction at a factor of maximum acceleration
    public void Steer(Vector3 steering, float accelerationFactor)
    {
        if (steering == Vector3.zero) return;

        accelerationFactor = Mathf.Clamp(accelerationFactor, 0, 1);
        steering = steering.normalized * accelerationFactor * maxAcceleration * Time.deltaTime;
        
        // Clamp by acceleration
        float accelerationMagnitude = maxAcceleration * accelerationFactor * Time.deltaTime;
        if (steering.magnitude > accelerationMagnitude) steering = steering.normalized * accelerationMagnitude;
        
        FrameAcceleration += steering;

        velocity += steering;
    }

    // Steer in the given direction at maximum acceleration
    public void Steer(Vector3 steering)
    {
        Steer(steering, 1);
    }

    void LateUpdate()
    {
        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        rotation = Mathf.Clamp(rotation, -maxRotation, maxRotation);
        transform.Rotate(transform.up, rotation * Time.deltaTime);
    }

    void FixedUpdate()
    {
        characterBody.velocity = new Vector3(velocity.x, characterBody.velocity.y, velocity.z);
    }

}
