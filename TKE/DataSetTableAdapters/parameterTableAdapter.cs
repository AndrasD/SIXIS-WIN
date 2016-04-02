using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using TKE;
using TKE.Properties;

namespace TKE.DataSetTableAdapters
{
	[DataObject(true)]
	[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[DesignerCategory("code")]
	[HelpKeyword("vs.data.TableAdapter")]
	[ToolboxItem(true)]
	public class parameterTableAdapter : Component
	{
		private SqlDataAdapter _adapter;

		private SqlConnection _connection;

		private SqlTransaction _transaction;

		private SqlCommand[] _commandCollection;

		private bool _clearBeforeFill;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected internal SqlDataAdapter Adapter
		{
			get
			{
				if (this._adapter == null)
				{
					this.InitAdapter();
				}
				return this._adapter;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool ClearBeforeFill
		{
			get
			{
				return this._clearBeforeFill;
			}
			set
			{
				this._clearBeforeFill = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected SqlCommand[] CommandCollection
		{
			get
			{
				if (this._commandCollection == null)
				{
					this.InitCommandCollection();
				}
				return this._commandCollection;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal SqlConnection Connection
		{
			get
			{
				if (this._connection == null)
				{
					this.InitConnection();
				}
				return this._connection;
			}
			set
			{
				this._connection = value;
				if (this.Adapter.InsertCommand != null)
				{
					this.Adapter.InsertCommand.Connection = value;
				}
				if (this.Adapter.DeleteCommand != null)
				{
					this.Adapter.DeleteCommand.Connection = value;
				}
				if (this.Adapter.UpdateCommand != null)
				{
					this.Adapter.UpdateCommand.Connection = value;
				}
				for (int i = 0; i < (int)this.CommandCollection.Length; i++)
				{
					if (this.CommandCollection[i] != null)
					{
						this.CommandCollection[i].Connection = value;
					}
				}
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal SqlTransaction Transaction
		{
			get
			{
				return this._transaction;
			}
			set
			{
				this._transaction = value;
				for (int i = 0; i < (int)this.CommandCollection.Length; i++)
				{
					this.CommandCollection[i].Transaction = this._transaction;
				}
				if (this.Adapter != null && this.Adapter.DeleteCommand != null)
				{
					this.Adapter.DeleteCommand.Transaction = this._transaction;
				}
				if (this.Adapter != null && this.Adapter.InsertCommand != null)
				{
					this.Adapter.InsertCommand.Transaction = this._transaction;
				}
				if (this.Adapter != null && this.Adapter.UpdateCommand != null)
				{
					this.Adapter.UpdateCommand.Transaction = this._transaction;
				}
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public parameterTableAdapter()
		{
			this.ClearBeforeFill = true;
		}

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Delete(long Original_ID, string Original_NEV, string Original_ERTEK)
		{
			int num;
			this.Adapter.DeleteCommand.Parameters[0].Value = Original_ID;
			if (Original_NEV == null)
			{
				throw new ArgumentNullException("Original_NEV");
			}
			this.Adapter.DeleteCommand.Parameters[1].Value = Original_NEV;
			if (Original_ERTEK == null)
			{
				throw new ArgumentNullException("Original_ERTEK");
			}
			this.Adapter.DeleteCommand.Parameters[2].Value = Original_ERTEK;
			ConnectionState state = this.Adapter.DeleteCommand.Connection.State;
			if ((this.Adapter.DeleteCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
			{
				this.Adapter.DeleteCommand.Connection.Open();
			}
			try
			{
				num = this.Adapter.DeleteCommand.ExecuteNonQuery();
			}
			finally
			{
				if (state == ConnectionState.Closed)
				{
					this.Adapter.DeleteCommand.Connection.Close();
				}
			}
			return num;
		}

		[DataObjectMethod(DataObjectMethodType.Fill, true)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Fill(TKE.DataSet.parameterDataTable dataTable)
		{
			this.Adapter.SelectCommand = this.CommandCollection[0];
			if (this.ClearBeforeFill)
			{
				dataTable.Clear();
			}
			return this.Adapter.Fill(dataTable);
		}

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual TKE.DataSet.parameterDataTable GetData()
		{
			this.Adapter.SelectCommand = this.CommandCollection[0];
			TKE.DataSet.parameterDataTable _parameterDataTable = new TKE.DataSet.parameterDataTable();
			this.Adapter.Fill(_parameterDataTable);
			return _parameterDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitAdapter()
		{
			this._adapter = new SqlDataAdapter();
			DataTableMapping dataTableMapping = new DataTableMapping()
			{
				SourceTable = "Table",
				DataSetTable = "parameter"
			};
			dataTableMapping.ColumnMappings.Add("ID", "ID");
			dataTableMapping.ColumnMappings.Add("NEV", "NEV");
			dataTableMapping.ColumnMappings.Add("ERTEK", "ERTEK");
			this._adapter.TableMappings.Add((object)dataTableMapping);
			this._adapter.DeleteCommand = new SqlCommand()
			{
				Connection = this.Connection,
				CommandText = "DELETE FROM [dbo].[parameter] WHERE (([ID] = @Original_ID) AND ([NEV] = @Original_NEV) AND ([ERTEK] = @Original_ERTEK))",
				CommandType = CommandType.Text
			};
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ID", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_NEV", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "NEV", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ERTEK", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ERTEK", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.InsertCommand = new SqlCommand()
			{
				Connection = this.Connection,
				CommandText = "",
				CommandType = CommandType.Text
			};
			this._adapter.UpdateCommand = new SqlCommand()
			{
				Connection = this.Connection,
				CommandText = "UPDATE [dbo].[parameter] SET [NEV] = @NEV, [ERTEK] = @ERTEK WHERE (([ID] = @Original_ID) AND ([NEV] = @Original_NEV) AND ([ERTEK] = @Original_ERTEK));\r\nSELECT ID, NEV, ERTEK FROM parameter WHERE (ID = @ID)",
				CommandType = CommandType.Text
			};
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NEV", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "NEV", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ERTEK", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ERTEK", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ID", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_NEV", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "NEV", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ERTEK", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ERTEK", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt, 8, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Current, false, null, "", "", ""));
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitCommandCollection()
		{
			this._commandCollection = new SqlCommand[] { new SqlCommand() };
			this._commandCollection[0].Connection = this.Connection;
			this._commandCollection[0].CommandText = "SELECT ID, NEV, ERTEK FROM dbo.parameter";
			this._commandCollection[0].CommandType = CommandType.Text;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitConnection()
		{
			this._connection = new SqlConnection()
			{
				ConnectionString = Settings.Default.tkeConnectionString
			};
		}

		[DataObjectMethod(DataObjectMethodType.Insert, true)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Insert()
		{
			int num;
			ConnectionState state = this.Adapter.InsertCommand.Connection.State;
			if ((this.Adapter.InsertCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
			{
				this.Adapter.InsertCommand.Connection.Open();
			}
			try
			{
				num = this.Adapter.InsertCommand.ExecuteNonQuery();
			}
			finally
			{
				if (state == ConnectionState.Closed)
				{
					this.Adapter.InsertCommand.Connection.Close();
				}
			}
			return num;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Update(TKE.DataSet.parameterDataTable dataTable)
		{
			return this.Adapter.Update(dataTable);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Update(TKE.DataSet dataSet)
		{
			return this.Adapter.Update(dataSet, "parameter");
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Update(DataRow dataRow)
		{
			return this.Adapter.Update(new DataRow[] { dataRow });
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Update(DataRow[] dataRows)
		{
			return this.Adapter.Update(dataRows);
		}

		[DataObjectMethod(DataObjectMethodType.Update, true)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Update(string NEV, string ERTEK, long Original_ID, string Original_NEV, string Original_ERTEK, long ID)
		{
			int num;
			if (NEV == null)
			{
				throw new ArgumentNullException("NEV");
			}
			this.Adapter.UpdateCommand.Parameters[0].Value = NEV;
			if (ERTEK == null)
			{
				throw new ArgumentNullException("ERTEK");
			}
			this.Adapter.UpdateCommand.Parameters[1].Value = ERTEK;
			this.Adapter.UpdateCommand.Parameters[2].Value = Original_ID;
			if (Original_NEV == null)
			{
				throw new ArgumentNullException("Original_NEV");
			}
			this.Adapter.UpdateCommand.Parameters[3].Value = Original_NEV;
			if (Original_ERTEK == null)
			{
				throw new ArgumentNullException("Original_ERTEK");
			}
			this.Adapter.UpdateCommand.Parameters[4].Value = Original_ERTEK;
			this.Adapter.UpdateCommand.Parameters[5].Value = ID;
			ConnectionState state = this.Adapter.UpdateCommand.Connection.State;
			if ((this.Adapter.UpdateCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
			{
				this.Adapter.UpdateCommand.Connection.Open();
			}
			try
			{
				num = this.Adapter.UpdateCommand.ExecuteNonQuery();
			}
			finally
			{
				if (state == ConnectionState.Closed)
				{
					this.Adapter.UpdateCommand.Connection.Close();
				}
			}
			return num;
		}

		[DataObjectMethod(DataObjectMethodType.Update, true)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Update(string NEV, string ERTEK, long Original_ID, string Original_NEV, string Original_ERTEK)
		{
			return this.Update(NEV, ERTEK, Original_ID, Original_NEV, Original_ERTEK, Original_ID);
		}
	}
}