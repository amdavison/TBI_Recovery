using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public Texture[] cardFaces;
    public Texture cardBack;
    public GameObject[] cards;

    private bool _init = false;
    private int _matches = 18;

    void Update()
    {
        if (!_init)
            InitializeCards();

        if (Input.GetMouseButtonUp(0))
            CheckCards();
    }

    void InitializeCards()
    {
        for (int id = 0; id < 2; id++) // for getting two identical cards
        {
            for (int i = 1; i < 14; i++) // for getting a card [1, 13] for Ace - King
            {
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>().Initialized);
                }
                cards[choice].GetComponent<Card>().CardValue = i;
                cards[choice].GetComponent<Card>().Initialized = true;
            }
        }

        foreach (GameObject card in cards)
            card.GetComponent<Card>().SetupGraphics();

        if (!_init)
            _init = true;
    }

    public Texture GetCardBack() { return cardBack; }

    public Texture GetCardFace(int i) { return cardFaces[i - 1]; }

    void CheckCards()
    {
        List<int> c = new List<int>();

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().State == 1)
                c.Add(i);
        }
        if (c.Count == 2)
            CardComparison(c);
    }

    void CardComparison(List<int> c)
    {
        Card.hold = true;

        int x = 0;

        if (cards[c[0]].GetComponent<Card>().CardValue == cards[c[1]].GetComponent<Card>().CardValue)
        {
            x = 2;
            _matches--;
            System.Console.WriteLine("Number of Matches: " + _matches); // NEED something else for here!
            if (_matches == 0)
            {
                System.Console.WriteLine("Level complete!"); // NEED new logic here for game completion!
            }
        }

        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().State = x;
            cards[c[i]].GetComponent<Card>().FalseCheck();
        }
    }
}
