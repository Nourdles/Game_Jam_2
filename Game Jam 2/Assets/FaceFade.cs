using UnityEngine;

public class FaceFade : MonoBehaviour
{
    public Sprite[] faceSprites;
    public float interactionDistance = 2.0f; // distance to trigger interaction
    private int currentSpriteIndex = 0;
    private SpriteRenderer spriteRenderer;
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
            Debug.Log("No more sprites to display.");
        }
    }
}
