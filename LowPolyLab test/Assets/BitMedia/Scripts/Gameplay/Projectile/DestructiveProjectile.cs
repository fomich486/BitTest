using BitMedia.TestProject.Gameplay.CharacterBehaviour;

namespace BitMedia.TestProject.Gameplay.ProjectileBehavoiur
{
    public class DestructiveProjectile : Projectile
    {
        protected override void InteractWithCharecter(Character character)
        {
            print("Character destroyed");
            character.BackInPoolSetup();
        }
    }
}
