using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpForce;
    private int jumpCount = 0;

    [SerializeField] private TextMeshProUGUI jumpCountText;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();

        jumpCount = 0;
    }

    private void Update() {
        if (GameManager.Instance.gameOver)
            return;

        if (Input.GetButtonDown("RightArrow")) {
            rb.AddForce(new Vector2(1, Mathf.Sqrt(3)) * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }
        if (Input.GetButtonDown("LeftArrow")) {
            rb.AddForce(new Vector2(-1, Mathf.Sqrt(3)) * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }

        jumpCountText.text = jumpCount.ToString();
    }
}
