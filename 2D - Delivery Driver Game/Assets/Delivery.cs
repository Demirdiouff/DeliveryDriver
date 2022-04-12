using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage;
    [SerializeField] float delayBeforeDestroy;
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Oups, j'ai touché un truc..");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage) {
            Debug.Log("Package picked up !");
            hasPackage = true;
            Destroy(other.gameObject, delayBeforeDestroy);
        }
        if (hasPackage && other.tag == "Customer") {
            Debug.Log("Package delivered !");
            hasPackage = false;
        }
    }
}
