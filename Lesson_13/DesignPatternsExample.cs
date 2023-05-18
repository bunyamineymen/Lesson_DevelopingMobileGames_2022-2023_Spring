using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace DesignPatternsExample
{
    #region  Singleton Pattern

    /* 
        Singleton pattern ensures that there is **only one instance of a class and provides a global access point to it**. 
        You can use a singleton pattern to create managers or controllers that handle game logic, input, audio, or other global aspects of your game.
    */
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError("GameManager is NULL");
                }
                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }

        // Define some public methods for the game manager logic
        public void StartGame()
        {
            // Implement game start logic
            Debug.Log("Game started");
        }

        public void PauseGame()
        {
            // Implement game pause logic
            Debug.Log("Game paused");
        }

        public void ResumeGame()
        {
            // Implement game resume logic
            Debug.Log("Game resumed");
        }

        public void EndGame()
        {
            // Implement game end logic
            Debug.Log("Game ended");
        }
    }

    public class PlayerTestSingleton : MonoBehaviour
    {
        private void Start()
        {
            // Access the game manager instance and call its methods
            GameManager.Instance.StartGame();
            GameManager.Instance.PauseGame();
            GameManager.Instance.ResumeGame();
            GameManager.Instance.EndGame();
        }
    }

    public class EnemyTestSingleton : MonoBehaviour
    {
        private void Start()
        {
            // Access the game manager instance and call its methods
            GameManager.Instance.StartGame();
            GameManager.Instance.PauseGame();
            GameManager.Instance.ResumeGame();
            GameManager.Instance.EndGame();
        }
    }
    // In this example, the GameManager class is a singleton. Players and enemies can access same the game manager instance and call its methods to start, pause, resume, or end the game.

    #endregion

    #region  Object Pool Pattern
    /* 
        Object pool pattern is a creational pattern that allows you to reuse objects instead of creating and destroying them. 
        You can use an object pool pattern to create bullets, enemies, or other objects that are frequently created and destroyed in your game.
    */
    public class ObjectPool<T> where T : MonoBehaviour
    {
        // A field that holds a queue of available objects in the pool
        private Queue<T> availableObjects;

        // A field that holds a list of active objects in use
        private List<T> activeObjects;

        // A field that holds a reference to the prefab of the object type
        private T prefab;

        // A field that holds the initial size of the pool
        private int initialSize;

        // A constructor that takes a prefab and an initial size as arguments and creates a new pool
        public ObjectPool(T prefab, int initialSize)
        {
            // Set the prefab and initial size fields
            this.prefab = prefab;
            this.initialSize = initialSize;

            // Initialize the queue and list data structures
            availableObjects = new Queue<T>();
            activeObjects = new List<T>();

            // Fill the pool with initial size number of objects
            for (int i = 0; i < initialSize; i++)
            {
                // Create a new object using the factory method
                T obj = CreateObject();
                // Add it to the queue of available objects
                availableObjects.Enqueue(obj);
            }
        }

        // A factory method that creates a new object of type T from the prefab and sets it to inactive
        private T CreateObject()
        {
            // Instantiate a new object from the prefab using Unity's instantiation system
            T obj = UnityEngine.Object.Instantiate(prefab);
            // Set the object to inactive by default
            obj.gameObject.SetActive(false);
            // Return the object
            return obj;
        }

        // A method that returns an object from the pool or creates a new one if none is available
        public T GetObject()
        {
            // Declare a variable to store the object to return
            T obj;
            // If there are no available objects in the queue, create a new one using the factory method
            if (availableObjects.Count == 0)
            {
                obj = CreateObject();
            }
            // Otherwise, dequeue an object from the queue of available objects
            else
            {
                obj = availableObjects.Dequeue();
            }
            // Add the object to the list of active objects
            activeObjects.Add(obj);
            // Set the object to active
            obj.gameObject.SetActive(true);
            // Return the object
            return obj;
        }

        // A method that returns an object to the pool and sets it to inactive
        public void ReturnObject(T obj)
        {
            // Remove the object from the list of active objects
            activeObjects.Remove(obj);
            // Set the object to inactive
            obj.gameObject.SetActive(false);
            // Enqueue the object to the queue of available objects
            availableObjects.Enqueue(obj);
        }
    }

    public class Bullet : MonoBehaviour
    {
        // A field that holds a reference to the object pool that this bullet belongs to
        private ObjectPool<Bullet> pool;

        // A method that sets the pool reference for this bullet
        public void SetPool(ObjectPool<Bullet> pool)
        {
            this.pool = pool;
        }

        // A method that is called when the bullet collides with something
        private void OnCollisionEnter(Collision collision)
        {
            // Do something with the collision

            // Return the bullet to the pool
            pool.ReturnObject(this);
        }
    }

    public class Weapon : MonoBehaviour
    {
        // A field that holds a reference to the bullet prefab
        [SerializeField] private Bullet bulletPrefab;

        // A field that holds a reference to the object pool of bullets
        private ObjectPool<Bullet> bulletPool;

        // A method that is called when the weapon is initialized
        private void Start()
        {
            // Create a new object pool of bullets with an initial size of 10
            bulletPool = new ObjectPool<Bullet>(bulletPrefab, 10);
        }

        // A method that is called when the weapon is fired
        private void Fire()
        {
            // Get a bullet from the pool
            Bullet bullet = bulletPool.GetObject();
            // Set the pool reference for the bullet
            bullet.SetPool(bulletPool);
            // Set the position and rotation of the bullet to match the weapon's transform
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            // Set the position and rotation of the bullet to match the weapon's transform
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            // Apply a force to the bullet to make it move forward
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
        }
    }

    #endregion

    #region Command Pattern
    /* 
        Command pattern is a behavioral pattern that encapsulates a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations. 
        You can use a command pattern to create a command manager that can execute, undo, and redo commands.
    */
    public class Player : MonoBehaviour
    {
        // A field that holds a reference to the command manager object
        private CommandManager commandManager;
        private void Start() // A method that is called when the player is initialized
        {
            commandManager = new CommandManager(); // Create a new command manager object
        }
        // A method that moves the player in a given direction and distance
        public void Move(Vector3 direction, float distance)// Do something to move the player
        {
        }
        // A method that makes the player jump to a given height
        public void Jump(float height)// Do something to make the player jump
        {
        }
        private void Update() // A method that is called when the player presses a key
        {
            if (Input.GetKeyDown(KeyCode.W))// If the player presses the W key
            {
                // Create a new move command with the player, the forward direction, and a distance of 1 unit
                ICommand moveCommand = new MoveCommand(this, Vector3.forward, 1f);
                // Execute the move command using the command manager object
                commandManager.ExecuteCommand(moveCommand);
            }
            else if (Input.GetKeyDown(KeyCode.S)) // If the player presses the S key
            {
                // Create a new move command with the player, the backward direction, and a distance of 1 unit
                ICommand moveCommand = new MoveCommand(this, Vector3.back, 1f);
                // Execute the move command using the command manager object
                commandManager.ExecuteCommand(moveCommand);
            }
            else if (Input.GetKeyDown(KeyCode.Space)) // If the player presses the space key
            {
                // Create a new jump command with the player and a height of 2 units
                ICommand jumpCommand = new JumpCommand(this, 2f);
                // Execute the jump command using the command manager object
                commandManager.ExecuteCommand(jumpCommand);
            }
            else if (Input.GetKeyDown(KeyCode.Z)) // If the player presses the Z key
            {
                // Undo the last command using the command manager object
                commandManager.UndoCommand();
            }
            else if (Input.GetKeyDown(KeyCode.Y)) // If the player presses the Y key
            {
                commandManager.RedoCommand();// Redo the last command using the command manager object
            }
        }
    }

    // An interface that defines the behavior of a command that can execute and undo an action
    public interface ICommand
    {
        // A method that executes the action
        void Execute();
        // A method that undoes the action
        void Undo();
    }

    // A class that implements the ICommand interface and encapsulates a move action
    public class MoveCommand : ICommand
    {
        // A field that holds a reference to the receiver of the action (the player)
        private Player player;
        // A field that holds the direction of the movement
        private Vector3 direction;
        // A field that holds the distance of the movement
        private float distance;

        // A constructor that takes a player, a direction, and a distance as arguments and sets them to the fields
        public MoveCommand(Player player, Vector3 direction, float distance)
        {
            this.player = player;
            this.direction = direction;
            this.distance = distance;
        }

        // A method that executes the move action by calling the Move method on the player object with the direction and distance fields
        public void Execute()
        {
            player.Move(direction, distance);
        }

        // A method that undoes the move action by calling the Move method on the player object with the opposite direction and distance fields
        public void Undo()
        {
            player.Move(-direction, distance);
        }

    }

    // A class that implements the ICommand interface and encapsulates a jump action
    public class JumpCommand : ICommand
    {
        // A field that holds a reference to the receiver of the action (the player)
        private Player player;
        // A field that holds the height of the jump
        private float height;
        // A field that holds the original position of the player before the jump
        private Vector3 originalPosition;

        // A constructor that takes a player and a height as arguments and sets them to the fields
        public JumpCommand(Player player, float height)
        {
            this.player = player;
            this.height = height;
            // Get and store the original position of the player before the jump
            originalPosition = player.transform.position;
        }

        // A method that executes the jump action by calling the Jump method on the player object with the height field
        public void Execute()
        {
            player.Jump(height);
        }

        // A method that undoes the jump action by setting the position of the player object to the original position field
        public void Undo()
        {
            player.transform.position = originalPosition;
        }
    }

    // A class that acts as an invoker and stores a list of commands that can be executed or undone
    public class CommandManager
    {
        // A field that holds a list of commands that have been; 
        private List<ICommand> executedCommands; // executed
        private List<ICommand> undoneCommands; //undone
        public CommandManager() // // A constructor that initializes the lists as empty lists
        {
            executedCommands = new List<ICommand>();
            undoneCommands = new List<ICommand>();
        }

        // A method that executes a command and adds it to the list of executed commands
        public void ExecuteCommand(ICommand command)
        {

            command.Execute();  // Execute the command
            executedCommands.Add(command); // Add the command to the list of executed commands
            undoneCommands.Clear();// Clear the list of undone commands
        }

        // A method that undoes the last executed command and adds it to the list of undone commands
        public void UndoCommand()
        {
            if (executedCommands.Count == 0) return; // If there are no executed commands, return
            // Get the last executed command from the list of executed commands
            ICommand command = executedCommands[executedCommands.Count - 1];
            command.Undo(); // Undo the command
            // Remove the command from the list of executed commands
            executedCommands.RemoveAt(executedCommands.Count - 1);
            // Add the command to the list of undone commands
            undoneCommands.Add(command);
        }

        // A method that redoes the last undone command and adds it back to the list of executed commands
        public void RedoCommand()
        {
            if (undoneCommands.Count == 0) return;// If there are no undone commands, return
            // Get the last undone command from the list of undone commands
            ICommand command = undoneCommands[undoneCommands.Count - 1];
            command.Execute();
            // Remove the command from the list of undone commands
            undoneCommands.RemoveAt(undoneCommands.Count - 1);
            // Add the command back to the list of executed commands
            executedCommands.Add(command);
        }
    }

    #endregion

    #region State Pattern
    /* 
        State pattern is a behavioral pattern that allows an object to alter its behavior when its internal state changes. 
        You can use a state pattern to create a state machine that can change its behavior based on the current state.
    */

    // An interface that defines the behavior of a state
    public interface IStatePattern
    {
        // A method that executes the behavior of the state
        void ExecuteState();
    }

    // A class that implements the IState interface and encapsulates the behavior of the idle state
    public class IdleState : IStatePattern
    {
        // A field that holds a reference to the state machine
        private StateMachine stateMachine;
        // A constructor that takes a state machine as an argument and sets it to the field
        public IdleState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        // A method that executes the behavior of the idle state
        public void ExecuteState()
        {
            // If the player presses the W key
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Set the state of the state machine to the move state
                stateMachine.SetState(new MoveState(stateMachine));
            }
            // If the player presses the space key
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                // Set the state of the state machine to the jump state
                stateMachine.SetState(new JumpState(stateMachine));
            }
        }
    }

    // A class that implements the IState interface and encapsulates the behavior of the move state
    public class MoveState : IStatePattern
    {
        // A field that holds a reference to the state machine
        private StateMachine stateMachine;
        // A constructor that takes a state machine as an argument and sets it to the field
        public MoveState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        // A method that executes the behavior of the move state
        public void ExecuteState()
        {
            // If the player presses the W key
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Set the state of the state machine to the move state
                stateMachine.SetState(new MoveState(stateMachine));
            }
            // If the player presses the space key
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                // Set the state of the state machine to the jump state
                stateMachine.SetState(new JumpState(stateMachine));
            }
        }
    }

    // A class that implements the IState interface and encapsulates the behavior of the jump state
    public class JumpState : IStatePattern
    {
        // A field that holds a reference to the state machine
        private StateMachine stateMachine;
        // A constructor that takes a state machine as an argument and sets it to the field
        public JumpState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        // A method that executes the behavior of the jump state
        public void ExecuteState()
        {
            // If the player presses the W key
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Set the state of the state machine to the move state
                stateMachine.SetState(new MoveState(stateMachine));
            }
            // If the player presses the space key
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                // Set the state of the state machine to the jump state
                stateMachine.SetState(new JumpState(stateMachine));
            }
        }
    }

    // A class that acts as a state machine and stores a reference to the current state
    public class StateMachine
    {
        // A field that holds a reference to the current state
        private IState currentState;
        // A constructor that takes an initial state as an argument and sets it to the current state field
        public StateMachine(IState initialState)
        {
            currentState = initialState;
        }

        // A method that sets the current state to a new state
        public void SetState(IState newState)
        {
            currentState = newState;
        }

        // A method that executes the behavior of the current state
        public void ExecuteState()
        {
            currentState.ExecuteState();
        }


    }

    public class Player2 : MonoBehaviour
    {
        // A field that holds a reference to the state machine
        private StateMachine stateMachine;
        // A field that holds a reference to the idle state
        private IdleState idleState;
        // A field that holds a reference to the move state
        private MoveState moveState;
        // A field that holds a reference to the jump state
        private JumpState jumpState;

        // Start is called before the first frame update
        void Start()
        {
            // Initialize the idle state
            idleState = new IdleState(stateMachine);
            // Initialize the move state
            moveState = new MoveState(stateMachine);
            // Initialize the jump state
            jumpState = new JumpState(stateMachine);
            // Initialize the state machine with the idle state
            stateMachine = new StateMachine(idleState);
        }

        // Update is called once per frame
        void Update()
        {
            // Execute the behavior of the current state
            stateMachine.ExecuteState();
        }
        public void Jump()
        {
            // Set the state of the state machine to the jump state
            stateMachine.SetState(new JumpState(stateMachine));
        }
    }

    #endregion

    #region State Pattern2
    // Define an interface for states
    public interface IState
    {
        // Define a method to enter the state
        void Enter(Enemy enemy);

        // Define a method to update the state
        void Update();

        // Define a method to exit the state
        void Exit();
    }

    // Define a scriptable object base class for states
    public abstract class State : ScriptableObject, IState
    {
        // Define a protected field to store the enemy reference
        protected Enemy enemy;

        // Define an abstract method to enter the state
        public abstract void Enter(Enemy enemy);

        // Define an abstract method to update the state
        public abstract void Update();

        // Define an abstract method to exit the state
        public abstract void Exit();
    }

    // Define scriptable object subclasses for different states
    [CreateAssetMenu(fileName = "AttackState", menuName = "States/AttackState")]
    public class AttackState : State
    {
        public override void Enter(Enemy enemy)
        {
            // Implement state enter logic
            Debug.Log(enemy.name + " enters attack state");
            this.enemy = enemy;
        }

        public override void Update()
        {
            // Implement state update logic
            Debug.Log(enemy.name + " updates attack state");

            // Call the enemy attack method
            this.enemy.Attack();

            // Check some conditions to change state
            if (this.enemy.Health < 20)
            {
                // Change to flee state if health is low
                this.enemy.ChangeState(this.enemy.FleeState);
            }
            else if (this.enemy.Health > 80)
            {
                // Change to heal state if health is high
                this.enemy.ChangeState(this.enemy.HealState);
            }
        }

        public override void Exit()
        {
            // Implement state exit logic
            Debug.Log(enemy.name + " exits attack state");
        }
    }

    [CreateAssetMenu(fileName = "FleeState", menuName = "States/FleeState")]
    public class FleeState : State
    {
        public override void Enter(Enemy enemy)
        {
            // Implement state enter logic
            Debug.Log(enemy.name + " enters flee state");
            this.enemy = enemy;
        }

        public override void Update()
        {
            // Implement state update logic
            Debug.Log(enemy.name + " updates flee state");

            // Call the enemy flee method
            this.enemy.Flee();

            // Check some conditions to change state
            if (this.enemy.Health > 50)
            {
                // Change to attack state if health is high enough
                this.enemy.ChangeState(this.enemy.AttackState);
            }
            else if (this.enemy.Health < 10)
            {
                // Change to heal state if health is too low
                this.enemy.ChangeState(this.enemy.HealState);
            }
        }

        public override void Exit()
        {
            // Implement state exit logic
            Debug.Log(enemy.name + " exits flee state");
        }
    }

    [CreateAssetMenu(fileName = "HealState", menuName = "States/HealState")]
    public class HealState : State
    {
        public override void Enter(Enemy enemy)
        {
            // Implement state enter logic
            Debug.Log(enemy.name + " enters heal state");
            this.enemy = enemy;
        }

        public override void Update()
        {
            // Implement state update logic
            Debug.Log(enemy.name + " updates heal state");

            // Call the enemy heal method
            this.enemy.Heal();

            // Check some conditions to change state
            if (this.enemy.Health < 50)
            {
                // Change to flee state if health is low
                this.enemy.ChangeState(this.enemy.FleeState);
            }
            else if (this.enemy.Health == 100)
            {
                // Change to attack state if health is full
                this.enemy.ChangeState(this.enemy.AttackState);
            }
        }

        public override void Exit()
        {
            // Implement state exit logic
            Debug.Log(enemy.name + " exits heal state");
        }
    }

    // Define a class for the enemy
    public class Enemy : MonoBehaviour
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        // Define fields to store the scriptable object states
        public State AttackState;
        public State FleeState;
        public State HealState;

        // Define a field to store the current state
        private State currentState;

        private void Start()
        {
            // Initialize the enemy properties
            this.Name = this.gameObject.name;
            this.Health = 50;
            this.Damage = 15;

            // Change the current state to attack state at the start
            this.ChangeState(this.AttackState);
        }

        private void Update()
        {
            // Update the current state every frame
            this.UpdateState();
        }

        // Define a method to change the current state
        public void ChangeState(State newState)
        {
            // Exit the current state if not null
            if (this.currentState != null)
            {
                this.currentState.Exit();
            }

            // Set the new state as the current state
            this.currentState = newState;

            // Enter the new state
            this.currentState.Enter(this);
        }

        // Define a method to update the current state
        public void UpdateState()
        {
            // Update the current state if not null
            if (this.currentState != null)
            {
                this.currentState.Update();
            }
        }

        // Define some methods for the enemy logic
        public void Attack()
        {
            // Implement enemy attack logic
            Debug.Log(this.Name + " attacks with " + this.Damage + " damage");
        }

        public void Flee()
        {
            // Implement enemy flee logic
            Debug.Log(this.Name + " flees from danger");
        }

        public void Heal()
        {
            // Implement enemy heal logic
            Debug.Log(this.Name + " heals for 10 health");
            this.Health += 10;
        }
    }




    #endregion

    #region Observer Pattern

    /* 
        Observer pattern is a behavioral pattern that defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically. 
        You can use an observer pattern to create a health bar that updates its value when the player's health changes.
    */

    // Define a delegate type for health events
    public delegate void HealthEventHandler(int currentHealth);

    // Define a class for the player
    public class PlayerObserverPattern : MonoBehaviour
    {
        public int MaxHealth = 100;
        public int CurrentHealth { get; private set; }

        // Define an event for health changes
        public event HealthEventHandler OnHealthChanged;

        private void Start()
        {
            // Initialize the current health to max health
            this.CurrentHealth = this.MaxHealth;

            // Invoke the health changed event at the start
            this.OnHealthChanged?.Invoke(this.CurrentHealth);
        }

        // Define a method to damage the player
        public void Damage(int amount)
        {
            // Reduce the current health by the amount
            this.CurrentHealth -= amount;

            // Clamp the current health between 0 and max health
            this.CurrentHealth = Mathf.Clamp(this.CurrentHealth, 0, this.MaxHealth);

            // Invoke the health changed event after taking damage
            this.OnHealthChanged?.Invoke(this.CurrentHealth);
        }

        // Define a method to heal the player
        public void Heal(int amount)
        {
            // Increase the current health by the amount
            this.CurrentHealth += amount;

            // Clamp the current health between 0 and max health
            this.CurrentHealth = Mathf.Clamp(this.CurrentHealth, 0, this.MaxHealth);

            // Invoke the health changed event after healing
            this.OnHealthChanged?.Invoke(this.CurrentHealth);
        }
    }

    // Define a class for the health bar
    public class HealthBar : MonoBehaviour
    {
        public PlayerObserverPattern player;
        public Slider slider;

        private void Start()
        {
            // Subscribe to the player's health changed event
            this.player.OnHealthChanged += this.UpdateHealthBar;
        }

        private void OnDestroy()
        {
            // Unsubscribe from the player's health changed event
            this.player.OnHealthChanged -= this.UpdateHealthBar;
        }

        // Define a method to update the health bar
        private void UpdateHealthBar(int currentHealth)
        {
            // Set the slider value to the current health percentage
            this.slider.value = (float)currentHealth / this.player.MaxHealth;
        }
    }

    // Use the player and the health bar in your game logic
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the player
            var player = new PlayerObserverPattern();

            // Create an instance of the health bar and assign the player reference
            HealthBar healthBar = new HealthBar();
            healthBar.player = player;

            // Simulate some damage and healing actions on the player
            player.Damage(20);
            player.Heal(10);
            player.Damage(50);
            player.Heal(30);
        }
    }




    #endregion
}

