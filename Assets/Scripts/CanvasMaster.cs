using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CanvasMaster : MonoBehaviour
{
    GameObject foodCounter;
    GameObject speed;


    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name.Equals("Speed"))
            {
                speed = child.gameObject;
            }
            else if (child.name.Equals("Food Count"))
            {
                foodCounter = child.gameObject;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
    }


    public void SetFoodAmount(int food)
    {
        foodCounter.GetComponent<Text>().text = "Food: " + food;
    }


    public void SetSpeedLocation(float speedNum, Vector3 mouseLocation)
    {
        speed.GetComponent<Text>().text = ((int)speedNum).ToString();
        speed.transform.position = Camera.main.WorldToScreenPoint(mouseLocation + new Vector3(0.15f, 0.15f, 0));

    }
}
