using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Inventory inventory;
    public bool inventoryShowing;
    public float moveSpeed;
    public float jumpForce;
    public bool onGround;
    public bool hit;
    

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public TerrainGeneration terrainGeneratior;

    public int playerRange;
    
    public Vector2Int mousePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        inventory = GetComponent<Inventory>();
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
    private void FixedUpdate()
    {

        

    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float jump = Input.GetAxisRaw("Jump");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryShowing = !inventoryShowing;
        }
        mousePos.x = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - 0.5f);
        mousePos.y =Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - 0.5f);

        inventory.inventoryUI.SetActive(inventoryShowing);
        hit = Input.GetMouseButton(0);

        if (Vector2.Distance(transform.position, mousePos) <= playerRange)
        {
            if (hit)
            {
                terrainGeneratior.RemoveTile(mousePos.x, mousePos.y);
            }
        }


        if (horizontal > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (horizontal < 0)
            transform.localScale = new Vector3(1, 1, 1);

        if (jump > 0.1f || vertical > 0.1f)
        {
            //if(onGround)
            movement.y = jumpForce;
        }
        rb.velocity = movement;
    }
}
