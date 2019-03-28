using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece
{
    private float radius;
    private float mass;
    private string cookingSystem;
    private Vector2 position;

    // Initialization //
    public void ObjectsStructure(float radius, float mass, Vector2 position)
    {
        if (radius <= 0)
            this.radius = 1;
        else
            this.radius = radius;

        this.mass = mass;
        this.position = position;
    }


    public void ObjectsStructure(float radius, float mass, string cookingSystem)
    {
        this.radius = radius;
        this.mass = mass;
        this.cookingSystem = cookingSystem;
    }


    // Get Statements //
    public float GetRadius()
    {
        return radius;
    }


    public float GetMass()
    {
        return mass;
    }


    public string GetCookingSystem()
    {
        return cookingSystem;
    }


    public Vector2 GetPosition()
    {
        return position;
    }


    // Set Statements //
    public void SetRadius(float radius)
    {
        if (radius <= 0)
            radius = 0;
        else
            this.radius = radius;
    }


    public void SetMass(float mass)
    {
        this.mass = mass;
    }


    public void SetCookingSystem(string cookingSystem)
    {
        this.cookingSystem = cookingSystem;
    }


    public void SetMass(Vector2 position)
    {
        this.position = position;
    }
}
