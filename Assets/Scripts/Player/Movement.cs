using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] Color c_sticking = Color.green;
    [SerializeField] Color c_notSticking = Color.white;
    private bool stickable = false;
    private bool isSticking = false;
    
    float xMov;
    float yMov;

    Rigidbody rb;
    Material playerMat;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerMat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        InputActions();     
    }

    private void FixedUpdate()
    {
        Vector3 m_Input = new Vector3(xMov, yMov, 0);
        rb.MovePosition(transform.position + m_Input * Time.deltaTime * speed);
    }

    public void ActivateStickToObject(bool value)
    {
        switch (value)
        {
            case true:
                isSticking = true;
                rb.velocity = Vector3.zero;
                SetPlayerMaterialColor(c_sticking);
                SetGravity(false);
                break;
            case false:
                isSticking = false;
                SetPlayerMaterialColor(c_notSticking);
                SetGravity(true);
                break;
        }      
    }

    private void InputActions()
    {
        xMov = Input.GetAxis("Horizontal");
        yMov = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && stickable)
        {
            if (!isSticking)
                ActivateStickToObject(true);
            else
                ActivateStickToObject(false);
        }
    }

    private void SetGravity(bool value)
    {
        rb.useGravity = value;
    }  
    
    public void SetPlayerMaterialColor(Color c)
    {
        playerMat.color = c;
    }

    public void SetStickability(bool value)
    {
        stickable = value;
    }

   

}

