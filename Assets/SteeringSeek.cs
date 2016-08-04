using UnityEngine;
using System.Collections;

public class SteeringSeek : MonoBehaviour {

    public Transform target;

    private CharacterSteeringMotor steeringMotor;

	// Use this for initialization
	void Start () {
        steeringMotor = GetComponent<CharacterSteeringMotor>();
    }
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            steeringMotor.Steer(target.position - transform.position);
        }
    }

    public static void DelegatedSteer(CharacterSteeringMotor motor, Transform delegatedTarget)
    {
        motor.Steer(delegatedTarget.position - motor.transform.position);
    }

    public static void DelegatedSteer(CharacterSteeringMotor motor, Vector3 destination)
    {
        motor.Steer(destination - motor.transform.position);
    }
}
