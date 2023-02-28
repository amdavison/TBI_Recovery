using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public static bool hold = false;  // halts card flipping process

    [SerializeField]
    private int _state;

    [SerializeField]
    private int _cardValue;

    [SerializeField]
    private bool _initialized = false;

    private Texture _cardBack;
    private Texture _cardFace;

    private GameObject _manager;
	void Start()
	{
        _state = 1;
        _manager = GameObject.Find("GameManager");  // GameObject.FindObjectWithTag("Manager");
	}

    public void SetupGraphics()
    {
        _cardBack = _manager.GetComponent<MatchManager>().GetCardBack();
        _cardFace = _manager.GetComponent<MatchManager>().GetCardFace(_cardValue);
        FlipCard();
    }

    public void FlipCard()
    {
        if (_state == 0)
            _state = 1;
        else if (_state == 1)
            _state = 0;
        // if (_state == 0 && !hold)
            // GetComponent<Image>().sprite = _cardBack;
        // else if (_state == 1 && !hold)
            // GetComponent<Image>().sprite = _cardFace;
    }
    public int CardValue { get { return _cardValue; } set { _cardValue = value; } }

    public int State { get { return _state; } set { _state = value; } }

    public bool Initialized { get { return _initialized; } set { _initialized = value; } }

    public void FalseCheck()
    {
        StartCoroutine(Pause());
    }

    IEnumerator Pause() 
    {
        yield return new WaitForSeconds(1);
        // if (_state == 0)
            // GetComponent<Image>().sprite = _cardBack;
        // else if(_state == 1)
            // GetComponent<Image>().sprite = _cardFace;
        hold = false;
    }

}
