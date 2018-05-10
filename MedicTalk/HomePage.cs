﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicTalk
{
	public partial class HomePage : Form
	{
		private Form1 form1;
		private Drinks _drink;
		private Alarm _alarm;
		private BreakFast _breakfast;
		private Lunch _lunch;
		private Shower _shower;
		public Mysql_Connect _connect;
		public Request_Emergency _emergencyRequest;
		public Visitor _visitor;

		public HomePage(Form1 form1, Mysql_Connect connect)
		{
			this.form1 = form1;
			InitializeComponent();
			_connect = connect;
			_emergencyRequest = new Request_Emergency(_connect, form1);

		}

		//Logout button
		private void button4_Click(object sender, EventArgs e)
		{
			var _confirm = MessageBox.Show("Are you sure you want to log out?", "Confirm logout", MessageBoxButtons.YesNo);

			if (_confirm == DialogResult.Yes)
			{
				this.Hide();
				form1.Logout();
				form1.UserNameProperty = "";
				form1.PasswordProperty = "";
				form1.UserIDProperty = "0";
			}
			
		}

		//Emergency Button
		private void button7_Click(object sender, EventArgs e)
		{
			MessageBox.Show("A nurse will be with you as soon as possible");
			_emergencyRequest.CallRequest();
			
		}

		//Drinks Icon
		private void button9_Click(object sender, EventArgs e)
		{
			_drink = new MedicTalk.Drinks(this,_connect, form1, _emergencyRequest);
			this.Hide();
			_drink.Show();
		}

		//Alarm Icon
		private void button6_Click(object sender, EventArgs e)
		{
			_alarm = new MedicTalk.Alarm(this, _connect, form1, _emergencyRequest);
			this.Hide();
			_alarm.Show();
		}

		//Breakfast Icon
		private void button2_Click(object sender, EventArgs e)
		{
			_breakfast = new MedicTalk.BreakFast(this, _connect, form1, _emergencyRequest);
			this.Hide();
			_breakfast.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			_lunch = new MedicTalk.Lunch(this, _connect, form1, _emergencyRequest);
			this.Hide();
			_lunch.Show();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			_visitor = new MedicTalk.Visitor(this, _connect, form1, _emergencyRequest);
			this.Hide();
			_visitor.Show();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			_shower = new MedicTalk.Shower(this, _connect, form1, _emergencyRequest);
			this.Hide();
			_shower.Show();
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			_lunch = new MedicTalk.Lunch(this, _connect, form1, _emergencyRequest);
			this.Hide();
			_lunch.Show();
		}
	}
}