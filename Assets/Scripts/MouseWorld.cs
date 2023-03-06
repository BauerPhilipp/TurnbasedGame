using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{

    public static MouseWorld instance;

    [SerializeField] LayerMask mousePlaneLayerMask;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        transform.position = GetPosition();
    }

    public static Vector3 GetPosition() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
        return raycastHit.point;
    }

}
