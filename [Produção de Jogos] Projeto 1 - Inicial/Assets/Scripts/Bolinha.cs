using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// [RequireComponent(typeof(Rigidbody))]
public class Bolinha : MonoBehaviour
{
    public Rigidbody rb;
    public bool canMove {get; set;} = true;
    public float speed = 2.0f;
    public float jumpForce = 3.0f;
    bool isJumping;
    float vertical = 0.0f;
    float horizontal = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.R))
        {
            Debug.Log("LoadScene");
            SceneManager.LoadScene(0);
        }
    }

    void FixedUpdate()
    {
        if (!canMove) return;

        rb.AddForce(0, 0, speed * vertical, ForceMode.Force);
        rb.AddForce(speed * horizontal, 0, 0, ForceMode.Force);

        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isJumping = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        isJumping = true;
    }
}
