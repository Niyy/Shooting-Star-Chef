using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Attributes")]
    public GameObject rootCannon;
    public int endScene;
    [Header("Panel Attributes")]
    public GameObject losePanel;


    private GameObject cannon;
    private GameObject canvas;
    private CannonBehaviors cannonBehaviors;
    private SceneMaster sceneMaster;
    private bool spawnedPanel;
    private int foodTotal;


    public void Start()
    {
        spawnedPanel = false;
        sceneMaster = GameObject.FindGameObjectWithTag("Scene Master").GetComponent<SceneMaster>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        CannonPicker(rootCannon);
    }


    public void Update()
    {
        cannonBehaviors.UseCannon();
        CheckEmpty();
        GatherFoodAmount();
    }


    public void CannonPicker(GameObject newCannon)
    {
        cannonBehaviors = newCannon.GetComponent<CannonBehaviors>();
        cannon = newCannon;
    }


    public void GatherFoodAmount()
    {
        foodTotal = 0;

        foreach (GameObject cannon in GameObject.FindGameObjectsWithTag("Cannon"))
        {
            foodTotal += cannon.GetComponent<CannonBehaviors>().FoodAmmo();
        }

        canvas.GetComponent<CanvasMaster>().SetFoodAmount(foodTotal);

        /*Vector3 mousePos = cannonBehaviors.GetMousePos();
        Vector3 mouseOffsetPos = (new Vector3((0.15f * cannonBehaviors.CalculateAngle()) + mousePos.x,
                                    (0.15f * cannonBehaviors.CalculateAngle()) + mousePos.y, 0));
                                    */
        canvas.GetComponent<CanvasMaster>().SetSpeedLocation(cannonBehaviors.SpeedCommand(), cannonBehaviors.GetMousePos());
    }


    private void CheckEmpty()
    {
        if (cannonBehaviors.FoodAmmo() <= 0)
        {
            if (cannon == rootCannon && !cannonBehaviors.FoodNow() && !spawnedPanel)
            {
                spawnedPanel = true;
                //sceneMaster.ChangeScene(endScene);
                GameObject panel = Instantiate(losePanel);
                panel.transform.SetParent(canvas.transform, false);

                SetUpButton(panel);

                RectTransform panelRect = panel.GetComponent<RectTransform>();
            }
            else if (!cannonBehaviors.FoodNow())
            {
                CannonPicker(rootCannon);
            }
        }
    }


    private void SetUpButton(GameObject panel)
    {
        Button[] buttons = panel.GetComponentsInChildren<Button>();
        if (buttons[0] && buttons[0].tag.Equals("Button0"))
        {
            buttons[0].onClick.AddListener(ButtonOne);
            Debug.Log("Button one set up!");
        }

        if (buttons[1] && buttons[1].tag.Equals("Button1"))
        {
            buttons[1].onClick.AddListener(ButtonTwo);
            Debug.Log("Button two set up!");
        }
    }


    private void ButtonOne()
    {
        sceneMaster.ChangeScene(sceneMaster.GetCurrentScene());
    }


    private void ButtonTwo()
    {
        sceneMaster.ChangeScene(0);
    }
}
