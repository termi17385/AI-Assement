using System.Collections.Generic;
using UnityEngine;

namespace StateMachines
{
    public enum States
    {
        Translate,
        Rotate,
        scale
    }

    // delegates what the function for each state will look like.
    public delegate void StateDelegate();
    public class StateMachine : MonoBehaviour
    {
        private Dictionary<States, StateDelegate> states = new Dictionary<States, StateDelegate>();

        [SerializeField] private States currentState = States.Translate;
        [SerializeField] private Transform controlled;  // affected by state machine
        [SerializeField] private float speed;           // just for testing the statemachine

        public void ChangeStates(States _newStates)
        {
            if (currentState != _newStates)
                currentState = _newStates;
        }


        // Start is called before the first frame update
        void Start()
        {
            // null-coalescing assignment operator - checks if null :)
            controlled ??= transform;

            states.Add(States.Translate, Translate);   
            states.Add(States.Rotate, Rotation);   
            states.Add(States.scale, Scale);   
        }

        // Update is called once per frame
        void Update()
        {
            // These two lines are used to run the state machine
            // it works by attempting to retrieve the relevant function for the current state.
            // then running the function if it successfully found it

            if (states.TryGetValue(currentState, out StateDelegate state))
                state.Invoke();
            else    // $ same as string.Format
                Debug.Log($"No state function set for state {currentState}.");
        }

        // the functions that will run for each state
        private void Translate() => controlled.position += controlled.forward * Time.deltaTime * speed;
        private void Rotation() => controlled.Rotate(Vector3.up, speed * .5f);
        private void Scale() => controlled.localScale += Vector3.one * Time.deltaTime * speed;
    }
}
