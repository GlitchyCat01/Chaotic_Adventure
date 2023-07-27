using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathScreen : MonoBehaviour {
    public string[] deathMessages;
    public TextMeshProUGUI deathMessage;
    private void Start() {
        int g = Random.Range(0, deathMessages.Length);
        deathMessage.text = deathMessages[g];
    }
}
