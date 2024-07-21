using UnityEngine;

namespace TestProject.Core.Entity.Player
{
    public class PlayerUnit : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public Transform PlayerTransform => playerTransform;
        public Vector3 SpriteBounds => spriteRenderer.bounds.extents;
    }
}