using System;
using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EatingTrigger : MonoBehaviour
{
    public Animator animator;
    // [Header("CustomEvent")]
    // public UnityEvent eatingEvent;
    private bool playerEnter;

    void Update() {
        // print(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0));
        if (Input.GetKeyDown(KeyCode.E) && playerEnter){
            animator.SetTrigger("isBeingEaten");
            // try {
            //     print("Event triggers.");
            //     eatingEvent.Invoke();
            // }       
            // catch {
            //     print("No event to trigger.");
            //     Debug.Log("No event to trigger.");
            // }
        }
    }
    
    // private void eatingTrigger(Collider2D other){
    //     try {
    //         print("Event triggers.");
    //         eatingEvent.Invoke();
    //     }       
    //     catch {
    //         print("No event to trigger.");
    //         Debug.Log("No event to trigger.");
    //     }
    // }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name == "Bear"){
            playerEnter = true;
        }
    }
}
