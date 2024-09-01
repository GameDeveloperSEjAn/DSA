using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inheritance : MonoBehaviour
{
    class Item
    {
        public string name;
        public string description;
        public int worth;
        public bool canBeSold;
        public int weight;

        public Item(string name, string description, int worth, bool canBeSold, int weight)
        {
            this.name = name;
            this.description = description;
            this.worth = worth;
            this.canBeSold = canBeSold;
            this.weight = weight;
        }

        void Start()
        {
            Item item = new Weapon("Rusty Axe", "a Rusty Axe",5, true, 8, 40, WeaponType.Axe, 4, 9, .6f);
        }
    }
    class Equipment : Item
    {
        public int currentDurability = 100;
        public int maxDurability = 100;

        public Equipment(string name, string description, int worth, bool canBeSold, int weight, int maxDurability) 
            : base(name, description, worth, canBeSold, weight)
        {
            this.maxDurability = maxDurability;
            currentDurability = maxDurability ;
        }

    }
    enum ArmorType
    {
    Helmet,
    Chest,
    Gloves,
    Girdle,
    Boots
    }
    class Armor : Equipment
    {
        public ArmorType type = ArmorType.Helmet;
        public int defence = 1;

        public Armor(string name, string description, int worth, bool canBeSold, int weight, int maxDurability ,ArmorType type , int defence)
            : base(name, description, worth, canBeSold, weight, maxDurability)
        {
            this.type = type;
            this.defence = defence;
        }
        
    }
    enum WeaponType
    {
        Sword,
        Axe,
        Hammer,
        Staff
    }
    class Weapon : Equipment
    {
        public WeaponType type = WeaponType.Sword;
        public int minDamage = 1;
        public int maxDamage = 2;
        public float attackTime = 0.6f;
        public bool dealsBluntDdamage = false;

        public Weapon(string name , string description , int worth, bool canBeSold , int weight, int maxDurability , WeaponType type, int minDamage, int maxDamage, float attackTime)
            :base (name , description , worth , canBeSold , weight , maxDurability )
        {
            this. type = type;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.attackTime = attackTime;
            if (type == WeaponType.Sword || type == WeaponType.Axe)
            {
                dealsBluntDdamage = false;
            }
            else
            {
                dealsBluntDdamage= true;
            }
        }
    }
}
