using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBehavior : MonoBehaviour
{
    public int nextScene;


    private GameObject sceneMaster;


    public void Start()
    {
        sceneMaster = GameObject.FindGameObjectWithTag("Scene Master");
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Food") && col.GetComponent<FoodBehaviors>().IsThisFoodCooked())
        {
            sceneMaster.GetComponent<SceneMaster>().ChangeScene(nextScene);
        }
        else
        {
            Destroy(col.gameObject);
        }
    }
}
