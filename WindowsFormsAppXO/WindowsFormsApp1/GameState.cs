namespace WindowsFormsApp1
{
	/// <summary>
	/// Возможные состояния игры
	/// </summary>
	public enum GameState
	{
		/// <summary>
		/// Игра не началась
		/// </summary>
		NotStarted,

		/// <summary>
		/// Игра в прогрессе
		/// </summary>
		InProgress,

		/// <summary>
		/// Игрок, играющий крестиками выиграл
		/// </summary>
		PlayerXWin,

		/// <summary>
		/// Игрок, играющий ноликами выиграл
		/// </summary>
		PlayerOWin,

		/// <summary>
		/// Ничья
		/// </summary>
		NoWin
	}
}
