using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class lobbyButtons : MonoBehaviour
{
    public GameObject cardButton;
    public GameObject gasButton;
    public GameObject pbButton;


    // Start is called before the first frame update
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "memGame")
        {

            SceneManager.LoadScene("matchCards", LoadSceneMode.Additive);
        }

        if (col.gameObject.tag == "gasGame")
        {
            SceneManager.LoadScene("GasStation", LoadSceneMode.Additive);

        }

        if (col.gameObject.tag == "pbGame")
        {
            SceneManager.LoadScene("PeanutButter", LoadSceneMode.Additive);


        }

    }
}
