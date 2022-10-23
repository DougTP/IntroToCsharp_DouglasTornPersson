using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    //This is from the lecture with JM, in case the game needs character names
    [SerializeField] private Image progressBar;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI characterName;

    private void Start()
    {
        button.onClick.AddListener(OnButtonPressed);
    }

    public void OnButtonPressed()
    {
        float randomValue = Random.Range(0f, 1f);
        progressBar.fillAmount = randomValue;
    }
}
