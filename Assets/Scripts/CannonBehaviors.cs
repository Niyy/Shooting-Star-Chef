using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviors : MonoBehaviour
{
    public GameObject foodPref;


    public float SpeedCommand;
    public float angleCommand;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var food = Instantiate(foodPref, this.transform.position, Quaternion.identity);
            food.GetComponent<FoodBehaviors>().SetInitVelocity(SpeedCommand, angleCommand);

            Debug.Log("FIRE!");
        }
    }
}
