using NavMeshPlus.Components;
using UnityEngine;

public class NavMeshController : MonoBehaviour
{
    private NavMeshSurface _navMeshSurface;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshSurface = GetComponent<NavMeshSurface>();
        _navMeshSurface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
