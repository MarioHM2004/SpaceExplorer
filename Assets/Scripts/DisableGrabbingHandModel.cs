using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableGrabbingHandModel : MonoBehaviour
{
    public GameObject leftHandModel;
    public GameObject rightHandModel;

    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HideGrabbingHand);
        grabInteractable.selectExited.AddListener(ShowGrabbingHand);
    }

    public void HideGrabbingHand(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.tag == "Left Hand") {
            leftHandModel.SetActive(false);
        } else if (args.interactorObject.transform.tag == "Right Hand") {
            rightHandModel.SetActive(false);
        }
    }

    public void ShowGrabbingHand(SelectExitEventArgs args)
    {

        if (args.interactorObject.transform.tag == "Left Hand") {
            leftHandModel.SetActive(true);
        } else if (args.interactorObject.transform.tag == "Right Hand") {
            rightHandModel.SetActive(true);
        }
    }
}
