using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviors : MonoBehaviour
{
    public float maxDis;
    public float needCookValue;
    public float distanceToTranscribe;
    public Sprite[] foodList;
    public GameObject trajectoryMark;


    private float angle;
    // Speed domain [0.0 - 5.0]
    private float speed;
    private bool amICooked;
    private float cookValue;
    private Rigidbody2D rig;
    private Vector2 velocity;
    private GameObject curTrajectory;

    // Start is called before the first frame update
    public void Awake()
    {
        amICooked = false;

        if (maxDis <= 0)
        {
            maxDis = 50;
        }

        cookValue = 0;
        velocity = Vector2.zero;
        rig = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        rig.velocity = velocity;


        if (Vector2.Distance(Vector2.zero, this.transform.position) >= maxDis)
        {
            Destroy(this.gameObject);
            Debug.Log("Boom! " + "I died.");
        }

        TranscribeTrajectory();
    }


    public void AddVelocity(Vector2 addition)
    {
        velocity += addition;
    }


    public void Velocity(Vector2 newVelocity)
    {
        velocity = newVelocity;
    }


    public Vector2 CreateVelocity(float newSpeed, float newAngle)
    {
        speed = newSpeed;
        angle = newAngle;
        return new Vector2(newSpeed * Mathf.Cos(Mathf.Deg2Rad * newAngle), newSpeed * Mathf.Sin(Mathf.Deg2Rad * newAngle));
    }


    public void SetInitVelocity(float newSpeed, float newAngle)
    {
        velocity = CreateVelocity(newSpeed, newAngle);
        rig.velocity = velocity;
    }


    public void CookTimer()
    {
        cookValue += Time.deltaTime;

        if (cookValue >= needCookValue)
        {
            this.GetComponent<SpriteRenderer>().sprite = foodList[1];
            amICooked = true;
            Debug.Log("Cooked");
        }
        else
        {
            Debug.Log("Not Cooked");
        }
    }


    public void TranscribeTrajectory()
    {
        if(!curTrajectory)
        {
            curTrajectory = Instantiate(trajectoryMark, this.transform.position, this.transform.rotation);
        }
        if(Vector2.Distance(curTrajectory.transform.position, this.transform.position) >= distanceToTranscribe)
        {
            curTrajectory = Instantiate(trajectoryMark, this.transform.position, this.transform.rotation);
            Debug.Log("Transcribed!");
        }
    }


    public bool IsThisFoodCooked()
    {
        return amICooked;
    }
}
