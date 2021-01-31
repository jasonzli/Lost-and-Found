using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AnimalProperties{
    public Vector3 Position;
    public Vector3 Velocity;
    public Vector3 Acceleration;
    public float MaxVelocity;
    public float Heading;
    public float Time;

    public AnimalProperties(Vector3 _p, float _mv, float _h, float _t){
        this.Position = _p;
        this.Velocity = Vector3.zero;
        this.Acceleration = Vector3.zero;
        this.MaxVelocity = _mv;
        this.Heading = _h;
        this.Time = _t;
    }
}
public class Animal : MonoBehaviour
{

    [SerializeField]
    private Transform camTransform;

    [SerializeField]
    private Renderer render;
    private MaterialPropertyBlock block;
    private AnimalProperties _prop;
    private CharacterController controller;
    public Transform CamTransform{
        get { return camTransform;}
        private set { camTransform = value;}
    }
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        _prop = new AnimalProperties(transform.position, Random.Range(1f,20f), Random.Range(0f,360f), Random.Range(2f,5f));
    }

    void Update(){
        Vector3 move = new Vector3( Mathf.Cos(_prop.Heading), 0 , Mathf.Sin(_prop.Heading));
        controller.Move(move * Time.deltaTime * _prop.MaxVelocity);

        if (move != Vector3.zero){
            gameObject.transform.forward = Vector3.Lerp(gameObject.transform.forward,move,.2f);
        }

        if (GoingOutOfBounds() || OutOfTime()){
            _prop.Heading = NewHeading();
            _prop.MaxVelocity = Random.Range(3f,20f);
        }

        if (OutOfTime()) _prop.Time += Random.Range(2f,5f);

        _prop.Time -= Time.deltaTime;
    }



    float NewHeading(){
        return Random.Range(0f,360f);
    }


    bool OutOfTime(){
        return _prop.Time < 0f;
    }
    bool GoingOutOfBounds(){
        var p = transform.position;
        return ( p.x > 125f || p.x < -125f || p.z > 125f || p.z < -125f);
    }

    ///////////
    //
    // Public Functions
    //
    //////////////////////

    public void SetCameraToTransform(Transform cam){
        cam.parent = camTransform;
        cam.position = camTransform.position;
        cam.localRotation = camTransform.localRotation;
    }

    public void BecomePrimal(){
        if (block == null) block = new MaterialPropertyBlock();
        render.GetPropertyBlock(block);
        block.SetColor("_BodyColor", Color.red);
        render.SetPropertyBlock(block);
    }
}
