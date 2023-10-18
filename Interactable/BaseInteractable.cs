using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour
{
    protected GameObject player;
    protected bool isInteractable;
    public abstract void Interact();
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
            isInteractable = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
            isInteractable = false;
    }
    private void Update()
    {
        if (isInteractable == true && Input.GetKeyDown(KeyCode.E))
            Interact();
    }
}
