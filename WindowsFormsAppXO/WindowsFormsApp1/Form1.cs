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
		Button[] buttons;


		public Form1()
		{
			InitializeComponent();

			buttons = new Button[]
				{
					button1, button2, button3, button4, button5, button6,button7, button8, button9,
				};

		}

		private void button10_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < buttons.Length; ++i)
			{
				buttons[i].Enabled = true;
				buttons[i].Text = "";
			}
		}

		private void button_Click(object sender, EventArgs e)
		{
			((Button)sender).Text = "X";
			if (CheckGame())
			{
				label1.Text = "Вы победили!";
				FinishGame();
				return;
			}
			if(CheckNotEmptyButtons())
			{
				CompoStep();
				if (CheckGame())
				{
					label1.Text = "Вы проиграли!";
					FinishGame();
				}
				else if (!CheckNotEmptyButtons())
				{
					label1.Text = "Ничья!";
					FinishGame();
				}
			}
			else
			{
				label1.Text = "Ничья!";
				FinishGame();
			}
		}

		private bool CheckGame()
		{
			if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X")
			{
				return true;
			}
			if (button3.Text == "X" && button4.Text == "X" && button7.Text == "X")
			{
				return true;
			}
			if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O")
			{
				return true;
			}
			return false;
		}

		private void FinishGame()
		{
			for (int i = 0; i < buttons.Length; ++i)
			{
				buttons[i].Enabled = false;
			}
		}

		private void CompoStep()
		{
			for (int i = 0; i < buttons.Length; ++i)
			{
				if (buttons[i].Text == "")
				{
					buttons[i].Text = "O";
					return;
				}
			}
		}

		private bool CheckNotEmptyButtons()
		{
			for (int i = 0; i < buttons.Length; ++i)
			{
				if(buttons[i].Text == "")
				{
					return true;
				}
			}
			return false;
		}
	}
}
