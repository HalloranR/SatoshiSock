using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreTextBox;
    
    void Start()
    {
        scoreTextBox.text = "Your Score: " + StateController.totalScore;
    }
}
