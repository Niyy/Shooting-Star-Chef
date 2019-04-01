﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviors : MonoBehaviour
{
    private float angle;
    // Speed domain [0.0 - 5.0]
    private float speed;


    private Rigidbody2D rig;
    private Vector2 velocity;

    // Start is called before the first frame update
    public void Awake()
    {
        velocity = Vector2.zero;
        rig = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        rig.velocity = velocity;
    }


    public void AddVelocity(Vector2 addition)
    {
        velocity += addition;
    }


    public Vector2 CreateVelocity(float newSpeed, float newAngle)
    {
        speed = newSpeed;
        angle = newAngle;
        return new Vector2(newSpeed * Mathf.Cos(Mathf.Deg2Rad * newAngle), newSpeed * Mathf.Sin(Mathf.Deg2Rad * newAngle));
    }


    public void SetInitVelocity(float newSpeed, float newAngle)
    {
        velocity = CreateVelocity(newSpeed, newAngle);
        rig.velocity = velocity;
    }
}
