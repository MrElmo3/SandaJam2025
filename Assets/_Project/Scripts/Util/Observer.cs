using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Subject abstract class of the Observer pattern
/// </summary>
public abstract class Subject<T> : MonoBehaviour {
	private readonly List<IObserver<T>> _observers = new();

	public void AddObserver(IObserver<T> observer) {
		_observers.Add(observer);
	}

	public void RemoveObserver(IObserver<T> observer) {
		_observers.Remove(observer);
	}

	protected void NotifyObservers(T value) {
		_observers.ForEach((_observer) => {
			_observer.OnNotify(value);
		});
	}
}

/// <summary>
/// Interface of the observer pattern
/// </summary>
public interface IObserver<T> {

	/// <summary>
	/// Event triggered when the Subject calls the observers
	/// (The parameters may be changed or modified)
	/// </summary>
	public void OnNotify(T value);
}