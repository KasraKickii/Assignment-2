using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneTransition : MonoBehaviour
{
    [SerializeField] private SceneName sceneNameToGoTo = SceneName.Kasra;
    [SerializeField] private Vector3 scenePositionToGoTo = new Vector3();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //collision.GetComponent<Rigidbody2D>().MovePosition(new Vector2(scenePositionToGoTo.x, scenePositionToGoTo.y));

            SceneGameManager.Instance.FadeAndLoadScene(sceneNameToGoTo.ToString(), scenePositionToGoTo);
        }
    }
}
