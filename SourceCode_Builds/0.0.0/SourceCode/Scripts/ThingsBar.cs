using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ThingsBar : MonoBehaviour {
    public bool[] isThingsActive;
    public Image[] thingsImage;
    public Sprite active, inactive;
    public int thingID;
    private void Start() {
        
    }
    private void Update() {
        for (int i = 0; i < 3; i++) {
            if (PlayerPrefs.GetInt(thingID.ToString() + "_thing_" + i.ToString()) == 1) {
                isThingsActive[i] = true;
            } else {
                isThingsActive[i] = false;
            }
            Debug.Log(thingID.ToString() + "_thing_" + i.ToString());
        }

        for (int i = 0; i < 3; i++) {
            if (isThingsActive[i] == true) {
                thingsImage[i].sprite = active;
            } else {
                thingsImage[i].sprite = inactive;
            }
        }
    }
}
