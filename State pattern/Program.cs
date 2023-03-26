// State pattern - Avoiding mutating state in the context class

public class Program
{
    static void Main(string[] args)
    {
        var gate = new Gate();
        Console.WriteLine(gate.State.GetType());

        gate.PayOk();
        Console.WriteLine(gate.State.GetType());

        gate.Enter();
        Console.WriteLine(gate.State.GetType());
    }
}

public class Gate // Context
{
    public GateState State { get; set; }
    public Gate() => State = new GateStateClosed();
    public void Enter() => this.State.Enter(this);
    public void Pay() => this.State.Pay(this);
    public void PayOk() => this.State.PayOk(this);
    public void PayFailed() => this.State.PayFailed(this);
}

public interface GateState // State
{
    void Enter(Gate gate);
    void Pay(Gate gate);
    void PayOk(Gate gate);
    void PayFailed(Gate gate);
}

public class GateStateOpen : GateState // Concrete state
{
    public void Enter(Gate gate) => gate.State = new GateStateClosed();
    public void Pay(Gate gate) => gate.State = new GateStateOpen();
    public void PayOk(Gate gate) => gate.State = new GateStateOpen();
    public void PayFailed(Gate gate) => gate.State = new GateStateOpen();
}

public class GateStateClosed : GateState // Concrete state
{
    public void Enter(Gate gate) { }
    public void Pay(Gate gate) => gate.State = new GateStateOpen(); // Should have a processing state here
    public void PayOk(Gate gate) => gate.State = new GateStateOpen();
    public void PayFailed(Gate gate) => gate.State = new GateStateClosed();
}

// Add more concrete states here for every state the gate can be in
// Each state will have a different implementation of the same methods

