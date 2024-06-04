using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.UI.Scrollbar;

public class Slice : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera mainCamera;
    private Boolean slicing;
    private BoxCollider bladeCollider;
    private TrailRenderer bladeTrail;
    private Vector3 direction;
    private float minSliceVelocity;

    void Start()
    {
        StopSlice();
    }

    // Update is called once per frame
    private void Update()
    {
        if(UnityEngine.Input.GetMouseButtonDown(0)){
            StartSlice();
        }else if(UnityEngine.Input.GetMouseButtonUp(0)){
            StopSlice();
        }else if(slicing){
            continueSlice();
        }
    }
    private void StartSlice(){
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        newPosition.z = 0f;
        transform.position = newPosition;
        slicing = true;
        bladeCollider.enabled = true;
        bladeTrail.enabled = true;
        bladeTrail.Clear();
    }
    private void StopSlice(){
        slicing = false;
        bladeCollider.enabled = false;
        bladeTrail.enabled = false;
    }
    private void continueSlice(){
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        newPosition.z = 0f;
        direction = newPosition - transform.position;
        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;
        transform.position = newPosition;
    }
}
