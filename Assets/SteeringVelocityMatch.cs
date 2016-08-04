using UnityEngine;
using System.Collections;

public class SteeringVelocityMatch : MonoBehaviour {

    public Transform target;

    private CharacterSteeringMotor steeringMotor;
    private Vector3 lastTargetPosition;

    // Use this for initialization
    void Start()
    {
        steeringMotor = GetComponent<CharacterSteeringMotor>();
        lastTargetPosition = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newTargetPosition = target.position;
        Vector3 targetVelocity = (newTargetPosition - lastTargetPosition) / Time.deltaTime;
        steeringMotor.Steer(targetVelocity);
        lastTargetPosition = newTargetPosition;
    }
}
