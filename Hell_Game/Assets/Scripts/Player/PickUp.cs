using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool fireActivated = false;
    [SerializeField] float numberOfSpells = 5;
    public GameObject fireCircle;
    public Transform SpawnCircle;

    Fire_Spell fire_spell;

    // Start is called before the first frame update
    void Awake()
    {
        fire_spell = GameObject.Find("Fire_thing").GetComponent<Fire_Spell>();


    }

    // Update is called once per frame
    void Update()
    {

        if (numberOfSpells <= 0)
        {
            fireActivated = false;
            numberOfSpells = 5;
        }

        // fire spells
        if (fireActivated && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(fireCircle, SpawnCircle.position, Quaternion.identity);
            numberOfSpells--;
        }

        if (fire_spell.playerCollision && Input.GetKeyDown(KeyCode.E))
        {
            fire_spell.destroy();
            FireOn();
        }
    }
    void FireOn()
    {
        fireActivated = true;
    }
}
