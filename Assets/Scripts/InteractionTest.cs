using UnityEngine;

public class InteractionTest : MonoBehaviour, IInteractable
{
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // This runs when the player clicks this object
    public void Interact()
    {
        rend.material.color = Random.ColorHSV();
    }
}
