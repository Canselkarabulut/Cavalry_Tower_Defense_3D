using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveUI : MonoBehaviour
{
    [SerializeField] Text LivesTxt;
    void Update()
    {
        LivesTxt.text ="Lives: " + PlayerStats.Lives.ToString();
    }
}
