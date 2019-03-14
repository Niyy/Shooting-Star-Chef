using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviors : MonoBehaviour
{
    private PlanetStructure thisPlanet;


    public void Start()
    {
        SetUp();

        Rigidbody2D rig2D = this.GetComponent<Rigidbody2D>();

        if(rig2D.mass <= 0)
        {
            rig2D.mass = 1;
            Debug.Log(this.name + ": Mass was 0 or less. Mass set to 0");
        }

        thisPlanet = new PlanetStructure(this.GetComponent<CircleCollider2D>().radius, rig2D.mass, this.transform.position);
    }


    private void SetUp()
    {
        if(!this.GetComponent<CircleCollider2D>())
        {
            CircleCollider2D circleCo = this.gameObject.AddComponent<CircleCollider2D>();
            circleCo.radius = 1;
        }

        if(!this.GetComponent<Rigidbody2D>())
        {
            Rigidbody2D rig2D = this.gameObject.AddComponent<Rigidbody2D>();
        }
    }


    private PlanetStructure GetPlanetStructure()
    {
        return thisPlanet;
    }
}
