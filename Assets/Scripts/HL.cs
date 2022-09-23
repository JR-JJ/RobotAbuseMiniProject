using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HL : MonoBehaviour
{
    //list of materials for highlight
    private List<Renderer> rendering = new List<Renderer>();

    private void Start()
    {
        rendering.AddRange(GetComponentsInChildren<Renderer>());
    }

    private void OnMouseEnter()
    {
        foreach (Renderer gOR in rendering)
        {
            gOR.material.color = Color.yellow;
        }
    }

    private void OnMouseExit()
    {
        foreach (Renderer gOM in rendering)
        {
            gOM.material.color = Color.white;
        }
    }
}
