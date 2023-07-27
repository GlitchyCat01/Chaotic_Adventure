using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour {
    public float startHealth = 3f, health;
    public int cookies;
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI cookiesText;
    public bool isAlive = true;
    public GameObject deathScreen;
    public Things things;
    private Leveldata leveldata;
    private bool isPaused = false;
    public GameObject pauseMenu;

    private void Start() {
        health = startHealth;
        leveldata = GameObject.FindGameObjectWithTag("World").GetComponent<Leveldata>();
        LoadStats();
        Time.timeScale = 1f;
    }

    private void Update() {
        Living();
        Pause();
        Stats();
        ThingUI();
        SaveStats();
    }
    void Stats() {
        cookiesText.text = "Cookies: " + cookies.ToString();
    }
    void Living() {
        if (isAlive) {
            // Update the health UI and check if the player is still alive
            healthSlider.value = health;
            healthSlider.maxValue = startHealth;

            if (health <= 0) {
                healthText.text = "Dead";
                isAlive = false;
            } else {
                healthText.text = "Health: " + health.ToString("F1");
            }
        } else {
            // If the player is dead, set isPaused to true to freeze everything except health update
            isPaused = true;
            Time.timeScale = 0f;
            deathScreen.SetActive(true);
        }
    }
    void Pause() {
        if (Input.GetKeyDown(KeyCode.P)) {
            TogglePause();
            pauseMenu.SetActive(true);
        }
    }
    public void TogglePause() {
        isPaused = !isPaused;

        if (isPaused) {
            Time.timeScale = 0f; // Freeze everything
        } else {
            Time.timeScale = 1f; // Resume normal time flow
        }
    }
    void ThingUI() {
        for (int i = 0; i < 3; i++) {
            if (things.thing[i].collected == true) {
                things.thing[i].imageThing.sprite = things.collectedSprite;
                things.thing[i].thing.GetComponent<SpriteRenderer>().sprite = things.collectedSprite;
            } else {
                things.thing[i].imageThing.sprite = things.thingSprite;
                things.thing[i].thing.GetComponent<SpriteRenderer>().sprite = things.thingSprite;
            }
        }
    }
    void SaveStats() {
        PlayerPrefs.SetInt("Cookies", cookies);
        for (int i = 0; i < 3; i++) {
            if (things.thing[i].collected == false) {
                PlayerPrefs.SetInt(leveldata.levelID.ToString() + "_thing_" + i.ToString(), 0);
            } else {
                PlayerPrefs.SetInt(leveldata.levelID.ToString() + "_thing_" + i.ToString(), 1);
            }
        }
    }
    void LoadStats() {
        cookies = PlayerPrefs.GetInt("Cookies");
        for (int i = 0; i < 3; i++) {
            if (PlayerPrefs.GetInt(leveldata.levelID.ToString() + "_thing_" + i.ToString()) == 1) {
                things.thing[i].collected = true;
            } else {
                things.thing[i].collected = false;
            }
            Debug.Log(leveldata.levelID.ToString() + "_thing_" + i.ToString());
        }
    }
}

[System.Serializable]
public class Things {
    public ThingyStuff[] thing;
    public Sprite collectedSprite;
    public Sprite thingSprite;
}

[System.Serializable]
public class ThingyStuff {
    public GameObject thing;
    public bool collected;
    public Image imageThing;
}