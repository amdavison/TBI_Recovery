using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject Toast;
    public GameObject Bread;

    // Start is called before the first frame update
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "WholeSandwich")
        {

            col.gameObject.SetActive(false);

        }

        if (col.gameObject.tag == "Plate")
        {
            Instantiate(Toast, new Vector3((float)-3.967, (float)1.5, (float)-3.044), Quaternion.identity);
        }

        if (col.gameObject.tag == "Bread")
        {
            col.gameObject.SetActive(false);
            Instantiate(Bread, new Vector3((float)-.90, (float)1, (float)-3.044), Quaternion.Euler(90,0,0));
        }
    }
}
