
using UnityEngine;
using UnityEngine.AI;

namespace Sacristan.Utils
{
    public static class AIExtensions
    {
        public static bool GetPathRemainingDistance(this NavMeshAgent navMeshAgent, out float distance)
        {
            distance = float.PositiveInfinity;

            if (!navMeshAgent.isOnNavMesh || navMeshAgent.pathPending || navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid || navMeshAgent.path.corners.Length < 2)
            {
                return false;
            }

            distance = 0f;

            for (int i = 0; i < navMeshAgent.path.corners.Length - 1; ++i)
            {
                distance += Vector3.Distance(navMeshAgent.path.corners[i], navMeshAgent.path.corners[i + 1]);
            }

            return true;
        }
    }
}