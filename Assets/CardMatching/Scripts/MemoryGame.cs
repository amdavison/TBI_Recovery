using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGame : MonoBehaviour
{
    // Suit and Rank names must match the Free_Playing_Cards naming convention
    string[] cardSuits = new string[] { "Club", "Diamond", "Spades", "Heart" };
    string[] cardRanks = new string[] { "2", "3", "4", "5", "6", "7", "8",
                                        "9", "10", "J", "Q", "K", "A" };

    // There is only one Memory Game at a time
    static public MemoryGame instance;
    
    // These are local state
    private Card[] cards;
    private Card selectOne;
    private Card selectTwo;
    private double selectTime;
    private int numMatches;

    // These are the audio sources
    private AudioSource[] audioSources;
    private AudioSource success;
    private AudioSource failure;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        // Get all cards on GameBoard
        cards = transform.GetComponentsInChildren<Card>();

        numMatches = cards.Length / 2;

        // Deal random cards, in pairs
        int n = 0;
        Shuffle(cards);
        for (int i = 0; i < cards.Length / 2; ++i)
        {
            // chose a random suit and rank
            string suit = GetRandomFromArray(cardSuits);
            string rank = GetRandomFromArray(cardRanks);

            // assign to two cards
            cards[n++].SetSuitAndRank(suit, rank);
            cards[n++].SetSuitAndRank(suit, rank);
        }
    }

    private void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = (int)Mathf.Floor(Random.value * (n--));
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }

    private T GetRandomFromArray<T>(T[] array)
    {
        return array[(int)Mathf.Floor(Random.value * array.Length)];
    }

    public void Select(Card card)
    {
        // If we don't already have two selected cards
        if (selectTwo == null)
        {
            // flip card
            card.Flip();

            // save card in selectOne or selectTwo
            if (selectOne == null)
            {
                selectOne = card;
            } 
            else
            {
                selectTwo = card;
                selectTime = Time.time;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // check for match or mismatch
        if (selectTwo != null)
        {
            // wait one secod so user can see card
            if (Time.time > selectTime + 1.0)
            {
                CheckMatch();
            }
        }
    }

    private void CheckMatch()
    {
        // get and unpack audio sounds
        audioSources = GetComponents<AudioSource>();
        success = audioSources[0];
        failure = audioSources[1];

        if (selectOne.Matches(selectTwo))
        {
            // sucess sound needed here
            success.Play();

            // remove cards from board
            selectOne.Hide();
            selectTwo.Hide();

            numMatches--;
        }
        else
        {
            // failure sound needed here
            failure.Play();

            // return cards face down
            selectOne.Flip();
            selectTwo.Flip();
        }
        // clear selection
        selectOne = selectTwo = null;

        if (numMatches == 0)
        {
            // call completion scene
        }
    }
}
