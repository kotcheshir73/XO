using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		ClassGameLogic logic;
		public Form1()
		{
			InitializeComponent();

			// В Tag фиксируем номер кнопки, соотвественно ячейке в списке
			button1.Tag = 0;
			button2.Tag = 1;
			button3.Tag = 2;
			button4.Tag = 3;
			button5.Tag = 4;
			button6.Tag = 5;
			button7.Tag = 6;
			button8.Tag = 7;
			button9.Tag = 8;
			logic = new ClassGameLogic();

		}

		private void button10_Click(object sender, EventArgs e)
		{
			logic.Start();
			Reload(logic.GetState(), false);
		}

		private void button_Click(object sender, EventArgs e)
		{
            try
            {
                Reload(logic.Step(Convert.ToInt32(((Button)sender).Tag), FieldState.Field_X), true);
                errorLabel.Text = "";
            }
            catch (XOException ex)
            {
                errorLabel.Text = String.Format("Ячейка {0} {1} занята", ex.row, ex.col);
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
            }
            finally
            {
                int x;

                Int32.TryParse(label2.Text, out x);

                label2.Text = (x + 1).ToString();
            }
		}

		/// <summary>
		/// Обновление поля
		/// </summary>
		/// <param name="state">Состояние игры</param>
		/// <param name="compStep">Делать ли ход компьютера</param>
		private void Reload(GameState state, bool compStep)
		{
			var field = logic.GetField();
            for (int i = 0; i < field.Length; ++i)
			{
				// Ищем среди всех элементов формы элемент с нужным названием (button + (i + 1)), это будет кнопка
				var button = ((Button)Controls.Find("button" + (i + 1), false)[0]);
				// определяем, каким значением ее заполнять
				button.Text = field[i] == FieldState.Field_O ? "O" : field[i] == FieldState.Field_X ? "X" : "";
			}
			switch (state)
			{
				case GameState.NotStarted:
                    //label1.Text = "Игра не началась";
                    //break;
                    throw new Exception("Игра не началась");
				case GameState.NoWin:
					label1.Text = "Ничья";
                    logic.SaveStat();
					break;
				case GameState.PlayerOWin:
					label1.Text = "Игрок ноликов выиграл";
                    logic.SaveStat();
                    break;
				case GameState.PlayerXWin:
                    label1.Text = "Игрок крестиков выиграл";
                    logic.SaveStat();
                    break;
				case GameState.InProgress:
					label1.Text = "Игра в процессе";
                    logic.stepCounter++;
                    if (compStep)
					{
						Reload(logic.Step(CompoStep(logic.GetField()), FieldState.Field_O), false);
					}
					break;
			}
		}

		private int CompoStep(FieldState[] fields)
		{
			for (int i = 0; i < fields.Length; ++i)
			{
				if (fields[i] == FieldState.Empty)
				{
					return i;
				}
			}
			return -1;
		}

        private void button11_Click(object sender, EventArgs e)
        {
            var data = Serializer.GetData(@"c:/stats.xml");

            var statsForm = new statsForm();

            statsForm.dataGridView1.DataSource = data;

            statsForm.Show();
        }
    }
}
