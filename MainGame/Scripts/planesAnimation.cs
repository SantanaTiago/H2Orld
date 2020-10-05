using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class planesAnimation : MonoBehaviour
{

    public GameObject firstPlane;
    public GameObject secondPlane;
    public GameObject thirdPlane;
    public GameObject balde;
    Transform target;
    Vector3 initialPositionFirstPlane;
    Vector3 positionFirstPlane;
    Vector3 initialPositionSecondPlane;
    Vector3 positionSecondPlane;
    Vector3 initialPositionThirdPlane;
    Vector3 positionThirdPlane;
    Vector3 initialPositionBlade;
    Vector3 positionBalde;


    // Use this for initialization
    void Start()
    {
        //save initial position of the 3planes and the bucket

        initialPositionFirstPlane = firstPlane.transform.position;
        initialPositionSecondPlane = secondPlane.transform.position;
        initialPositionThirdPlane = thirdPlane.transform.position;
        initialPositionBlade = balde.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //save the vale of X of the bucket. The use that value to add to the X of the planes, dividing that value so they become smaller and have different movements 

        positionBalde.x = initialPositionBlade.x- balde.transform.position.x;
        firstPlane.transform.position = initialPositionFirstPlane + new Vector3(positionBalde.x / 2, 0f, 0f);
        secondPlane.transform.position = initialPositionSecondPlane + new Vector3(positionBalde.x / 5, 0f, 0f);
        thirdPlane.transform.position = initialPositionThirdPlane + new Vector3(positionBalde.x / 10, 0f, 0f);
    }
}
   
