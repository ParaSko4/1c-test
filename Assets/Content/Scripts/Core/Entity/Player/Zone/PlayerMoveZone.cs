using UnityEngine;
using Zenject;

namespace TestProject.Core.Entity.Player.Zone
{
    public class PlayerMoveZone : MonoBehaviour
    {
        [SerializeField] private float height;
        [SerializeField] private float width;
        [SerializeField] private Transform playerZoneCenter;

        private PlayerUnit playerUnit;
        private float widthHalf;
        private float heightHalf;

        [Inject]
        public void Construct(PlayerUnit playerUnit)
        {
            this.playerUnit = playerUnit;
        }

        private void Awake()
        {
            Setup();
        }

        public Vector3 CorrectPositionByZone(Vector3 position)
        {
            var center = playerZoneCenter.position;

            var clampedX = Mathf.Clamp(position.x, center.x - widthHalf + playerUnit.SpriteBounds.x, center.x + widthHalf - playerUnit.SpriteBounds.x);
            var clampedY = Mathf.Clamp(position.y, center.y - heightHalf + playerUnit.SpriteBounds.y, center.y + heightHalf - playerUnit.SpriteBounds.y);

            return new(clampedX, clampedY, position.z);
        }

        private void Setup()
        {
            widthHalf = width / 2f;
            heightHalf = height / 2f;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawCube(playerZoneCenter.position, new(width, height));
        }
    }
}