using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDrag : MonoBehaviour {

    Plane movePlane;
    float fixedDistance = 0f;
    float hitDist, t;
    Ray camRay;
    Vector3 startPos, point, corPoint;

    void OnMouseDown()
    {
        //startPos = transform.position; // save position in case draged to invalid place
        movePlane = new Plane(-Camera.main.transform.forward, transform.position); // find a parallel plane to the camera based on obj start pos;
    }

    void OnMouseDrag()
    {
        if (pauseMenu.gamePaused == false) { 
        camRay = Camera.main.ScreenPointToRay(Input.mousePosition); // shoot a ray at the obj from mouse screen point

        if (movePlane.Raycast(camRay, out hitDist))
        { // finde the collision on movePlane
            point = camRay.GetPoint(hitDist); // define the point on movePlane
            t = -(fixedDistance - camRay.origin.z) / (camRay.origin.z - point.z); // the x,y or z plane you want to be fixed to
            corPoint.x = camRay.origin.x + (point.x - camRay.origin.x) * t; // calculate the new point t futher along the ray
            if (corPoint.x > 3.4f)
                corPoint.x = 3.4f;
            if (corPoint.x < -3.4f)
                corPoint.x = -3.4f;
            corPoint.y = -1f;
            corPoint.z = -1f;
            transform.position = corPoint;
        }
        }
    }
}
