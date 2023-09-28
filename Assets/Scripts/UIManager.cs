using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreUI;

    void Update()
    {
        scoreUI.text = score.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        UnityEngine.Debug.Log("Collider is Working ");
        if (other.gameObject.tag == "SpeedBoost")
        {
            score++;
        }
    }
}