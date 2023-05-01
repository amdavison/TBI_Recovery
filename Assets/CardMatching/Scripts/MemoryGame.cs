using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MemoryGame : MonoBehaviour
{
    // Suit and Rank names must match the Free_Playing_Cards naming convention
    string[] cardSuits = new string[] { "Club", "Diamond", "Spades", "Heart" };
    string[] cardRanks = new string[] { "2", "3", "4", "5", "6", "7", "8",
                                        "9", "10", "J", "Q", "K", "A" };

    public TextMeshProUGUI matchText;
    public TextMeshProUGUI timeText;

    // There is only one Memory Game at a time
    static public MemoryGame instance;
    
    // These are local state
    private Card[] cards;
    private Card selectOne;
    private Card selectTwo;
    private double selectTime;
    private double startTime;
    private double playTime;
    private bool startGame = true;
    private bool endGame = false;
    private int numMatches = 18;
    readonly private double waitTime = 8.0;

    // These are the audio sources
    private AudioSource success;
    private AudioSource failure;
    private AudioSource complete;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        LevelComplete.previousSceneID = "matchCards";
        LevelComplete.previousSceneName = "Memory Game";

        AudioSource[] audioSources = GetComponents<AudioSource>();
        success = audioSources[0];
        failure = audioSources[1];
        complete = audioSources[2];
        audioSources[3].Play();

        // Get all cards on GameBoard
        cards = transform.GetComponentsInChildren<Card>();

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

        numMatches = cards.Length / 2;
        SetMatchText();

        playTime = startTime = 0.0;
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
                selectTime = Time.timeSinceLevelLoad;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame == true)
        {
            if (Time.timeSinceLevelLoad > startTime + waitTime)
            {
                foreach (Card card in cards)
                {
                    card.Flip();
                }
                startGame = false;
            }
        }

        // update playTime counter if during game play
        if (Time.timeSinceLevelLoad > playTime + waitTime && !endGame)
        {
            timeText.text = "Time: " + playTime.ToString();
            playTime++;
        }

        // check for match or mismatch
        if (selectTwo != null)
        {
            // wait one secod so user can see card
            if (Time.timeSinceLevelLoad > selectTime + 1.0)
            {
                CheckMatch();
            }
        }
    }

    private void CheckMatch()
    {
        if (selectOne.Matches(selectTwo))
        {
            // play sucess sound
            success.Play();

            // remove cards from board
            selectOne.Hide();
            selectTwo.Hide();

            numMatches--;
            SetMatchText();
        }
        else
        {
            // play failure sound
            failure.Play();

            // return cards face down
            selectOne.Flip();
            selectTwo.Flip();
        }
        // clear selection
        selectOne = selectTwo = null;

        if (numMatches == 0)
        {
            endGame = true;
            LevelComplete.completionTime = --playTime;

            // execute end simulation coroutine
            StartCoroutine(EndSimulation());

        }
    }

    private void SetMatchText()
    {
        matchText.text = "Matches left: " + numMatches.ToString();
    }

    protected IEnumerator EndSimulation()
    {
        // play level complete sound and load LevelCompletion scene
        complete.Play();
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("LevelCompletion");
    }
}
