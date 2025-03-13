using UnityEngine;
using UnityEngine.UI;

public class BalanceBar : MonoBehaviour
{
    public RectTransform pointer;  // The moving pointer
    public RectTransform leftBar;  // The blue bar (fixed left)
    public RectTransform rightBar; // The red bar (fixed right)

    public float balance = 0.025f;   // Range: -1 (left) to 1 (right)
    public float moveSpeed = 5f; // Speed of movement

    private float maxWidth; // The total width of the bar

    void Start()
    {
        maxWidth = leftBar.sizeDelta.x + rightBar.sizeDelta.x;
    }

    void Update()
    {
        // Update balance dynamically using player input (or replace with game logic)
        balance = Mathf.Clamp(balance + Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, -1f, 1f);

        // Move pointer based on balance
        float newX = Mathf.Lerp(-maxWidth / 2, maxWidth / 2, (balance + 1) / 2);
        pointer.anchoredPosition = new Vector2(newX, pointer.anchoredPosition.y);

        // Calculate dynamic widths based on balance
        float rightWidth = Mathf.Lerp(maxWidth, 0, (balance + 1) / 2);
        float leftWidth = maxWidth - rightWidth; // Right bar fills the remaining space

        // Apply new widths (Position remains fixed due to pivot settings)
        leftBar.sizeDelta = new Vector2(leftWidth, leftBar.sizeDelta.y);  
        rightBar.sizeDelta = new Vector2(rightWidth, rightBar.sizeDelta.y);
    }
}