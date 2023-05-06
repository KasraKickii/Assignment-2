using UnityEngine;
using Cinemachine;

public class UpdateVCAMConfiner : MonoBehaviour
{
    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += UpdateNewVCAMConfiner;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= UpdateNewVCAMConfiner;
    }

    /// <summary>
    /// Change the collider that cinemachine uses to define the boundary of main camera
    /// </summary>
    private void UpdateNewVCAMConfiner()
    {
        PolygonCollider2D polygonCollider2D = GameObject.FindGameObjectWithTag(Tags.VCAMConfiner).GetComponent<PolygonCollider2D>();

        CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();
        cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;

        cinemachineConfiner.InvalidatePathCache();
    }
}
