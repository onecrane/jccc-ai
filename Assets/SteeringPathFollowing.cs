using UnityEngine;
using System.Collections;

public class SteeringPathFollowing : MonoBehaviour {

    public Path path;
    public float projectionDistance = 5;
    private CharacterSteeringMotor motor;

    private Transform seekTarget;

	// Use this for initialization
	void Start () {
        motor = GetComponent<CharacterSteeringMotor>();
        seekTarget = transform.FindChild("seekTarget");

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 target = path.ProjectDownPath(transform.position, projectionDistance);
        target.y = transform.position.y;
        SteeringSeek.DelegatedSteer(motor, target);

        seekTarget.position = target;

	}
}
