using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text _coinScore;

    [SerializeField]
    private Text _livesCount;

    // Start is called before the first frame update
    void Start()
    {
        _coinScore.text = "Coins: " + 0;
        _livesCount.text = "Lives: " + 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _coinScoreUpdate(int coinsCollected)
    {
        _coinScore.text = "Coins: " + coinsCollected;
    }

    public void livesCountUpdate(int _lives)
    {
        _livesCount.text = "Lives: " + _lives;
    }
}
