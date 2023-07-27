using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Startscreen : MonoBehaviour {
    public GameObject[] levelButtons;
    public TextMeshProUGUI cookieText;
    private void Start() {
        
    }
    private void Update() {
        cookieText.text = "Cookies: " +  PlayerPrefs.GetInt("Cookies").ToString();
    }
    public void LoadLevel(string level) {
        SceneManager.LoadScene(level);
    }

    public void Reset() {
        PlayerPrefs.DeleteAll();
    }
}
