using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour {

    public float speed = 2.0f;
    public float jump = 3.0f;
    private CharacterController cc;
    private Vector3 move, gravity;
    public int score = 0;
    public Text countText, loseText;

    private void Start() {
        cc = GetComponent<CharacterController>();
        move = Vector3.zero;
        gravity = Vector3.zero;
        loseText.text = "";
        Count();
    }

    private void Update() {
        if(Input.GetButton("Horizontal")) {
            move.z = -Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        }
        if(cc.isGrounded)
        {
            gravity = Vector3.zero;
            if (Input.GetButton("Jump"))
            {
                gravity.y = jump;
            }
        }
        else
        {
            gravity += Physics.gravity * Time.deltaTime * 3;
        }
        
        move.x = speed * Time.deltaTime;
        move += gravity;
        move *= Time.deltaTime;
        cc.Move(move);
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Coin")
        {
            Destroy(hit.gameObject);
            score++;
            Count();
        }

        if(hit.gameObject.tag == "Barricade")
        {
            loseText.text = "You lose!";
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Count()
    {
        countText.text = "Count: " + score.ToString();
    }
}
