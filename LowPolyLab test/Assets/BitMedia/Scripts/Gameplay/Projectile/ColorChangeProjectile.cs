using BitMedia.TestProject.Gameplay.CharacterBehaviour;
using UnityEngine;

namespace BitMedia.TestProject.Gameplay.ProjectileBehavoiur
{
    public class ColorChangeProjectile : Projectile
    {
        [SerializeField]
        private Material _changeColorMaterial;
        protected override void InteractWithCharecter(Character character)
        {
            character.ChangeColor(_changeColorMaterial);
            print("Color change");
           
        }
    }
}
