using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerSpriteRenderer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer {  get; private set; }
    private PlayerMovement movement;

    public Sprite idle;
    public Sprite jump;
    public Sprite slide;
    public AnimatedSprite run;

    private void Awake()
    {
        movement = GetComponentInParent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();      
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }
    private void OnDisable()
    {
        spriteRenderer.enabled = false;
        run.enabled = false; 
    }
    private void LateUpdate()
    {
        run.enabled = movement.running;

        if(movement.jumping)
        {
            spriteRenderer.sprite = jump;
        } 
        else if (movement.sliding)
        {
            spriteRenderer.sprite = slide;
        }        
        else if(!movement.running) 
        {
            spriteRenderer.sprite = idle;
        }
    }
}
