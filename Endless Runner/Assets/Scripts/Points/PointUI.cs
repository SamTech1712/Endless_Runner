using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PointUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    
    public void UpdateScore(int score)
    {
        text.text = Convert.ToString(score);
    }
}
