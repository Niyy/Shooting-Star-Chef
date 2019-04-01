using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviors : MonoBehaviour
{
    public GameObject foodPref;
    public Vector2 pointOfRotation;
    public float raidusFromPoint;


    public float SpeedCommand;
    public float angleCommand;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - this.transform.position.x;
        float y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - this.transform.position.y;
        float angleCommand = Mathf.Rad2Deg * Mathf.Atan2(y, x);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var food = Instantiate(foodPref, this.transform.position, Quaternion.identity);
            food.GetComponent<FoodBehaviors>().SetInitVelocity(SpeedCommand, angleCommand);

            Debug.Log("FIRE!");
        }
    }
}
