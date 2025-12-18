using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragandDrop : MonoBehaviour
{
    [SerializeField] private InputAction mouseClick;
    [SerializeField] private float mouseDragVelocitySpeed = 10;
    [SerializeField] private float mouseDragSpeed = .1f;
    private Camera mainCamera;

    private Vector3 velocity = Vector3.zero;

    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();



    private void Awake()
    {
        //reference to main camera
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        //inspector input action
        mouseClick.Enable();
        mouseClick.performed += MousePressed;
    }

    private void OnDisable()
    {
        mouseClick.performed -= MousePressed;
        //disable mouse click
        mouseClick.Disable();
    }
    private void MousePressed(InputAction.CallbackContext context)
    {
        //ray from camera
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        //if ray hits an object
        if (Physics.Raycast(ray, out hit))
        {
            //hitting collider or draggable or has IDrag
            if (hit.collider != null && (hit.collider.gameObject.CompareTag("Draggable") || hit.collider.gameObject.layer == LayerMask.NameToLayer("Draggable") || hit.collider.gameObject.GetComponent<IDrag>() != null))
            {
                StartCoroutine(DragUpdate(hit.collider.gameObject));
            }
        }
    }
    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        float initialDistance = Vector3.Distance(clickedObject.transform.position, mainCamera.transform.position);
        clickedObject.TryGetComponent<Rigidbody>(out var rb);
        clickedObject.TryGetComponent<IDrag>(out var iDragComponent);
        iDragComponent?.onStartDrag();
        while (mouseClick.ReadValue<float>() != 0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            //if object has rigid body
            if (rb != null)
            {
                Vector3 direction = ray.GetPoint(initialDistance) - clickedObject.transform.position;
                //velocity to move object
                rb.velocity = direction * mouseDragVelocitySpeed;
                yield return waitForFixedUpdate;
            }
            else
            {
                Vector3 target = ray.GetPoint(initialDistance);
                clickedObject.transform.position = Vector3.SmoothDamp(clickedObject.transform.position, target, ref velocity, mouseDragSpeed);
                yield return null;
            }
        }
        //end dragging
        iDragComponent?.onEndDrag();
    }
}
