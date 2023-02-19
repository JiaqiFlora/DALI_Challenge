using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Inventory")]
    public Inventory inventory;
    public InventoryUI inventoryUI;
    private IIventoryItem itemToPickUp = null;

    // For health bar
    [Header("Health Bar")]
    public int maxHealth = 10;
    public int currentHealth = 10;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<DialogueTrigger>().TriggerDialogue();

        currentHealth = maxHealth;
        HealthBar.instance.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(itemToPickUp != null && Input.GetKeyDown(KeyCode.F))
        {
            inventory.AddItem(itemToPickUp);
            inventoryUI.CloseMessagePanel();
        }

        // TODO: use real logic
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }

        // TODO: This feature might need to be changed!
        if(CoinsManager.instance.getCoinsCount() < 1 && GetComponent<Animator>().GetFloat("Speed") > 2)
        {
            GetComponent<Animator>().SetFloat("Speed", 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter!");
        IIventoryItem item = other.GetComponent<IIventoryItem>();
        if (item != null)
        {
            Debug.Log("item!");
            itemToPickUp = item;
            inventoryUI.OpenMessagePanel();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IIventoryItem item = other.GetComponent<IIventoryItem>();
        if (item != null)
        {
            itemToPickUp = null;
            inventoryUI.CloseMessagePanel();
        }
    }

    private void TakeDamage(int damage)
    {
        Debug.Log("current: " + currentHealth);
        currentHealth -= damage;
        Debug.Log(currentHealth);
        healthBar.SetHealth(currentHealth);
    }
}
