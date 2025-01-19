using UnityEngine;

public class FaceFadeScript : MonoBehaviour
{
    public Sprite[] faceSprites;
    public float interactionDistance = 2.0f; // distance to trigger interaction
    public Transform[] targetPositions;
    private int currentSpriteIndex = 0;
    private SpriteRenderer spriteRenderer;
    private Transform player;
    private bool hasMoved = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (faceSprites.Length > 0)
        {
            spriteRenderer.sprite = faceSprites[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= interactionDistance && Input.GetKeyDown(KeyCode.E))
        {
            SwitchToNextSprite();
        }
    }

    void SwitchToNextSprite()
    {
        currentSpriteIndex++;

        // update sprite
        if (currentSpriteIndex < faceSprites.Length)
        {
            spriteRenderer.sprite = faceSprites[currentSpriteIndex];
        }
        else
        {
            spriteRenderer.sprite = null;

            // move the face
            if (!hasMoved && targetPositions.Length > 0)
            {
                MoveToNewPosition();
            }
        }
    }

    void MoveToNewPosition()
    {
        Transform newTarget = targetPositions[Random.Range(0, targetPositions.Length)];
        transform.position = newTarget.position;
        currentSpriteIndex = 0;

        // reset sprite to the first in the array
        if (faceSprites.Length > 0)
        {
            spriteRenderer.sprite = faceSprites[0];
        }

        hasMoved = true; // ensure the face only moves once
        Debug.Log("Face moved to a new location: " + newTarget.position);
    }
}
