﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public enum Gender
    {
        male,
        female
    }

    public Gender gen = Gender.male;

    // Use this for initialization
    Rigidbody2D _playerRigidbody;
    Animator _animator;
    int _dir = 1;
    float strength = 1;


    public AnimationClip[] femalClips;
    private void Awake()
    {
        if(gen == Gender.female)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            _dir = -1;
            strength = 0.8f;

        }
    }

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
        Vector3 speed = _playerRigidbody.velocity;
        float y = speed.y;
        float x = speed.x;
        float m = 0;
        if(x >0.01f || x < -0.01f)
        {
            m = y / x * 7;
        }
        transform.localEulerAngles = new Vector3(0, 0, m);
          
    }

    public void SetMoveDirection(Vector3 vec)
    {

    }

    Vector3 _direction = Vector3.forward;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        
   


    }

    internal void Jump(Vector3 x)
    {
        _playerRigidbody.AddForce(Vector2.up * 200f);
        Vector2 forward = transform.right;
        int dir = 1;
        if (x.x > Screen.width / 2)
        {
            dir = -1;
            transform.localScale = new Vector3(-1, 1, 1);
        } else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        Vector3 current = _playerRigidbody.velocity;
        _playerRigidbody.velocity = Vector3.zero;// new Vector3(0, current.y, 0);
        _playerRigidbody.AddForce(forward * 80f * dir * _dir * strength);
        _animator.SetTrigger("Flap");
    }
}
