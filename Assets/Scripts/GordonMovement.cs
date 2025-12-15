using UnityEngine;

public class GordonMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 3f;
    public float arriveDistance = 0.05f;

    private Transform currentTarget;

    void Update()
    {
        if (currentTarget == null) return;

        Vector3 targetPos = currentTarget.position;
        targetPos.y = transform.position.y; // keep him grounded

        Vector3 dir = targetPos - transform.position;
        float dist = dir.magnitude;

        if (dist <= arriveDistance)
        {
            // close enough, stop moving
            return;
        }

        dir.Normalize();
        transform.position += dir * moveSpeed * Time.deltaTime;

        if (dir.sqrMagnitude > 0.0001f)
        {
            Quaternion lookRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 10f);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        currentTarget = newTarget;
        Debug.Log($"GordonMovement: new target set to {newTarget.name}");
    }
}
