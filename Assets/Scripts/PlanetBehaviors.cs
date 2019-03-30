using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviors : MonoBehaviour
{
    private Rigidbody2D rig;
    private GameObject food;


    // Start is called before the first frame update
    void Start()
    {
        food = GameObject.FindGameObjectWithTag("Food");
        rig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GravityUpdate();
    }


    private void GravityUpdate()
    {
        // Find F = (mm)/d^2
        float distance = Mathf.Pow(Vector2.Distance(food.transform.position, this.transform.position), 2);
        float force = (food.GetComponent<Rigidbody2D>().mass * this.rig.mass) / distance;

        // Find the direction of new force
        float x = (this.transform.position.x - food.transform.position.x);
        float y = (this.transform.position.y - food.transform.position.y);
        float angle = Mathf.Atan2(y, x);

        Vector2 newVelocity = new Vector2(force * Mathf.Cos(angle), force * Mathf.Sin(angle));

        food.GetComponent<FoodBehaviors>().AddVelocity(newVelocity);
    }
}
