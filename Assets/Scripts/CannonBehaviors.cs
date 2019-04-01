using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviors : MonoBehaviour
{
    public GameObject foodPref;
    public Vector2 pointOfRotation;
    public float raidusFromPoint;


    public float speedCommand;
    public float angleCommand;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePos.x - this.transform.position.x;
        float y = mousePos.y - this.transform.position.y;
        float angleCommand = Mathf.Rad2Deg * Mathf.Atan2(y, x);
        speedCommand = Vector2.Distance(this.transform.position, mousePos);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var food = Instantiate(foodPref, this.transform.position, Quaternion.identity);
            food.tag = "Food";
            food.GetComponent<FoodBehaviors>().SetInitVelocity(speedCommand, angleCommand);

            Debug.Log("FIRE!");
        }
    }
}
