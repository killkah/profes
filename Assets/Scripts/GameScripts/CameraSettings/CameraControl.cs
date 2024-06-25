using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Rigidbody rbCube;

    [SerializeField] private CinemachineVirtualCamera cmCamera;

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rbCube.velocity = new Vector3(moveX * speed, 0, moveY * speed);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll > 0)
        {
            cmCamera.m_Lens.FieldOfView -= 1;
        }
        else if (scroll < 0)
        {
            cmCamera.m_Lens.FieldOfView += 1;
        }

        if(cmCamera.m_Lens.FieldOfView >= 30)
        {
            cmCamera.m_Lens.FieldOfView = 30;
        }
        else if (cmCamera.m_Lens.FieldOfView <= 0)
        {
            cmCamera.m_Lens.FieldOfView = 0;
        }
    }
}
