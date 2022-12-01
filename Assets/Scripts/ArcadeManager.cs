using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeManager : MonoBehaviour
{
    [SerializeField] Game game; // Game child classes
    [SerializeField] Collider ArcadeCollider;

    Game Instance;

    void Awake()
    {
        Eyes.OnRayCastHitEvent += RunGame;
    }

    void RunGame(RaycastHit hit)
    {
        if(!Input.GetMouseButtonDown(0) || !hit.collider.Equals(ArcadeCollider))
            return;
        if(Instance != null)
            Destroy(Instance.gameObject);
        Instance = Instantiate(game,gameObject.transform);
    }
}