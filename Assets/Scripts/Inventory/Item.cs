using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ItemData itemData;

    
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = itemData.icon;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player;
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            Destroy(gameObject);
            print("Player took me!");
            player.TryGetComponent<Inventory>(out Inventory inv);
            inv.AddItem(itemData);   
        }
    }
}
