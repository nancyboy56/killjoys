using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats 
{
	// without any items
	private int baseStat;

	// with item modifications
	//idk if i want to keep track of the items being modified??
	//i might change when i get up to that part
	private int itemStat = 0;

	private int maxStat;
	private int minStat;
	private float modifier;
	private BaseStatType statType;

	
	
	public Stats()
	{
		maxStat = 25;
		minStat = 6;
		baseStat = 10;
		// deafualt stat is strength
		statType = BaseStatType.Strength;
	}

	public Stats( BaseStatType type)
	{
		maxStat = 25;
		minStat = 6;
		baseStat = 10;
		statType = type;
		CalculateModifier();
	}

	public Stats(BaseStatType type, int baseStatNum)
	{
		maxStat = 25;
		minStat = 6;
		baseStat = baseStatNum;
		statType = type;
		CalculateModifier();
	}

	public Stats(BaseStatType type, int baseStatNum, int min, int max)
	{
		maxStat = min;
		minStat = max;
		baseStat = baseStatNum;
		statType = type;
		CalculateModifier();
	} 
	public int BaseStat
	{
		get { return baseStat + itemStat; }

		set { 
			if(value <maxStat && value > minStat)
			{
				CalculateModifier();
				baseStat = value;
			}
			 }
	}

	public float Modifier
	{
		get { return modifier; }
	}


	public void CalculateModifier()
	{
		modifier = (BaseStat - 10) / 2 ;
	}

	public void ChangeStat(int change)
	{
		BaseStat += change;
	}

	public override string ToString()
	{
		string stateTypeString ="";

		if (statType.Equals(BaseStatType.Charisma))
		{
			stateTypeString = "Chrisma";
		} 
		else if (statType.Equals(BaseStatType.Wisdom))
		{
			stateTypeString = "Wisdom";
		}
		else if (statType.Equals(BaseStatType.Constitution))
		{
			stateTypeString = "Constitution";
		}
		else if (statType.Equals(BaseStatType.Dexterity))
		{
			stateTypeString = "Dexterity";
		}
		else if (statType.Equals(BaseStatType.Strength))
		{
			stateTypeString = "Strength";
		}
		return "Stat Type: " + stateTypeString+ ", Base Stat: " + BaseStat + ", Modifier: " + Modifier;
	}

}
