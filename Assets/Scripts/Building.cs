using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [System.Serializable] public class Level
    {
        public int level = 1;
        public Sprite icon = null;
        public GameObject mesh = null;
        //Temporary variables (building resource requirements)
        public int reqElixir = 100;
        public int reqGold = 100;
    }

    //Building size
    private int rows = 1;
    private int columns = 1;
    //Current building location on grid
    private int currentX = 0;
    private int currentY = 0;

    //Stores the level + meshes and sprites for each building level
    [SerializeField] private Level[] _levels = null;
}
