using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public float offsetX, offsetY, offsetZ;
    public GameObject follow;

    private void Update() {
        transform.position = new Vector3(offsetX + follow.transform.position.x, offsetY + follow.transform.position.y, offsetZ + follow.transform.position.z);
    }
}
