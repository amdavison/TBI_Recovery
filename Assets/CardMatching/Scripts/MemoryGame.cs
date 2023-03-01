using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGame : MonoBehaviour
{
    readonly string[] cardSuits = new string[] { "Club", "Diamond",
                                                 "Spade", "Heart" };
    readonly string[] cardRanks = new string[] { "2", "3", "4", "5", "6", "7",
                                                 "8", "9", "10", "J", "Q", "K",
                                                 "A" };

    static public MemoryGame instance;

    public Card[] cards;
    private Card selectOne;
    private Card selectTwo;
    private double selectTime;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        // Get all cards on Table
        cards = transform.GetComponentsInChildren<Card>();
        

        // Deal random cards, in pairs
        int n = 0;
        Shuffle(cards);
        for (int i = 0; i < cards.Length / 2; ++i)
        {
            // choose a random suit and rank
            string suit = GetRandomFromArray(cardSuits);
            string rank = GetRandomFromArray(cardRanks);

            // assign it to two cards
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
            selectOne = card;
        }
        else
        {
            selectTwo = card;
            selectTime = Time.time;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // check for match or mismatch
        if (selectTwo != null)
        {
            // wait one second so user can see card
            if (Time.time > selectTime + 1.0)
            {
                CheckMatch();
            }
        }
    }

    private void CheckMatch()
    {
        if (selectOne.Matches(selectTwo))
        {
            // remove cards from the board
            selectOne.Hide();
            selectTwo.Hide();
        }
        else
        {
            // return cards to face down
            selectOne.Flip();
            selectOne.Flip();
        }

        // clear selection
        selectOne = selectTwo = null;
    }
}
