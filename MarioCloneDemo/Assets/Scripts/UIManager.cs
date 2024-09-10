using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] TextMeshProUGUI pointText;

    private int currentPoints = 0;
    private int prevPoints;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void increaseScore(int points)
    {
        currentPoints = points;
        currentPoints += prevPoints;
        pointText.text = "x" + currentPoints.ToString();
        prevPoints = currentPoints;
    }
}
