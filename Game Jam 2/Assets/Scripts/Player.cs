using UnityEngine;

public class Player : MonoBehaviour
{
    private bool hasKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasKey = false;
    }

    public void addKey()
    {
        hasKey = true;
    }
    
}
