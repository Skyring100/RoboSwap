using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float camSpeed;
    private GridLayout grid;
    private Transform cameraTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject c = GameObject.Find("Main Camera");
        cameraTransform = c.transform;
        grid = GameObject.Find("Grid").GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        // Camera Movement
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        cameraTransform.Translate(new Vector3(xInput, yInput) * camSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = grid.LocalToCell(clickPos);
            Debug.Log(cellPos);
        }
    }
}
