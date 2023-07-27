using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour {
    private PlayerStats stats;
    private void Start() {
        stats = GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Cookie")) {
            stats.cookies++;
            Destroy(collision.gameObject);
        } else if (collision.CompareTag("Thing1")) {
            stats.things.thing[0].collected = true;
        } else if (collision.CompareTag("Thing2")) {
            stats.things.thing[1].collected = true;
        } else if (collision.CompareTag("Thing3")) {
            stats.things.thing[2].collected = true;
        }
    }
}