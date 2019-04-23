using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviors : MonoBehaviour
{
    public float mass;
    public string cookingType;
    public float cookingRadius;


    private float graitationalConst;
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
        AffectFood();
    }


    private void GravityUpdate(GameObject pieceOf)
    {
        // Find F = (mm)/d^2
        float force = ((pieceOf.GetComponent<Rigidbody2D>().mass * mass) / CalculateDistance(pieceOf)) * graitationalConst;


        // Find the direction of new force
        float x = (this.transform.position.x - pieceOf.transform.position.x);
        float y = (this.transform.position.y - pieceOf.transform.position.y);
        float angle = Mathf.Atan2(y, x);

        Vector2 newVelocity = new Vector2(force * Mathf.Cos(angle), force * Mathf.Sin(angle));

        pieceOf.GetComponent<FoodBehaviors>().AddVelocity(newVelocity);
    }


    private float CalculateDistance(GameObject pieceOf)
    {
        return Mathf.Pow(Vector2.Distance(pieceOf.transform.position, this.transform.position), 2);
    }


    private void CookFood(GameObject pieceOf)
    {
        if(cookingRadius >= CalculateDistance(pieceOf) && cookingType.Equals("cook"))
        {
            pieceOf.GetComponent<FoodBehaviors>().CookTimer();
        }
    }


    private void AffectFood()
    {
        food = GameObject.FindGameObjectsWithTag("Food");

        if (food.Length > 0)
        {
            foreach (GameObject pieceOf in food)
            {
                GravityUpdate(pieceOf);
                CookFood(pieceOf);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
    }
}
