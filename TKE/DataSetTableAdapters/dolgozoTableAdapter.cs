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
	public class dolgozoTableAdapter : Component
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
		public dolgozoTableAdapter()
		{
			this.ClearBeforeFill = true;
		}

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Delete(long Original_ID, string Original_DOLGOZO_NEV, string Original_AZONOSITO, string Original_JELSZO, string Original_SZINT)
		{
			int num;
			this.Adapter.DeleteCommand.Parameters[0].Value = Original_ID;
			if (Original_DOLGOZO_NEV == null)
			{
				throw new ArgumentNullException("Original_DOLGOZO_NEV");
			}
			this.Adapter.DeleteCommand.Parameters[1].Value = Original_DOLGOZO_NEV;
			if (Original_AZONOSITO == null)
			{
				throw new ArgumentNullException("Original_AZONOSITO");
			}
			this.Adapter.DeleteCommand.Parameters[2].Value = Original_AZONOSITO;
			if (Original_JELSZO == null)
			{
				throw new ArgumentNullException("Original_JELSZO");
			}
			this.Adapter.DeleteCommand.Parameters[3].Value = Original_JELSZO;
			if (Original_SZINT == null)
			{
				throw new ArgumentNullException("Original_SZINT");
			}
			this.Adapter.DeleteCommand.Parameters[4].Value = Original_SZINT;
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
		public virtual int Fill(TKE.DataSet.dolgozoDataTable dataTable)
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
		public virtual TKE.DataSet.dolgozoDataTable GetData()
		{
			this.Adapter.SelectCommand = this.CommandCollection[0];
			TKE.DataSet.dolgozoDataTable _dolgozoDataTable = new TKE.DataSet.dolgozoDataTable();
			this.Adapter.Fill(_dolgozoDataTable);
			return _dolgozoDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitAdapter()
		{
			this._adapter = new SqlDataAdapter();
			DataTableMapping dataTableMapping = new DataTableMapping()
			{
				SourceTable = "Table",
				DataSetTable = "dolgozo"
			};
			dataTableMapping.ColumnMappings.Add("ID", "ID");
			dataTableMapping.ColumnMappings.Add("DOLGOZO_NEV", "DOLGOZO_NEV");
			dataTableMapping.ColumnMappings.Add("AZONOSITO", "AZONOSITO");
			dataTableMapping.ColumnMappings.Add("JELSZO", "JELSZO");
			dataTableMapping.ColumnMappings.Add("SZINT", "SZINT");
			this._adapter.TableMappings.Add((object)dataTableMapping);
			this._adapter.DeleteCommand = new SqlCommand()
			{
				Connection = this.Connection,
				CommandText = "DELETE FROM [dbo].[dolgozo] WHERE (([ID] = @Original_ID) AND ([DOLGOZO_NEV] = @Original_DOLGOZO_NEV) AND ([AZONOSITO] = @Original_AZONOSITO) AND ([JELSZO] = @Original_JELSZO) AND ([SZINT] = @Original_SZINT))",
				CommandType = CommandType.Text
			};
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ID", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_DOLGOZO_NEV", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "DOLGOZO_NEV", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_AZONOSITO", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "AZONOSITO", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_JELSZO", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "JELSZO", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SZINT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SZINT", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.InsertCommand = new SqlCommand()
			{
				Connection = this.Connection,
				CommandText = "INSERT INTO [dbo].[dolgozo] ([DOLGOZO_NEV], [AZONOSITO], [JELSZO], [SZINT]) VALUES (@DOLGOZO_NEV, @AZONOSITO, @JELSZO, @SZINT);\r\nSELECT ID, DOLGOZO_NEV, AZONOSITO, JELSZO, SZINT FROM dolgozo WHERE (ID = SCOPE_IDENTITY())",
				CommandType = CommandType.Text
			};
			this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@DOLGOZO_NEV", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "DOLGOZO_NEV", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@AZONOSITO", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "AZONOSITO", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@JELSZO", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "JELSZO", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@SZINT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SZINT", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.UpdateCommand = new SqlCommand()
			{
				Connection = this.Connection,
				CommandText = "UPDATE [dbo].[dolgozo] SET [DOLGOZO_NEV] = @DOLGOZO_NEV, [AZONOSITO] = @AZONOSITO, [JELSZO] = @JELSZO, [SZINT] = @SZINT WHERE (([ID] = @Original_ID) AND ([DOLGOZO_NEV] = @Original_DOLGOZO_NEV) AND ([AZONOSITO] = @Original_AZONOSITO) AND ([JELSZO] = @Original_JELSZO) AND ([SZINT] = @Original_SZINT));\r\nSELECT ID, DOLGOZO_NEV, AZONOSITO, JELSZO, SZINT FROM dolgozo WHERE (ID = @ID)",
				CommandType = CommandType.Text
			};
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DOLGOZO_NEV", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "DOLGOZO_NEV", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@AZONOSITO", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "AZONOSITO", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@JELSZO", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "JELSZO", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SZINT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SZINT", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ID", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_DOLGOZO_NEV", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "DOLGOZO_NEV", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_AZONOSITO", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "AZONOSITO", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_JELSZO", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "JELSZO", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SZINT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SZINT", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt, 8, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Current, false, null, "", "", ""));
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitCommandCollection()
		{
			this._commandCollection = new SqlCommand[] { new SqlCommand() };
			this._commandCollection[0].Connection = this.Connection;
			this._commandCollection[0].CommandText = "SELECT ID, DOLGOZO_NEV, AZONOSITO, JELSZO, SZINT FROM dbo.dolgozo";
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
		public virtual int Insert(string DOLGOZO_NEV, string AZONOSITO, string JELSZO, string SZINT)
		{
			int num;
			if (DOLGOZO_NEV == null)
			{
				throw new ArgumentNullException("DOLGOZO_NEV");
			}
			this.Adapter.InsertCommand.Parameters[0].Value = DOLGOZO_NEV;
			if (AZONOSITO == null)
			{
				throw new ArgumentNullException("AZONOSITO");
			}
			this.Adapter.InsertCommand.Parameters[1].Value = AZONOSITO;
			if (JELSZO == null)
			{
				throw new ArgumentNullException("JELSZO");
			}
			this.Adapter.InsertCommand.Parameters[2].Value = JELSZO;
			if (SZINT == null)
			{
				throw new ArgumentNullException("SZINT");
			}
			this.Adapter.InsertCommand.Parameters[3].Value = SZINT;
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
		public virtual int Update(TKE.DataSet.dolgozoDataTable dataTable)
		{
			return this.Adapter.Update(dataTable);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Update(TKE.DataSet dataSet)
		{
			return this.Adapter.Update(dataSet, "dolgozo");
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
		public virtual int Update(string DOLGOZO_NEV, string AZONOSITO, string JELSZO, string SZINT, long Original_ID, string Original_DOLGOZO_NEV, string Original_AZONOSITO, string Original_JELSZO, string Original_SZINT, long ID)
		{
			int num;
			if (DOLGOZO_NEV == null)
			{
				throw new ArgumentNullException("DOLGOZO_NEV");
			}
			this.Adapter.UpdateCommand.Parameters[0].Value = DOLGOZO_NEV;
			if (AZONOSITO == null)
			{
				throw new ArgumentNullException("AZONOSITO");
			}
			this.Adapter.UpdateCommand.Parameters[1].Value = AZONOSITO;
			if (JELSZO == null)
			{
				throw new ArgumentNullException("JELSZO");
			}
			this.Adapter.UpdateCommand.Parameters[2].Value = JELSZO;
			if (SZINT == null)
			{
				throw new ArgumentNullException("SZINT");
			}
			this.Adapter.UpdateCommand.Parameters[3].Value = SZINT;
			this.Adapter.UpdateCommand.Parameters[4].Value = Original_ID;
			if (Original_DOLGOZO_NEV == null)
			{
				throw new ArgumentNullException("Original_DOLGOZO_NEV");
			}
			this.Adapter.UpdateCommand.Parameters[5].Value = Original_DOLGOZO_NEV;
			if (Original_AZONOSITO == null)
			{
				throw new ArgumentNullException("Original_AZONOSITO");
			}
			this.Adapter.UpdateCommand.Parameters[6].Value = Original_AZONOSITO;
			if (Original_JELSZO == null)
			{
				throw new ArgumentNullException("Original_JELSZO");
			}
			this.Adapter.UpdateCommand.Parameters[7].Value = Original_JELSZO;
			if (Original_SZINT == null)
			{
				throw new ArgumentNullException("Original_SZINT");
			}
			this.Adapter.UpdateCommand.Parameters[8].Value = Original_SZINT;
			this.Adapter.UpdateCommand.Parameters[9].Value = ID;
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
		public virtual int Update(string DOLGOZO_NEV, string AZONOSITO, string JELSZO, string SZINT, long Original_ID, string Original_DOLGOZO_NEV, string Original_AZONOSITO, string Original_JELSZO, string Original_SZINT)
		{
			return this.Update(DOLGOZO_NEV, AZONOSITO, JELSZO, SZINT, Original_ID, Original_DOLGOZO_NEV, Original_AZONOSITO, Original_JELSZO, Original_SZINT, Original_ID);
		}
	}
}