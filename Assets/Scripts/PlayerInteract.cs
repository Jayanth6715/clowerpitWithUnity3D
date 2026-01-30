using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float range = 3f;

    Camera cam;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        // Trackpad / left click
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("CLICK REGISTERED");

            float offset = 0.1f;
            Vector3 origin = cam.transform.position + cam.transform.forward * offset;
            Ray ray = new Ray(origin, cam.transform.forward);

            RaycastHit hit;



            if (Physics.Raycast(ray, out hit, range))
            {
                IInteractable interactable =
                    hit.collider.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }
}
