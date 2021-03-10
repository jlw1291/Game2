using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance {get; private set; }

    private void Awake(){
    	Instance = this;
    }
/*Seaweed,	Fishcan,	Wood,	Metal, 	Bolt,	Spear,	Knife, 	Trident,	Harpoon,	RadSuit,	HeatSuit,	Fins, 	Lamp*/

    public Sprite noneSprite;
    public Sprite seaweedSprite;
    public Sprite fishcanSprite;
    public Sprite woodSprite;
    public Sprite metalSprite;
    public Sprite boltSprite;
    public Sprite spearSprite;
    public Sprite knifeSprite;
    public Sprite tridentSprite;
    public Sprite harpoonSprite;
    public Sprite radsuitSprite;
    public Sprite heatsuitSprite;
    public Sprite finsSprite;
    public Sprite lampSprite;


}
