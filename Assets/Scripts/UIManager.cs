using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Movement player;
    [SerializeField] private TextMeshProUGUI velocityText;
    private Vector3 velocity;
    private int velocityInt;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Movement>();
        velocityText = GameObject.Find("kmh").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        velocity = player.GetVelocity();
        velocityText.text = velocityInt.ToString();
    }
}
