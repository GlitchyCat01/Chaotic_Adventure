using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {
    public float damage;
    public bool damaging;
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player")) 
            damaging = true;
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
            damaging = false;
    }
    private void Update() {
        if (damaging) {
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<PlayerStats>().health -= damage * Time.deltaTime;
        }
    }
}
