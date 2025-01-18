using UnityEngine;
using Player;

public class Key : Object, IInteractable
{
    public GameObject _playerObject;
    private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canInteract = false;
        if (_playerObject != null)
        {
            player = _playerObject.FindObjectOfType<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            Debug.Log("UI for \"Press E to interact\"");
        }
        else if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            interact();
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    public void interact()
    {
        Debug.Log("Picked up the key");
        Destroy(this.GameObject);
        player.addKey();
    }
}
