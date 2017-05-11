using System.Collections.Generic;

namespace WindowsFormsApp1
{
	/// <summary>
	/// Класс, храняищий информацию по полю
	/// </summary>
	class ClassGameLogic
	{
		/// <summary>
		/// Поле
		/// </summary>
		private List<FieldState> fields;

		/// <summary>
		/// Размерность поля
		/// </summary>
		private int size = 3;

		/// <summary>
		/// Статус игры
		/// </summary>
		private GameState state;

		/// <summary>
		/// Конструктор, в котором происходит инициализация списка полей
		/// </summary>
		public ClassGameLogic()
		{
			state = GameState.NotStarted;
			fields = new List<FieldState>();
			// заполняем список пустыми ячейками, в зависимости от размерности поля, например, 3х3 = 9 элементов
			for (int i = 0; i < size * size; ++i)
			{
				fields.Add(FieldState.Empty);
			}
		}

		/// <summary>
		/// Начало игры, все поля делаем пустыми
		/// </summary>
		public void Start()
		{
			for (int i = 0; i < fields.Count; ++i)
			{
				fields[i] = FieldState.Empty;
			}
			state = GameState.InProgress;
		}

		/// <summary>
		/// Возвращаем поле в виде массива
		/// во-первых, не возвращаем сам список, так как передастся ссылка на список, а значит можно будет из вне его изменить, что недопустимо
		/// во-вторых, массив, так как именно массив используется в стандартном методе CopyTo
		/// </summary>
		/// <returns></returns>
		public FieldState[] GetField()
		{
			FieldState[] array = new FieldState[fields.Count];
			fields.CopyTo(array);
			return array;
		}

		/// <summary>
		/// Ход одного из игроков
		/// </summary>
		/// <param name="index">Куда поставлено значение</param>
		/// <param name="field">Какое значение ставится, крестик или нолик</param>
		/// <returns>Состояние игры</returns>
		public GameState Step(int index, FieldState field)
		{
			if (index > -1 && index < fields.Count)
			{
				fields[index] = field;
				// CheckGame вернет true, коглда есть победитель
				// CheckNotEmptyButtons вернет true, коглда есть пустые поля
				// если и то и другое вернуло false, значит нет ни победителя, ни пустых полей для продолжения
				if (!CheckGame() && !CheckNotEmptyButtons())
				{
					state = GameState.NoWin;
				}
			}
			return state;
		}

		/// <summary>
		/// Простая логика проверки заполненности полей одинаковыми не пустыми значениями для поля 3х3
		/// </summary>
		/// <returns>true - есть победитель</returns>
		private bool CheckGame()
		{
			// первая строка заполнена идентичными не пустыми значениями
			if (fields[0] == fields[1] && fields[1] == fields[2] && fields[0] != FieldState.Empty)
			{
				state = (fields[0] == FieldState.Field_O) ? GameState.PlayerOWin : GameState.PlayerXWin;
				return true;
			}
			// вторая строка заполнена идентичными не пустыми значениями
			if (fields[3] == fields[4] && fields[4] == fields[5] && fields[3] != FieldState.Empty)
			{
				state = (fields[3] == FieldState.Field_O) ? GameState.PlayerOWin : GameState.PlayerXWin;
				return true;
			}
			// третья строка заполнена идентичными не пустыми значениями
			if (fields[6] == fields[7] && fields[7] == fields[8] && fields[6] != FieldState.Empty)
			{
				state = (fields[6] == FieldState.Field_O) ? GameState.PlayerOWin : GameState.PlayerXWin;
				return true;
			}
			// первый столбец заполнен идентичными не пустыми значениями
			if (fields[0] == fields[3] && fields[3] == fields[6] && fields[0] != FieldState.Empty)
			{
				state = (fields[0] == FieldState.Field_O) ? GameState.PlayerOWin : GameState.PlayerXWin;
				return true;
			}
			// второй столбец заполнен идентичными не пустыми значениями
			if (fields[1] == fields[4] && fields[4] == fields[7] && fields[1] != FieldState.Empty)
			{
				state = (fields[1] == FieldState.Field_O) ? GameState.PlayerOWin : GameState.PlayerXWin;
				return true;
			}
			// третий столбец заполнен идентичными не пустыми значениями
			if (fields[2] == fields[5] && fields[5] == fields[8] && fields[2] != FieldState.Empty)
			{
				state = (fields[2] == FieldState.Field_O) ? GameState.PlayerOWin : GameState.PlayerXWin;
				return true;
			}
			// главная диагональ заполнена идентичными не пустыми значениями
			if (fields[0] == fields[4] && fields[4] == fields[8] && fields[4] != FieldState.Empty)
			{
				state = (fields[4] == FieldState.Field_O) ? GameState.PlayerOWin : GameState.PlayerXWin;
				return true;
			}
			// побочная диагональ заполнена идентичными не пустыми значениями
			if (fields[2] == fields[4] && fields[4] == fields[6] && fields[4] != FieldState.Empty)
			{
				state = (fields[4] == FieldState.Field_O) ? GameState.PlayerOWin : GameState.PlayerXWin;
				return true;
			}
			return false;
		}

		/// <summary>
		/// Проверка, что есть еще пустые поля
		/// </summary>
		/// <returns>true - есть пустые поля</returns>
		private bool CheckNotEmptyButtons()
		{
			for (int i = 0; i < fields.Count; ++i)
			{
				if (fields[i] == FieldState.Empty)
				{
					return true;
				}
			}
			return false;
		}
	}
}
