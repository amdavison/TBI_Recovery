using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private string suit;
    private string rank;
    private bool faceUp = false;

    public void SetSuitAndRank(string newSuit, string newRank)
    {
        suit = newSuit;
        rank = newRank;

        // set the graphics for this suit and rank
        string path = "Free_Playing_Cards/PlayingCards_" + rank + suit;
        GetComponent<MeshFilter>().mesh = Resources.Load<Mesh>(path);
        // add collision so we can detect mouse clicks
        gameObject.AddComponent<MeshCollider>();
    }

    public bool Matches(Card otherCard)
    {
        return (rank == otherCard.rank) && (suit == otherCard.suit);
    }

    public void Flip()
    {
        // Add card flipping sound

        faceUp = !faceUp;
        transform.rotation = Quaternion.LookRotation(-transform.forward, -Vector3.right);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

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
