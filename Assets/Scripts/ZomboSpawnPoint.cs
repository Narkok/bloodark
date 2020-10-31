﻿using UnityEngine;

[ExecuteInEditMode]
public class ZomboSpawnPoint: MonoBehaviour
{

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.4f);
    }
}
