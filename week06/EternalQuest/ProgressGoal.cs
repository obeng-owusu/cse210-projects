/// <summary>
/// Tracks gradual progress toward a large goal (e.g., 42 training runs).
/// </summary>
public class ProgressGoal : Goal
{
    private int _currentProgress;
    private int _targetProgress;

    public ProgressGoal(string name, string description, int points, int targetProgress)
        : base(name, description, points)
    {
        _targetProgress = targetProgress;
        _currentProgress = 0;
    }

    public ProgressGoal(string name, string description, int points, int targetProgress, int currentProgress)
        : base(name, description, points)
    {
        _targetProgress = targetProgress;
        _currentProgress = currentProgress;
    }

    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _currentProgress++;
            if (_currentProgress > _targetProgress)
                _currentProgress = _targetProgress;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete() => _currentProgress >= _targetProgress;

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description}) -- Progress: {_currentProgress}/{_targetProgress}";
    }

    // Format: ProgressGoal:name,description,points,targetProgress,currentProgress
    public override string GetStringRepresentation()
    {
        return $"ProgressGoal:{_shortName},{_description},{_points},{_targetProgress},{_currentProgress}";
    }
}