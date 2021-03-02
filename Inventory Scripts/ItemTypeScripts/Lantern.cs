using UnityEngine;

[CreateAssetMenu(fileName = "New Lantern", menuName = "Inventory/Lantern/Lantern")]
public class Lantern : Item
{
    public bool isLanternOn;
    public bool isSkullLantern;
    public GameObject lanternLightPrefab;
    public LanternController existingLight;
    public Color lanternColor; // = new Color (0.98f,0.83f,0.14f);
    public float lanternIntensity = 1;
    public float lanternRadiusInner = 2.56f;
    public float lanternRadiusOuter = 5.74f;
    
    public override void Use()
    {
        //base.Use();

        existingLight = FindObjectOfType<LanternController>(); //Cant seem to get this to work outside of the use function.
        isLanternOn = !isLanternOn;
        existingLight.lt.color = lanternColor;
        existingLight.lt.intensity = lanternIntensity;
        existingLight.lt.pointLightInnerRadius = lanternRadiusInner;
        existingLight.lt.pointLightOuterRadius = lanternRadiusOuter;
        existingLight.ToggleLantern(); 
    }
    
}
