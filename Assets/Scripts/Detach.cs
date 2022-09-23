using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Detach : MonoBehaviour
{

    [SerializeField] private Transform robotTorso;
    private float zCoordinate = 0.0f;
    private Vector3 startPosition;
    public float distOrigin;
    [SerializeField] public bool detached = false;
    public Text infoText;
    [SerializeField] private string _attached = "Attached";
    [SerializeField] private string _detached = "Detached";
    [SerializeField] private string torsoTag = "Torso";


    // Start is called before the first frame update
    void Start()
    {
        robotTorso = GameObject.FindGameObjectWithTag(torsoTag).transform;
        startPosition = transform.position;   
    }
    private void OnMouseDown()
    {
        zCoordinate = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    private Vector3 MouseToWorldPoint()
    {
        Vector3 mouseCoord = Input.mousePosition;
        mouseCoord.z = zCoordinate;

        return Camera.main.ScreenToWorldPoint(mouseCoord);
    }

    private void OnMouseDrag()
    {
        transform.position = MouseToWorldPoint();
    }

    private void OnMouseUp()
    {
        
        if(Vector3.Distance(transform.localPosition, startPosition) <= distOrigin)
        {
            transform.localPosition = startPosition;
            detached = false;
            transform.SetParent(robotTorso);
            if(transform.tag != torsoTag)
            {
                infoText.text = transform.name + _attached;
            }
        }
        else
        {
            detached = true;
            
            if (transform.tag != torsoTag)
            {
                transform.parent = null;
                infoText.text = transform.name + _detached;
            }
            
        }
        startPosition = transform.position;

    }
    private void OnMouseEnter()
    {
        if(transform.tag == torsoTag)
        {
            infoText.text = transform.name;
        }
        else if (!detached)
        {
            infoText.text = transform.name + _attached;
        }
        else
        {
            infoText.text = transform.name + _detached;
        }
    }

    private void OnMouseExit()
    {
        infoText.text = null;
    }

    
}