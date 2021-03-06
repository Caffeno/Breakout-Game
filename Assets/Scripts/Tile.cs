using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
public class Tile : MonoBehaviour
{

    [HideInInspector]
    public float height = 0f;
    static float tilesAlive;
    static float tileCount;

    public GameObject particleGameObject;

    private void Awake()
    {
        if (tileCount >= 0) { tileCount += 1; }
        else { tileCount = 1; }
        if (tilesAlive >= 0) { tilesAlive += 1; ; }
        else { tilesAlive = 1; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        tilesAlive -= 1;
        Ball.instacne.SpeedUp(height / 10);
       
        Instantiate(particleGameObject, transform.position, Quaternion.identity);
        GameObject.Destroy(gameObject);
        CustomEventManager.instance.OnTileBreak(1 - (tilesAlive / tileCount));
    }
}
