using UnityEngine;

public class StatePatrulha : State{
    private SteerableBehaviour steerable;

    [SerializeField] private ChangeStateDist csd;

    public override void Awake()
    {
        base.Awake();

        
        // Criamos e populamos uma nova transição
        Transition ToAtacando = new Transition();
        ToAtacando.condition = new ConditionDistLT(transform,
            GameObject.FindWithTag("Player").transform,
            csd.dist);
        ToAtacando.target = GetComponent<StateAtaque>();
        // Adicionamos a transição em nossa lista de transições
        transitions.Add(ToAtacando);

        steerable = GetComponent<SteerableBehaviour>();
    }

    public override void Update() {
        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        Vector3 direction = (posPlayer - transform.position);
        Vector2 dir = new Vector2(direction.x, direction.y);
        dir = dir.normalized * 2;

        steerable.Thrust(dir.x, dir.y);
       
        Vector3 diff = Camera.main.ScreenToWorldPoint(direction) - transform.position;

        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
}