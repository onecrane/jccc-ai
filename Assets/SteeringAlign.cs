using UnityEngine;
using System.Collections;

public class SteeringAlign : MonoBehaviour {

    public Transform target;

    public float targetRange = 2;
    public float outerRange = 30;

    private CharacterSteeringMotor steeringMotor;

    // Use this for initialization
    void Start()
    {
        steeringMotor = GetComponent<CharacterSteeringMotor>();
    }

	// Update is called once per frame
	void Update () {

        if (target != null)
        {
            DelegatedSteer(steeringMotor, target.forward, targetRange, outerRange);
        }
	}

    public static void DelegatedSteer(CharacterSteeringMotor motor, Vector3 targetDirection)
    {
        DelegatedSteer(motor, targetDirection, motor.alignmentInnerRadius, motor.alignmentOuterRadius);
    }

    public static void DelegatedSteer(CharacterSteeringMotor motor, Vector3 targetDirection, float targetRange, float outerRange)
    {
        Transform transform = motor.transform;

        float angle = Vector3.Angle(targetDirection, transform.forward);
        Vector3 cross = Vector3.Cross(targetDirection, transform.forward);
        float deltaAngle = angle * cross.y < 0 ? 1 : -1;    // Maybe?

        // If we're within targetRange, we don't need to adjust.
        if (angle < targetRange) return;

        // If we're outside the slowdown range, we want maximum turning.
        // Assume we are.
        float targetRotation = motor.maxRotation;
        if (angle < outerRange)
        {
            targetRotation *= angle / outerRange;
        }
        targetRotation *= angle / deltaAngle;

        float adjustment = targetRotation - motor.rotation;

        motor.Steer(adjustment);

    }
}
