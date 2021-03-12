using UnityEngine;

[CreateAssetMenu(fileName = "New Lantern", menuName = "Inventory/Lantern/Lantern")]
public class Lantern : Item
{
    public bool isLanternOn;
    public bool isSkullLantern;
    public Sprite offSprite;
    public Sprite onSprite;
    public LanternController existingLight;
    public Color lanternColor; // = new Color (0.98f,0.83f,0.14f);
    public float lanternIntensity = 1;
    public float lanternRadiusInner = 2.56f;
    public float lanternRadiusOuter = 5.74f;
    //I wanted to change the lights falloff range but for some reason unity does not support this feature.
    
    public override void Use()
    {
        //base.Use();
        
        existingLight = FindObjectOfType<LanternController>(); //Cant seem to get this to work outside of the use function.
        isLanternOn = !isLanternOn;
        if(isLanternOn == true)
        {
            icon = onSprite;
        }
        else
        {
            icon = offSprite;
        }
        FindObjectOfType<InventoryUI>().UpdateUI();
        existingLight.lt.color = lanternColor;
        existingLight.lt.intensity = lanternIntensity;
        existingLight.lt.pointLightInnerRadius = lanternRadiusInner;
        existingLight.lt.pointLightOuterRadius = lanternRadiusOuter;
        
        existingLight.ToggleLantern(); 
    }
    
}
