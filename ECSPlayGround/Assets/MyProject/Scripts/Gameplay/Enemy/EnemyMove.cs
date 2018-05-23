using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public enum EnemyMoveType
    {
        None,
        Random,
        Path,
    }
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private float minX, minY;
        [SerializeField] private float maxX, maxY;
        
        [SerializeField] private EnemyMoveType moveTypes;
        [SerializeField] private Vector3 nextPoint;

        private void Start()
        {
            MoveToNextPoint();
        }

        public void MoveToNextPoint()
        {
            //Get next-point
            nextPoint = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
            //move
            transform.DOMove(nextPoint, 4)
                .SetId("move")
                .OnComplete(MoveToNextPoint);
        }

        private void OnDisable()
        {
            transform.DOPause();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector2(minX, minY), new Vector2(maxX, minY));
            Gizmos.DrawLine(new Vector2(minX, minY), new Vector2(minX, maxY));
            Gizmos.DrawLine(new Vector2(maxX, maxY), new Vector2(maxX, minY));
            Gizmos.DrawLine(new Vector2(minX, maxY), new Vector2(maxX, maxY));
        }
    }
}