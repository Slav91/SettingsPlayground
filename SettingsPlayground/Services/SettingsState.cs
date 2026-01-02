// Copyright Slav Povstianoj 2026

using SettingsPlayground.Models;

namespace SettingsPlayground.Services;

public class SettingsState
{
    private UserSettings _currentSettings = UserSettings.GetDefaults();
    private readonly SettingsStore _store;
    private readonly Stack<SettingChange> _history = new();
    private const int MaxHistorySize = 10;

    public event EventHandler? SettingsChanged;

    public UserSettings Current => _currentSettings;

    public bool CanUndo => _history.Count > 0;

    public SettingsState(SettingsStore store)
    {
        _store = store;
    }

    public async Task InitializeAsync()
    {
        _currentSettings = await _store.LoadAsync();
        NotifyChanged();
    }

    public async Task UpdateAsync(Action<UserSettings> updateAction, string settingName = "", string oldValue = "", string newValue = "")
    {
        // Save previous state for undo
        var previousSettings = _currentSettings.Clone();
        
        // Apply the update
        updateAction(_currentSettings);
        
        // Save to history
        if (!string.IsNullOrEmpty(settingName))
        {
            var change = new SettingChange
            {
                SettingName = settingName,
                OldValue = oldValue,
                NewValue = newValue,
                PreviousSettings = previousSettings,
                Timestamp = DateTime.Now
            };
            
            _history.Push(change);
            
            // Limit history size
            if (_history.Count > MaxHistorySize)
            {
                var temp = _history.ToList();
                temp.RemoveAt(temp.Count - 1);
                _history.Clear();
                foreach (var item in temp.AsEnumerable().Reverse())
                {
                    _history.Push(item);
                }
            }
        }
        
        // Persist
        await _store.SaveAsync(_currentSettings);
        
        // Notify
        NotifyChanged();
    }

    public async Task UndoAsync()
    {
        if (!CanUndo) return;

        var lastChange = _history.Pop();
        _currentSettings = lastChange.PreviousSettings.Clone();
        
        await _store.SaveAsync(_currentSettings);
        NotifyChanged();
    }

    public SettingChange? GetLastChange()
    {
        return _history.Count > 0 ? _history.Peek() : null;
    }

    public async Task ResetAsync()
    {
        await _store.ResetAsync();
        _currentSettings = UserSettings.GetDefaults();
        _history.Clear();
        await _store.SaveAsync(_currentSettings);
        NotifyChanged();
    }

    public async Task ImportSettingsAsync(UserSettings settings)
    {
        _currentSettings = settings.Clone();
        _history.Clear();
        await _store.SaveAsync(_currentSettings);
        NotifyChanged();
    }

    private void NotifyChanged()
    {
        System.Diagnostics.Debug.WriteLine($"Settings changed - notifying {SettingsChanged?.GetInvocationList()?.Length ?? 0} subscribers");
        SettingsChanged?.Invoke(this, EventArgs.Empty);
    }
}


