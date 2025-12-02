using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public string recipeName;
    public Sprite finalProduct;
    public Sprite[] ingredients;   // size 4 for now
}
