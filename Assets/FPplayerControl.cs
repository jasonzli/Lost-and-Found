using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPplayerControl : MonoBehaviour
{
    private CharacterController controller;
    
    [SerializeField]
    private Vector3 playerVelocity;
    [SerializeField]
    private float playerSpeed = 2.0f;



    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3( Input.GetAxisRaw("Horizontal"), 0 , Input.GetAxisRaw("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero){
            gameObject.transform.forward = Vector3.Lerp(gameObject.transform.forward,move,.2f);
        }
    }
}
