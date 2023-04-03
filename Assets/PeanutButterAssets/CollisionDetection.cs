using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject SlicedSandwich;
    public GameObject Bread1;
    public GameObject Bread2;
    public GameObject JamSlice;
    public GameObject PBSlice;
    public AudioSource BreadSlice;
    public AudioSource PlateSound;

    // Start is called before the first frame update
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "WholeSandwich")
        {

            col.gameObject.SetActive(false);

        }

        if (col.gameObject.tag == "Plate")
        {
            PlateSound.Play();
            SlicedSandwich.SetActive(true);
            //Instantiate(Toast, new Vector3((float)-3.967, (float)1.5, (float)-3.044), Quaternion.identity);
        }

        if (col.gameObject.tag == "Bread")
        {
            BreadSlice.Play();
            col.gameObject.SetActive(false);
            Bread1.SetActive(true);
            Bread2.SetActive(true);
            //Instantiate(Bread, new Vector3((float)-.90, (float)1, (float)-3.044), Quaternion.Euler(90,0,0));
        }

        if (col.gameObject.tag == "JamJar")
        {
            JamSlice.SetActive(true);
        }

        if (col.gameObject.tag == "PBJar")
        {
            PBSlice.SetActive(true);
        }
    }
}
