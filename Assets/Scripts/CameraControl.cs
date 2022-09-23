using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //robot reference transform
    public Transform target;
    public float speed = 1;
   
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CameraMovement());
    }
    
    IEnumerator CameraMovement()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            transform.RotateAround(target.position, Vector3.up, speed * Input.GetAxis("Horizontal"));
            yield return null;
        }
        if(Input.GetAxis("Vertical") != 0){
            transform.RotateAround(target.position, transform.TransformDirection(Vector3.right), speed * Input.GetAxis("Vertical"));
            yield return null;
        }
    }
}