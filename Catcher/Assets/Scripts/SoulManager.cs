using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulManager : MonoBehaviour
{
    public int maxSouls;
    public int currentSouls;

    public SoulBar soulBar;

    // Start is called before the first frame update
    void Start()
    {
        // animator = GetComponent<Animator>();
        currentSouls = 0;
        soulBar.SetSouls(currentSouls);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _pickUpSoul()
    {
        currentSouls++;
        soulBar.SetSouls(currentSouls);
    }


}
