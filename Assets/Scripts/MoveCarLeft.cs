using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarLeft : MonoBehaviour
{
    public string direction;

    private float leftX = 50.0f;
    private float rightX = -140.0f;

    private Transform car;

    void Start()
    {
        car = this.gameObject.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (direction == "left")
        {
            if (car.localPosition.x > leftX) {
                car.localPosition = new Vector3(rightX, car.localPosition.y, car.localPosition.z);
            }
            else
            {
                car.localPosition += new Vector3(0.1f, 0.0f, 0.0f);
            }
        } else
        {
            if (car.localPosition.x < rightX)
            {
                car.localPosition = new Vector3(leftX, car.localPosition.y, car.localPosition.z);
            }
            else
            {
                 car.localPosition -= new Vector3(0.1f, 0.0f, 0.0f);
            }
        }
    }
}
