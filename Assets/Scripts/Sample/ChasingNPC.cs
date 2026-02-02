using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ChasingNPC3D : MonoBehaviour
{
    public Transform player;       // assigned by spawner OR set in inspector
    public float speed = 3f;
    public float chaseRange = 20f;

    private Rigidbody rBody;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector3.Distance(rBody.position, player.position);
        if (distance > chaseRange) return;

        Vector3 direction = (player.position - rBody.position);
        direction.y = 0f; // stay on ground
        direction = direction.normalized;

        Vector3 newPos = rBody.position + direction * speed * Time.fixedDeltaTime;
        rBody.MovePosition(newPos);
    }
}
