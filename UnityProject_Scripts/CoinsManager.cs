using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager instance { get; private set; }
    public TextMeshProUGUI countPanel;
    private int coinsCount;

    public AudioSource audioSource;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        } else
        {
            instance = this;
        }
    }

    public void addCoins()
    {
        Debug.Log("add a coin!");
        coinsCount++;
        // TODO: maybe can add some animation
        countPanel.text = coinsCount.ToString();
        audioSource.Play();
    }

    public void decreaseCoins(int num)
    {
        Debug.Log("decrease coins by " + num);
        coinsCount -= num;
        if(coinsCount < 0)
        {
            coinsCount = 0;
        }
        // TODO: maybe can add some animation
        countPanel.text = coinsCount.ToString();
    }

    public int getCoinsCount()
    {
        return coinsCount;
    }

}
