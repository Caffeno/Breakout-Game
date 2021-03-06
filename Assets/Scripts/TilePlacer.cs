using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlacer : MonoBehaviour
{
    public Vector3 topLeftBox;
    public int rowCount;
    public int columnCount;
    public Camera mainCamera;
    public Gradient boxColors;
    public GameObject tile;
    public float bounciness = 5;
    private Bounds tileBounds;
    private float bottomRowHeight;

    private float topRowHeight;
    

    // Start is called before the first frame update
    void Start()
    {
        
        tileBounds = tile.GetComponent<SpriteRenderer>().bounds;

        topRowHeight = mainCamera.WorldToScreenPoint(topLeftBox).y / mainCamera.pixelHeight;
        bottomRowHeight = mainCamera.WorldToScreenPoint(topLeftBox - new Vector3(0, rowCount - 1, 0) * tileBounds.size.y).y / mainCamera.pixelHeight;
        PlaceTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaceTiles()
    {
        for (int i = 0; i < rowCount; i++)
        {
            float x = topLeftBox.x;
            float y = topLeftBox.y - tileBounds.size.y * i;
            for (int j = 0; j < columnCount; j++)
            {
                GameObject newTile = Instantiate(tile, new Vector3(x, y, 0), Quaternion.identity, transform);

                SpriteRenderer tileRenderer = newTile.GetComponent<SpriteRenderer>();
                float height = mainCamera.WorldToScreenPoint(newTile.transform.position).y / mainCamera.pixelHeight - bottomRowHeight;
                height /= topRowHeight - bottomRowHeight;
                tileRenderer.color = boxColors.Evaluate(1 - height);

                float tileBouncyness = Mathf.Lerp(1, bounciness, height);
                BoxCollider2D tileCollider = newTile.GetComponent<BoxCollider2D>();
                PhysicsMaterial2D tileMat =  new PhysicsMaterial2D();
                tileMat.bounciness = tileBouncyness;
                tileMat.friction = 0;
                tileCollider.sharedMaterial = tileMat;
                newTile.layer = 9;

                newTile.GetComponent<Tile>().height = height;

                x += tileBounds.size.x;
            }
        }
    }
}
