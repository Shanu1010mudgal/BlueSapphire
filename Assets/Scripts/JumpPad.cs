using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {
    public Vector2 force;

    private Animator animator;
    private AudioSource audioSource;
    private string jumpAnimation = "jump";

    
    void Start() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">
    void OnTriggerEnter2D(Collider2D other) {
        ObjectController2D obj = other.GetComponent<ObjectController2D>();
        if (obj) {
            obj.SetForce(force);
            obj.IgnoreFriction = true;
            CharacterController2D character = obj.GetComponent<CharacterController2D>();
            if (character) {
                character.ResetJumpsAndDashes();
            }
            animator.SetTrigger(jumpAnimation);
            if (audioSource) {
                audioSource.Play();
            }
        }
    }
}