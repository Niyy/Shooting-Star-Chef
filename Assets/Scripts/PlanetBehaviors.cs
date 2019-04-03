using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviors : MonoBehaviour
{
    private const float GRAV_CONST = 0.50f;


    public float mass;
    public float cookingRadius;



    private Rigidbody2D rig;
    private GameObject[] food;


    // Start is called before the first frame update
    void Start()
    {
        graitationalConst = 0.25f;
        food = GameObject.FindGameObjectsWithTag("Food");
        rig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        food = GameObject.FindGameObjectsWithTag("Food");
        AffectFood();
    }


    private void AffectFood()
    {
        foreach (GameObject pieceOf in food)
        {
            GravityUpdate(pieceOf);
            CookFood(pieceOf);
        }
    }


    private void GravityUpdate(GameObject pieceOf)
    {
        float force = 0;
        food = GameObject.FindGameObjectsWithTag("Food");


        // Find F = (mm)/d^2
        force = ((pieceOf.GetComponent<Rigidbody2D>().mass * mass) / CalculateDistance(pieceOf)) * GRAV_CONST;

        Vector2 newVelocity = new Vector2(force * Mathf.Cos(CalculateAngle(pieceOf)), force * Mathf.Sin(CalculateAngle(pieceOf)));

        pieceOf.GetComponent<FoodBehaviors>().AddVelocity(newVelocity);
    }


    private void CookFood(GameObject pieceOf)
    {
        if (cookingRadius >= CalculateDistance(pieceOf))
        {
            pieceOf.GetComponent<FoodBehaviors>().CookTimer();
        }
    }


    private float CalculateDistance(GameObject pieceOf)
    {
        return Mathf.Pow(Vector2.Distance(pieceOf.transform.position, this.transform.position), 2);
    }


    private float CalculateAngle(GameObject pieceOf)
    {
        // Find the direction of new force
        float x = (this.transform.position.x - pieceOf.transform.position.x);
        float y = (this.transform.position.y - pieceOf.transform.position.y);

        return Mathf.Atan2(y, x);
    }
}
