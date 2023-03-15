using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject Toast;
  
    // Start is called before the first frame update
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "WholeSandwich")
        {

            col.gameObject.SetActive(false);

        }

        else if(col.gameObject.tag == "Plate")
        {
            Instantiate(Toast, new Vector3((float)-3.957, (float).74, (float)(-3.031)), transform.rotation);
        }
    }
}
