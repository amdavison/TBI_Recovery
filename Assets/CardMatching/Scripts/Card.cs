using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private string suit;
    private string rank;
    private bool faceUp = false;


    public void SetSuitAndRank(string inSuit, string inRank)
    {
        suit = inSuit;
        rank = inRank;

        // set the graphics for this suit and rank
        string path = "Cards/" + suit + rank;
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
        faceUp = !faceUp;
        transform.rotation = Quaternion.LookRotation(-transform.forward, Vector3.up);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per fram
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
