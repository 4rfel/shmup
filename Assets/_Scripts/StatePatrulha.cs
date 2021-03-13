using UnityEngine;

public class StatePatrulha : State {
    private SteerableBehaviour steerable;

    public override void Awake()
    {
        base.Awake();

        
        // Criamos e populamos uma nova transição
        Transition ToAtacando = new Transition();
        ToAtacando.condition = new ConditionDistLT(transform,
            GameObject.FindWithTag("Player").transform,
            5.0f);
        ToAtacando.target = GetComponent<StateAtaque>();
        // Adicionamos a transição em nossa lista de transições
        transitions.Add(ToAtacando);

        steerable = GetComponent<SteerableBehaviour>();
    }

    float angle = 0;
    public override void Update() {
        
    }
}