﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace MedicTalk
{
	public partial class Form1 : Form
	{
		private bool loggedIn;
		Forgot_Password FGot_Pass;
		Forgot_UserName FGot_User;
		HomePage _HomePage;
		private string User_Name;
		private string Password;
		public string _firstName;
		public string _lastName;
		public string _room;
		public string _section;
		public Mysql_Connect _connect;
		private bool _commandResult;
		private string User_Id;List<string> Keywords;
		List<string> Parameters;
		List<string> ParameterValues;
		
		private string[] Query_Results;

		public Form1()
		{
			InitializeComponent();
			loggedIn = false;
			_commandResult = false;
			_connect = new Mysql_Connect();
			User_Id = "0";
			_firstName = "";
			_lastName = "";
			_room = "";
			_section = "";
		}


		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{


		}

		private void Forgot_UserName_Click(object sender, EventArgs e)
		{
			
					FGot_User = new MedicTalk.Forgot_UserName();
					this.Hide();
					FGot_User.Show();
					_connect = new Mysql_Connect();

		}


		private void Forgot_Password_Click(object sender, EventArgs e)
		{
			this.Hide();
			FGot_Pass.Show();

		}

		private void button2_Click(object sender, EventArgs e)
		{
			User_Name = textBox3.Text;
			Password = textBox4.Text;


			if (User_Name == "" || Password == "")
			{
				MessageBox.Show("You must enter both a password and username");
			}
			else
			{
				_commandResult = _connect.Login("SELECT * FROM Accounts WHERE User_Name = @user and Password=@Password", User_Name, Password);

				//Creates list of keywords to pass to select statement. This tells he select
				//function to return the values from those keywords.
				Keywords = new List<string>();
				Keywords.Add("User_Id");
				Keywords.Add("First_Name");
				Keywords.Add("Last_Name");
				Keywords.Add("Section");
				Keywords.Add("Room");
				Parameters = new List<string>();
				Parameters.Add("User_Name");
				Parameters.Add("Password");
				ParameterValues = new List<string>();
				ParameterValues.Add(User_Name);
				ParameterValues.Add(Password);
				
				string _returnedQuery = _connect.Select("SELECT User_id, First_Name, Last_Name, Section, Room FROM Accounts WHERE User_Name = @User_Name and Password=@Password", "1", Keywords, Parameters, ParameterValues);
			
				Query_Results = _returnedQuery.Split('/');
				User_Id = Query_Results[0];
				_firstName = Query_Results[1];
				_lastName = Query_Results[2];
				_section = Query_Results[3];
				_room = Query_Results[4];

				if (_commandResult)
				{
					loggedIn = true;
					_HomePage = new MedicTalk.HomePage(this, _connect);
					this.Hide();
					_HomePage.Show();
				}
				else
				{
					MessageBox.Show("Invalid Credentials");
				}
			}
		}

		public void Logout()
		{
	
				this.Show();
				_HomePage = null;
			
		}

		public string UserIDProperty
		{
			get
			{
				return User_Id;
			}
			set
			{
				User_Id = value;
			}
		}

		public string PasswordProperty
		{
			get
			{
				return Password;
			}
			set
			{
				Password = value;
			}
		}

		public string UserNameProperty
		{
			get
			{
				return User_Name;
			}
			set
			{
				User_Name = value;
			}
		}

		public string RoomProperty
		{
			get
			{
				return _room;
			}
		}


		public string SectionProperty
		{
			get
			{
				return _section;
			}
		}
		public string FirstNameProperty
		{
			get
			{
				return _firstName;
			}
		}

		public string LastNameProperty
		{
			get
			{
				return _lastName;
			}
		}

	}
}
