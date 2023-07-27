using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Leveldata : MonoBehaviour {
    public int levelID;

    public void LoadLevel(string ID) {
        SceneManager.LoadScene(ID);
    }
}
