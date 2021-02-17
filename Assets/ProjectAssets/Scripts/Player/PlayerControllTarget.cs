using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerControllTarget : MonoBehaviour
{

    [SerializeField] float currentSpeed;
    [SerializeField] float speed;
    [SerializeField] float sprint;
    Vector3 moveDir;
    Vector3 lookDir;
    Rigidbody rb;
    [SerializeField] Camera cam;

    private bool horizontal = false, vertical = false;

    void Start ()
    {
        rb = GetComponent<Rigidbody> ();

        if (cam == null)
        {
            cam = Camera.main;
        }

    }

    void Update ()
    {
        Buttons ();

        currentSpeed = Input.GetButton ("Dash") ? speed * sprint : speed;
        Vector3 forward = cam.transform.forward * Input.GetAxis ("Vertical") * currentSpeed;
        Vector3 right = cam.transform.right * Input.GetAxis ("Horizontal") * currentSpeed;

        moveDir = forward + right;
        moveDir = new Vector3 (moveDir.x, rb.velocity.y, moveDir.z);

    }

    void FixedUpdate ()
    {
        Movement ();

    }

    void Movement ()
    {

        //de berekende move en rotation vectoren worden hier in FixedUpdate toegepast.
        rb.velocity = moveDir;
    }

    void Buttons ()
    {
        if (Input.GetButtonDown ("Horizontal"))
        {
            horizontal = true;
        }
        else if (Input.GetButtonUp ("Horizontal"))
        {
            horizontal = false;
        }

        if (Input.GetButtonDown ("Vertical"))
        {
            vertical = true;
        }
        else if (Input.GetButtonUp ("Vertical"))
        {
            vertical = false;
        }

    }
}