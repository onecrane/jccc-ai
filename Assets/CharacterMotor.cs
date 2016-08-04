using UnityEngine;
using System.Collections;

public class CharacterMotor : MonoBehaviour {

    public float maxSpeed = 3;
    public float speed = 3;

    public Vector3 directionOfMovement;

    private Vector3 gravity = Vector3.zero;
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
    }

    void FixedUpdate()
    {
        if (speed > maxSpeed) speed = maxSpeed;
        Vector3 movement = directionOfMovement.normalized * speed;
        characterBody.velocity = new Vector3(movement.x, characterBody.velocity.y, movement.z);

    }

}
