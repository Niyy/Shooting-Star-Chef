using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBehavior : MonoBehaviour
{
    private GameObject sceneMaster;


    public void Start()
    {
        sceneMaster = GameObject.FindGameObjectWithTag("Scene Manager");
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Food") && col.GetComponent<FoodBehaviors>().IsThisFoodCooked())
        {
            sceneMaster.GetComponent<SceneMaster>().ChangeScene(2);
        }
        else
        {
            Destroy(col.gameObject);
        }
    }
}
