using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Card : MonoBehaviour
{
    private string suit;
    private string rank;
    private bool faceUp = true;
    private AudioSource cardFlip;

    public void SetSuitAndRank(string newSuit, string newRank)
    {
        suit = newSuit;
        rank = newRank;

        // set the graphics for this suit and rank
        string path = "Free_Playing_Cards/PlayingCards_" + rank + suit;
        GetComponent<MeshFilter>().mesh = Resources.Load<Mesh>(path);
        
        // add collision so we can detect mouse clicks
        gameObject.AddComponent<BoxCollider>();
    }

    public bool Matches(Card otherCard)
    {
        return (rank == otherCard.rank) && (suit == otherCard.suit);
    }

    public void Flip()
    {
        if (!faceUp)
        {
            // Add card flipping sound
            cardFlip = GetComponent<AudioSource>();
            cardFlip.Play();
        }

        faceUp = !faceUp;
        transform.rotation = Quaternion.LookRotation(-transform.forward, Vector3.up);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    // On trigger enter
    // wasSelected boolean for telling whether colliders interacted
    // On trigger exit to flip wasSelected to false

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    if (!faceUp)
                    {
                        MemoryGame.instance.Select(this);
                    }
                }
            }
        }
    }
}
