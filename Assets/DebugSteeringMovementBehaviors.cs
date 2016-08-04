using UnityEngine;
using System.Collections.Generic;
using System;

public class DebugSteeringMovementBehaviors : MonoBehaviour {

    public CharacterSteeringMotor associatedMotor;

    private Transform velocityArrow;
    private Transform accelerationArrow;

    private Transform satisfactionRing;
    private Transform decelerationRing;

    public GameObject breadcrumbTemplate;
    public int maxBreadcrumbs = 50;
    public int breadcrumbsPerSecond = 4;
    private DateTime nextBreadcrumbDrop = DateTime.Now;

    private List<GameObject> breadcrumbs = new List<GameObject>();

	// Use this for initialization
	void Start () {

        velocityArrow = transform.FindChild("velocityArrow");
        accelerationArrow = transform.FindChild("accelerationArrow");
        satisfactionRing = transform.FindChild("satisfactionRing");
        decelerationRing = transform.FindChild("decelerationRing");

        if (breadcrumbsPerSecond > 10) breadcrumbsPerSecond = 10;
        if (breadcrumbsPerSecond < 0) breadcrumbsPerSecond = 0;

    }

    // Update is called once per frame
    void Update()
    {
        velocityArrow.position = associatedMotor.transform.position + new Vector3(0, 1, 0);
        velocityArrow.localScale = new Vector3(1, 1, associatedMotor.velocity.magnitude / associatedMotor.maxSpeed);
        velocityArrow.LookAt(velocityArrow.position + associatedMotor.velocity);

        accelerationArrow.position = associatedMotor.transform.position + new Vector3(0, 0.5f, 0);
        accelerationArrow.localScale = new Vector3(1, 1, 0.5f + associatedMotor.FrameAcceleration.magnitude);
        accelerationArrow.LookAt(accelerationArrow.position + associatedMotor.FrameAcceleration);

    }

    void OnGUI()
    {
        GUILayout.Label(associatedMotor.FrameAcceleration.ToString("F3"));
    }
}
