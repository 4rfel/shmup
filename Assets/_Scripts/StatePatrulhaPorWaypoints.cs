public class StatePatrulhaPorWaypoints : State {
    public Transform[] waypoints;
    SteerableBehaviour steerable;

    public override void Awake() {
        base.Awake();
        // Configure a transição para outro estado aqui.
        steerable = GetComponent<SteerableBehaviour>();

    }

    public void Start() {
        waypoints[0].position = transform.position;
        waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
    }

    public override void Update() {
        if (Vector3.Distance(transform.position, waypoints[1].position) > .1f) {
            Vector3 direction = waypoints[1].position - transform.position;
            direction.Normalize();
            steerable.Thrust(direction.x, direction.y);
        } else {
            waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
        }
    }

}