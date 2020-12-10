using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneOne : MonoBehaviour
{
    public static bool cutsceneOn;

    [SerializeField] 
    private Animator animator;

    [SerializeField] 
    private CharacterController controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controller.speed = 0.0f;

            cutsceneOn = true;

            animator.SetBool("Cutscene", true);

            Invoke(nameof(StopCutscene), 3f);
        }
    }

    void StopCutscene()
    {
        controller.speed = 5f;

        cutsceneOn = false;

        animator.SetBool("Cutscene", false);

        Destroy(gameObject);
    }
}
