using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayers : MonoBehaviour
{
    [SerializeField] LayerMask solidsLayer;
    [SerializeField] LayerMask interactablesLayer;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] LayerMask portalLayer;

    public static GameLayers i {get; set; }

    private void Awake() 
    {
        i = this;
    }

    public LayerMask SolidsLayer { get => solidsLayer; }

    public LayerMask InteractablesLayer { get => interactablesLayer; }

    public LayerMask PlayerLayer { get => playerLayer; }

    public LayerMask PortalLayer { get => portalLayer; }

    public LayerMask TriggerableLayers {
        get => portalLayer;
    }
}
