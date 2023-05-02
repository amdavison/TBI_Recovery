using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    public GameObject SlicedSandwich;
    public GameObject Bread1;
    public GameObject Bread2;
    public GameObject JamSliceKnife;
    public GameObject JamSliceBread;
    public GameObject PBSliceKnife;
    public GameObject PBSliceBread;
    public AudioSource BreadSlice;
    public AudioSource PlateSound;
    public AudioSource complete;
    public SceneChanger scenChang;


    // Start is called before the first frame update

    void Start()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "WholeSandwich")
        {

            col.gameObject.SetActive(false);
            PBSliceBread.SetActive(false);
            JamSliceBread.SetActive(false);
            Bread1.SetActive(false);
            PlateSound.Play();
            SlicedSandwich.SetActive(true);

        }

        if (col.gameObject.tag == "Plate")
        {
            //PlateSound.Play();
            //SlicedSandwich.SetActive(true);
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

        if (col.gameObject.tag == "PBJar")
        {
            PBSliceKnife.SetActive(true);
            JamSliceKnife.SetActive(false);
            Bread1.tag = "BottomBread";

           
        }

        if (col.gameObject.tag == "BottomBread")
        {
            PBSliceKnife.SetActive(false);
            PBSliceBread.SetActive(true);
        }

        if (col.gameObject.tag == "JamJar")
        {
            JamSliceKnife.SetActive(true);
            PBSliceKnife.SetActive(false);

            
        }

        if (JamSliceKnife.activeSelf == true)
        {
            if (col.gameObject.tag == "PBSlice")
            {
                JamSliceKnife.SetActive(false);
                JamSliceBread.SetActive(true);
                Bread2.tag = "WholeSandwich";

            }
        }

        if (SlicedSandwich.activeSelf == true)
        {
            StartCoroutine(EndSimulation());
        }
    }
    IEnumerator EndSimulation()
    {
        complete.Play();
        LevelComplete.previousSceneID = "PeanutButter";
        LevelComplete.previousSceneName = "PB & J Simulation";
        yield return new WaitForSecondsRealtime(3);
        scenChang.changeScene("LevelCompletion");
    }
}
