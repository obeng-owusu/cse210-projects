public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int target, int bonusPoints)
        : base(name, description, points)
    {
        _target = target;
        _bonusPoints = bonusPoints;
        _amountCompleted = 0;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonusPoints, int amountCompleted)
        : base(name, description, points)
    {
        _target = target;
        _bonusPoints = bonusPoints;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _amountCompleted++;

            if (IsComplete())
            {
                return _points + _bonusPoints;
            }
            return _points;
        }
        return 0;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    // Format: ChecklistGoal:name,description,points,bonusPoints,target,amountCompleted
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonusPoints},{_target},{_amountCompleted}";
    }
}