using UnityEngine;

public class BehaviourTreeRunner : MonoBehaviour
{
    public BehaviourTree _behaviourTree;
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private PlayerController target;
    [SerializeField] private EnemyController enemyTarget;
    private BTContext _btContext;

    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = GameObject.FindWithTag("Player");
        target = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _btContext = InitBTContext();
        _behaviourTree = _behaviourTree.Clone();
        _behaviourTree.Bind(_btContext);
    }

    // Update is called once per frame
    void Update()
    {
        _behaviourTree.Update();
    }

    BTContext InitBTContext()
    {
        return BTContext.CreateFromGameObjectToTarget(gameObject, playerGameObject, target, enemyTarget);
    }
}