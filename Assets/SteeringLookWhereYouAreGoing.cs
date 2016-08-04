using UnityEngine;
using System.Collections;

public class SteeringLookWhereYouAreGoing : MonoBehaviour {

    private CharacterSteeringMotor myMotor;

	// Use this for initialization
	void Start () {
        myMotor = GetComponent<CharacterSteeringMotor>();

    }
	
	// Update is called once per frame
	void Update () {

        SteeringAlign.DelegatedSteer(myMotor, myMotor.velocity);

    }
}
