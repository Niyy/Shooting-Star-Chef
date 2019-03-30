using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviors : MonoBehaviour
{
    public float angle;
    // Speed domain [0.0 - 5.0]
    public float speed;


    private Rigidbody2D rig;
    private Vector2 velocity;

    // Start is called before the first frame update
    public void Start()
    {
        velocity = new Vector2(speed * Mathf.Cos(Mathf.Deg2Rad * angle), speed * Mathf.Sin(Mathf.Deg2Rad * angle));
        Debug.Log("Velocity: " + velocity + "\nSin: " + Mathf.Cos(Mathf.Deg2Rad * angle) + "\nCos: " + Mathf.Sin(Mathf.Deg2Rad * angle));
        rig = this.gameObject.GetComponent<Rigidbody2D>();
        rig.velocity = velocity;
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
}
