using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private string suit;
    private string rank;
    private bool faceUp = true;
    private AudioSource cardFlip;

    Collider selector;

    public void SetSuitAndRank(string newSuit, string newRank)
    {
        suit = newSuit;
        rank = newRank;

        // set the graphics for this suit and rank
        string path = "Free_Playing_Cards/PlayingCards_" + rank + suit;
        GetComponent<MeshFilter>().mesh = Resources.Load<Mesh>(path);

        // add collision so we can detect mouse clicks
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
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

    private void OnTriggerEnter(Collider otherCollider)
    {
        Debug.Log("Trigger event");
        if (!faceUp)
        {
            Debug.Log("Card face down");
            MemoryGame.instance.Select(this);
            selector = otherCollider;
        }
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        Debug.Log("Exiting trigger event");
        if (otherCollider == selector && faceUp)
        {
            selector = null;
        }
    }
}
