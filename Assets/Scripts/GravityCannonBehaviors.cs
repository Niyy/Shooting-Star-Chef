// author - Austin Meyer 
// email - meyerforge@gmail.com
// file name - GravityCannonBehaviors.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCannonBehaviors : MonoBehaviour
{
    private float distanceToGrab;
    private float artificalStrength;
    private GameObject[] food;
    private bool activeGrav;


    void Update()
    {
        if (activeGrav)
        {
            FindFood();

            foreach (GameObject pieceOf in food)
            {
                GrabProjectile(pieceOf);
            }
        }
    }


    private void GrabProjectile(GameObject projectile)
    {
        if (Vector2.Distance(projectile.transform.position, this.transform.position) <= distanceToGrab)
        {
            // Find the direction of new force
            float x = (this.transform.position.x - projectile.transform.position.x);
            float y = (this.transform.position.y - projectile.transform.position.y);
            float angle = Mathf.Atan2(y, x);

            Vector2 newVelocity = new Vector2(artificalStrength * Mathf.Cos(angle), artificalStrength * Mathf.Sin(angle));

            projectile.GetComponent<FoodBehaviors>().Velocity(newVelocity);
        }
    }


    private float CalculateDistance(GameObject pieceOf)
    {
        return Mathf.Pow(Vector2.Distance(pieceOf.transform.position, this.transform.position), 2);
    }


    private void FindFood()
    {
        food = GameObject.FindGameObjectsWithTag("Food");
    }


    public void DistanceToGrab(float newDis)
    {
        distanceToGrab = newDis;
    }


    public void ArtificalStrength(float newStrength)
    {
        artificalStrength = newStrength;
    }


    public void ActiveGravity(bool isActive)
    {
        activeGrav = isActive;
    }


    public bool ActiveGravity()
    {
        return activeGrav;
    }
}
