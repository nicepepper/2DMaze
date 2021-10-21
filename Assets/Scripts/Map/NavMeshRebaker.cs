using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Map
{
    public class NavMeshRebaker : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<NavMeshSurface>().BuildNavMesh();
        }
    }
}


