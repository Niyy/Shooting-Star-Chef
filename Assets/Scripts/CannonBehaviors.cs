// author - Austin Meyer 
// email - meyerforge@gmail.com
// file name - CannonBehaviors.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviors : MonoBehaviour
{
    [Header("Cannon Attributes")]
    public GameObject foodPref;
    public GameObject pointOfRotation;
    public int foodAmmo;
    [Header("Gravity Cannon Attributes")]
    public bool activateGravity;
    public float artificalStrength;
    public float distanceOfActivation;
    public float timeReactivate;


    private float speedCommand;
    private float angleCommand;
    private float raidusFromPoint;
    private float timeDeactivation;
    private GameObject foodNow;
    private GravityCannonBehaviors gravCannon;
    private PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        if (!pointOfRotation)
        {
            pointOfRotation = this.gameObject;
        }

        raidusFromPoint = Vector2.Distance(this.transform.position, pointOfRotation.transform.position);
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        timeDeactivation = -1;
        ActivateGravityCannonStats();
    }


    void FixedUpdate()
    {
        if (timeDeactivation != -1 && timeDeactivation + timeReactivate <= Time.time)
        {
            gravCannon.ActiveGravity(true);
            timeDeactivation = -1;
            Debug.Log("Reactivating gravCannon.");
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Food"))
        {
            Destroy(col.gameObject);
            playerController.CannonPicker(this.gameObject);
            foodAmmo++;
        }
    }


    private void ActivateGravityCannonStats()
    {
        gravCannon = GetComponentInChildren<GravityCannonBehaviors>();

        gravCannon.ActiveGravity(activateGravity);
        gravCannon.ArtificalStrength(artificalStrength);
        gravCannon.DistanceToGrab(distanceOfActivation);
    }


    public void UseCannon()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angleCommand = CalculateAngle();
        speedCommand = Vector2.Distance(this.transform.position, mousePos);
        this.transform.position = new Vector2(raidusFromPoint * Mathf.Cos(Mathf.Deg2Rad * angleCommand) + pointOfRotation.transform.position.x,
                                                raidusFromPoint * Mathf.Sin(Mathf.Deg2Rad * angleCommand) + pointOfRotation.transform.position.y);
        this.transform.rotation = Quaternion.Euler(0, 0, angleCommand + 90);

        if (foodAmmo > 0 && Input.GetKeyDown(KeyCode.Mouse0) && !foodNow)
        {
            if (gravCannon.ActiveGravity())
            {
                gravCannon.ActiveGravity(false);
                timeDeactivation = Time.time;
            }

            Vector3 spawnPoint = new Vector3(0.3f * Mathf.Cos(Mathf.Deg2Rad * angleCommand),
                                            0.3f * Mathf.Sin(Mathf.Deg2Rad * angleCommand));
            foodNow = Instantiate(foodPref, this.transform.position + spawnPoint, Quaternion.identity);
            foodNow.tag = "Food";
            foodNow.GetComponent<FoodBehaviors>().SetInitVelocity(speedCommand, angleCommand);
            foodAmmo--;

            Debug.Log("FIRE!");
        }
    }


    public float CalculateAngle()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePos.x - pointOfRotation.transform.position.x;
        float y = mousePos.y - pointOfRotation.transform.position.y;
        return Mathf.Rad2Deg * Mathf.Atan2(y, x);
    }


    public int FoodAmmo()
    {
        return foodAmmo;
    }


    public GameObject FoodNow()
    {
        return foodNow;
    }


    public float SpeedCommand()
    {
        return speedCommand;
    }


    public Vector3 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
