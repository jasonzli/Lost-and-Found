﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TDPlayer : MonoBehaviour
{

    [SerializeField] 
    private Camera cam;
    
    [SerializeField]
    private Transform selected; 

    [SerializeField]
    private TextMeshProUGUI textObj;

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
        MoveToSelected();

        if ( (selected == null ? false : selected.gameObject.GetComponentInParent<Animal>().Primal)){
            CorrectSelection();
        }

        
        Vector3 move = new Vector3( Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        cam.transform.position += move * 3f;
    }

    void CorrectSelection(){
        textObj.text = "You have found me!";
    }
    void MoveToSelected(){
        if(!selected) return;

        cam.transform.position = Vector3.Lerp(new Vector3(selected.transform.position.x, 100, selected.transform.position.z), cam.transform.position,0.3f);
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
