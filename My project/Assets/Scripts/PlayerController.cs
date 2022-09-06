using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody player_rigidbody;
    float horizontal, vertical;
    public float jumpPower = 10;
    bool isJump;

    public int itemCount;

    AudioSource ScoreSound;
    void Start()
    {
        isJump = false;
        player_rigidbody = GetComponent<Rigidbody>();

        ScoreSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            Vector3 PlayerJump = new Vector3(0, jumpPower, 0);
            player_rigidbody.AddForce(PlayerJump, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        player_rigidbody.AddForce(movement, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJump = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            ScoreSound.Play();
            itemCount++;

            other.gameObject.SetActive(false);
        }
    }
}







