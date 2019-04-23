using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltComponent : MonoBehaviour
{
    float circleOne;
    float circleTwo;
    Vector2 center;

    public BeltComponent(float radOne, float radTwo, Vector2 location)
    {
        circleOne = radOne;
        circleTwo = radTwo;
        center = location;
    }
}
