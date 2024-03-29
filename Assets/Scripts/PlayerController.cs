﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float dashTime;
    private Rigidbody rb;
    private Vector3 input;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) 
            || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)
            || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow)
            || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            UtilityHelper.ChangeRotation(transform, input);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        velocity = input * speed;
        rb.velocity = velocity;
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        float oldSpeed = speed;

        while (Time.time < startTime + dashTime)
        {
            speed = 40f;

            yield return null;
        }

        speed = oldSpeed;
    }
}
