using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviors : MonoBehaviour
{
    public float angle;
    // Speed domain [0.0 - 1.0]
    public float speed;


    private Rigidbody2D rig;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rig = this.gameObject.GetComponent<Rigidbody2D>();
        velocity = new Vector2(speed * Mathf.Rad2Deg * Mathf.Cos(angle), speed * Mathf.Rad2Deg * Mathf.Sin(angle));
        rig.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
