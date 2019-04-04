using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviors : MonoBehaviour
{
    public GameObject foodPref;
    public GameObject pointOfRotation;


    private float speedCommand;
    private float angleCommand;
    private float raidusFromPoint;
    private GameObject foodNow;


    // Start is called before the first frame update
    void Start()
    {
        raidusFromPoint = Vector2.Distance(this.transform.position, pointOfRotation.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePos.x - pointOfRotation.transform.position.x;
        float y = mousePos.y - pointOfRotation.transform.position.y;
        float angleCommand = Mathf.Rad2Deg * Mathf.Atan2(y, x);
        speedCommand = Vector2.Distance(this.transform.position, mousePos);
        this.transform.position = new Vector2(raidusFromPoint * Mathf.Cos(Mathf.Deg2Rad * angleCommand) + pointOfRotation.transform.position.x,
                                                raidusFromPoint * Mathf.Sin(Mathf.Deg2Rad * angleCommand) + pointOfRotation.transform.position.y);
        this.transform.rotation = Quaternion.Euler(0, 0, angleCommand + 90);

        if (Input.GetKeyDown(KeyCode.Mouse0) && !foodNow)
        {
            foodNow = Instantiate(foodPref, this.transform.position, Quaternion.identity);
            foodNow.tag = "Food";
            foodNow.GetComponent<FoodBehaviors>().SetInitVelocity(speedCommand, angleCommand);

            Debug.Log("FIRE!");
        }
    }
}
