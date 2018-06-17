using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {



    // Use this for initialization
    Rigidbody2D _playerRigidbody;
    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

            Debug.DrawRay(transform.position,Vector3.forward,Color.yellow);
    }

    public void SetMoveDirection(Vector3 vec)
    {

    }

    Vector3 _direction = Vector3.forward;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        
       // Debug.Log("Collision " + collision.gameObject.name);
        //Ray MyRay = ObjectHit.position - ObjectFalling.position;

        //this will declare a variable which will store information about the object hit
        RaycastHit MyRayHit;
        if(Physics.Raycast(transform.position,Vector3.forward,out MyRayHit,0.5f))
        {
            if (MyRayHit.collider.gameObject == collision.gameObject)
            {
                Debug.Log("hit");
                Debug.DrawRay(transform.position, Vector3.forward, Color.red, 5f);
                LevelMgr.Current.ToLose();
            }
        }


    }

    internal void Jump()
    {
        _playerRigidbody.AddForce(Vector2.up * 500f);
    }
}
