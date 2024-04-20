using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class FishingRodGame : MonoBehaviour
{
    public GameObject fishingLinePrefab; // Prefab for the fishing line
    public float throwForce = 5f;

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(ThrowLine);
    }

    void ThrowLine(XRBaseInteractor interactor)
    {
        // Instantiate the fishing line prefab and position it at the tip of the fishing rod
        GameObject fishingLine = Instantiate(fishingLinePrefab, transform.position, transform.rotation);

        // Add force to the fishing line to simulate throwing
        Rigidbody lineRigidbody = fishingLine.GetComponent<Rigidbody>();
        lineRigidbody.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}
