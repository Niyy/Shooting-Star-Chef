using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBehavior : MonoBehaviour
{
    public GameObject SceneMaster;


    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Food"))
        {
            SceneMaster.GetComponent<SceneMaster>().ChangeScene(2);
        }
    }
}
