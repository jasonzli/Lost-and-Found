using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDPlayer : MonoBehaviour
{

    [SerializeField] 
    private Camera cam;
    
    [SerializeField]
    private Transform selected;

    [SerializeField]
    private int SortingLayer;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            selected = TargetAtRay();
        }
    }

    Transform TargetAtRay () {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        int layerMask = 1 << SortingLayer; //bitshift against this to only hit that layer
        // layerMask = ~layerMask; // this reverses it to everything but thatl ayer.

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)){
            Transform objectHit = hit.transform;
            return objectHit;
        }

        return null;
    }
}
