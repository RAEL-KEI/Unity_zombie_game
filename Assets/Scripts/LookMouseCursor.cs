using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouseCursor : MonoBehaviour
{
    public Camera characterCamera;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookMouseCursorMethod();
    }

    void LookMouseCursorMethod()
    {
        Ray ray = characterCamera.ScreenPointToRay(Input.mousePosition - new Vector3(0, Screen.height / 10, 0));
        RaycastHit hitResult;
        if (Physics.Raycast(ray, out hitResult, 50f, LayerMask.GetMask("hitpoint")))
        {
            Vector3 mouseDir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z);
            transform.LookAt(mouseDir);
        }
    }
}
