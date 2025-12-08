using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable
{
   public void Interact();
}


public class Interactor : MonoBehaviour
{
    public Transform InteractorSource; // should be main camera
    public float InteractRange = 8f; // how far away/close you need to be to interact. recomend: 8f
    public float radius = 0.5f; // how wide your aim needs to be to look at the object. reccomend: 0.5f
    public LayerMask interactMask; // layer should be "interactable"
    
    IInteractable currentView; //object you are currently looking at
    GameObject lastPrompt; // last object you looked at

   void Update(){

        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
       
        if (Physics.SphereCast(r, radius, out RaycastHit hitInfo, InteractRange, interactMask)){ //looks for objects in the range 
            IInteractable interactObj = hitInfo.collider.GetComponentInParent<IInteractable>();

            if (interactObj != null){                                                               

                currentView = interactObj;
                Transform root = ((MonoBehaviour)interactObj).transform;
                Transform promptTransform = root.Find("InteractPrompt");
                
                if (promptTransform != null){
                    GameObject prompt = promptTransform.gameObject;

                    if (lastPrompt != null && lastPrompt != prompt) // turns off previously viewed object and turns on newly viewed object
                        lastPrompt.SetActive(false);
                        prompt.SetActive(true);
                        lastPrompt = prompt;
                }
                else{ ClearPrompt();}
            }
            else{ ClearPrompt();}
        }
        else{ClearPrompt();}

        if (Input.GetKeyDown(KeyCode.E) && currentView != null){
            currentView.Interact();
        }
}
void ClearPrompt()
{
    if (lastPrompt != null)
        lastPrompt.gameObject.SetActive(false);

    lastPrompt = null;
    currentView = null;
}

}


