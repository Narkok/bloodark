using UnityEngine;

[ExecuteInEditMode]
public class PlayerSpawnPoint : MonoBehaviour
{

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.4f);
    }
}
