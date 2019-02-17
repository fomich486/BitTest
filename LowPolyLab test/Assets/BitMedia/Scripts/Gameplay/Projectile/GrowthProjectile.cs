using BitMedia.TestProject.Gameplay.CharacterBehaviour;

namespace BitMedia.TestProject.Gameplay.ProjectileBehavoiur
{
    public class GrowthProjectile : Projectile
    {
        [UnityEngine.SerializeField]
        private float _growthCoef;
        protected override void InteractWithCharecter(Character character)
        {
            print("GROWTH!");
            character.transform.localScale = _growthCoef * character.transform.localScale;
        }
    }
}
