using UnityEngine;
using System.Collections;

public class LineDebugging : MonoBehaviour {


    private Transform a, b, c, d, intersection;


	// Use this for initialization
	void Start () {
        a = transform.FindChild("A");
        b = transform.FindChild("B");
        c = transform.FindChild("C");
        d = transform.FindChild("D");
        intersection = transform.FindChild("Intersection");
    }



    // Update is called once per frame
    void Update () {

        LineSegment l1 = new LineSegment(a.position, b.position);

        Vector3 closest = l1.ClosestPoint(c.position);
        closest.y = a.position.y;
        intersection.position = closest;

	}



}
