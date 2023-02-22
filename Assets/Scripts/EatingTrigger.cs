using System;
using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EatingTrigger : MonoBehaviour
{
    public Animator animator;
    public GameObject gameObject;
    private bool playerEnter;

    public AudioSource Eating;

    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && playerEnter){
            animator.SetTrigger("isBeingEaten");
            Eating.Play();
            if (gameObject.name == "Beehive" || gameObject.name == "Beehive" || gameObject.name == "Salmon"){
                Destroy(gameObject, 3);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Bear"){
            playerEnter = true;

        }
    }
    
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Bear") {
            playerEnter = false;
        }
    }
}
