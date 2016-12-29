using UnityEngine;
using System.Collections;
using Valve.VR;
using VRTK;
public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject body;
    [SerializeField]
    private GameObject head;
    [SerializeField]
    private Transform fakeController;
    private GameObject rightController;
    float vert = 0;
    float hori = 0;
    uint contIndex;
    void Awake()
    {
        rightController = VRTK_DeviceFinder.GetControllerRightHand();
        contIndex = VRTK_DeviceFinder.GetControllerIndex(rightController);
    }

    void FixedUpdate()
    {
        ApplyVelocityToPosition(Movement());
        Rotate();
    }

    void Rotate()
    {
        if (VRTK_SDK_Bridge.IsTriggerPressedOnIndex(contIndex))
        //if (Input.GetButton("Fire1"))
        {
            body.transform.rotation = rightController.transform.rotation;
        }

    }
	Vector3 Movement()
    {
        Vector2 pos = VRTK_SDK_Bridge.GetTouchpadAxisOnIndex(contIndex);
        if (Input.GetAxis("Vertical") != 0)
        {
            vert = Input.GetAxis("Vertical");
        }

        //if (Input.GetAxis("Horizontal") != 0)
        //{
        //    hori = Input.GetAxis("Horizontal");
        //}
        return new Vector3(pos.x, 0, pos.y);
        //return new Vector3(hori, 0, vert);
        
        //ApplyVelocityToPosition(bodyRigidbody.position);

    }

    void ApplyVelocityToPosition(Vector3 _vel)
    {
       // bodyRigidbody.velocity = _vel;
       // FCRigid.velocity = _vel;
        transform.Translate(body.transform.forward * (_vel.z * Time.deltaTime));
        transform.Translate(body.transform.right * (_vel.x * Time.deltaTime));
        
       // Vector3 pos = new Vector3(body.transform.position.x, head.transform.position.y, body.transform.position.z);
        //head.transform.position = pos;
        
    }
}
