namespace WindowsFormsApp1
{
	/// <summary>
	/// Возможные состояния игры
	/// </summary>
	enum GameState
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
		/// Игрок один выиграл
		/// </summary>
		Player1Win,

		/// <summary>
		/// Игрок 2 выиграл
		/// </summary>
		Player2Win
	}
}
