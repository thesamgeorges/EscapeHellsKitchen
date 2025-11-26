using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;


interface IInteractable
{
   public void Interact();
}


public class Interactor : MonoBehaviour
{
   public Transform InteractorSource;
   public float InteractRange;
   IInteractable CurrentLook;
   Transform lastPrompt;
   // Start is called before the first frame update
   void Start()
   {
      
   }

   // Update is called once per frame
   void Update()
   {
       Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
           if(Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
           {
             if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
               {
                   CurrentLook = interactObj;
                   Transform prompt = hitInfo.collider.transform.Find("InteractPrompt");
               if (prompt != null)
            {
                if (lastPrompt != null && lastPrompt != prompt)
                    lastPrompt.gameObject.SetActive(false);

                prompt.gameObject.SetActive(true);
                lastPrompt = prompt;
            }
        }
        else
        {
            ClearPrompt();
        }
    }
    else
    {
        ClearPrompt();
    }

    if (Input.GetKeyDown(KeyCode.E) && currentLook != null)
    {
        currentLook.Interact();
    }
}

void ClearPrompt()
{
    if (lastPrompt != null)
        lastPrompt.gameObject.SetActive(false);

    lastPrompt = null;
    currentLook = null;
}

}


