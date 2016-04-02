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
	public class kilometerTableAdapter : Component
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
		public kilometerTableAdapter()
		{
			this.ClearBeforeFill = true;
		}

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Delete(long Original_ID, long Original_DOLGOZO_ID, DateTime Original_DATUM, string Original_HONNAN, string Original_HOVA, int Original_KM, string Original_SZOVEG, int Original_SZORZO)
		{
			int num;
			this.Adapter.DeleteCommand.Parameters[0].Value = Original_ID;
			this.Adapter.DeleteCommand.Parameters[1].Value = Original_DOLGOZO_ID;
			this.Adapter.DeleteCommand.Parameters[2].Value = Original_DATUM;
			if (Original_HONNAN != null)
			{
				this.Adapter.DeleteCommand.Parameters[3].Value = 0;
				this.Adapter.DeleteCommand.Parameters[4].Value = Original_HONNAN;
			}
			else
			{
				this.Adapter.DeleteCommand.Parameters[3].Value = 1;
				this.Adapter.DeleteCommand.Parameters[4].Value = DBNull.Value;
			}
			if (Original_HOVA != null)
			{
				this.Adapter.DeleteCommand.Parameters[5].Value = 0;
				this.Adapter.DeleteCommand.Parameters[6].Value = Original_HOVA;
			}
			else
			{
				this.Adapter.DeleteCommand.Parameters[5].Value = 1;
				this.Adapter.DeleteCommand.Parameters[6].Value = DBNull.Value;
			}
			this.Adapter.DeleteCommand.Parameters[7].Value = Original_KM;
			if (Original_SZOVEG != null)
			{
				this.Adapter.DeleteCommand.Parameters[8].Value = 0;
				this.Adapter.DeleteCommand.Parameters[9].Value = Original_SZOVEG;
			}
			else
			{
				this.Adapter.DeleteCommand.Parameters[8].Value = 1;
				this.Adapter.DeleteCommand.Parameters[9].Value = DBNull.Value;
			}
			this.Adapter.DeleteCommand.Parameters[10].Value = Original_SZORZO;
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
		public virtual int Fill(TKE.DataSet.kilometerDataTable dataTable)
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
		public virtual TKE.DataSet.kilometerDataTable GetData()
		{
			this.Adapter.SelectCommand = this.CommandCollection[0];
			TKE.DataSet.kilometerDataTable _kilometerDataTable = new TKE.DataSet.kilometerDataTable();
			this.Adapter.Fill(_kilometerDataTable);
			return _kilometerDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitAdapter()
		{
			this._adapter = new SqlDataAdapter();
			DataTableMapping dataTableMapping = new DataTableMapping()
			{
				SourceTable = "Table",
				DataSetTable = "kilometer"
			};
			dataTableMapping.ColumnMappings.Add("ID", "ID");
			dataTableMapping.ColumnMappings.Add("DOLGOZO_ID", "DOLGOZO_ID");
			dataTableMapping.ColumnMappings.Add("DATUM", "DATUM");
			dataTableMapping.ColumnMappings.Add("HONNAN", "HONNAN");
			dataTableMapping.ColumnMappings.Add("HOVA", "HOVA");
			dataTableMapping.ColumnMappings.Add("KM", "KM");
			dataTableMapping.ColumnMappings.Add("SZOVEG", "SZOVEG");
			dataTableMapping.ColumnMappings.Add("SZORZO", "SZORZO");
			this._adapter.TableMappings.Add((object)dataTableMapping);
			this._adapter.DeleteCommand = new SqlCommand()
			{
				Connection = this.Connection,
				CommandText = "DELETE FROM [dbo].[kilometer] WHERE (([ID] = @Original_ID) AND ([DOLGOZO_ID] = @Original_DOLGOZO_ID) AND ([DATUM] = @Original_DATUM) AND ((@IsNull_HONNAN = 1 AND [HONNAN] IS NULL) OR ([HONNAN] = @Original_HONNAN)) AND ((@IsNull_HOVA = 1 AND [HOVA] IS NULL) OR ([HOVA] = @Original_HOVA)) AND ([KM] = @Original_KM) AND ((@IsNull_SZOVEG = 1 AND [SZOVEG] IS NULL) OR ([SZOVEG] = @Original_SZOVEG)) AND ([SZORZO] = @Original_SZORZO))",
				CommandType = CommandType.Text
			};
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ID", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_DOLGOZO_ID", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "DOLGOZO_ID", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_DATUM", SqlDbType.Date, 0, ParameterDirection.Input, 0, 0, "DATUM", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_HONNAN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HONNAN", DataRowVersion.Original, true, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_HONNAN", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HONNAN", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_HOVA", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HOVA", DataRowVersion.Original, true, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_HOVA", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HOVA", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_KM", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "KM", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SZOVEG", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SZOVEG", DataRowVersion.Original, true, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SZOVEG", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SZOVEG", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SZORZO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SZORZO", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.InsertCommand = new SqlCommand()
			{
				Connection = this.Connection,
				CommandText = "INSERT INTO [dbo].[kilometer] ([DOLGOZO_ID], [DATUM], [HONNAN], [HOVA], [KM], [SZOVEG], [SZORZO]) VALUES (@DOLGOZO_ID, @DATUM, @HONNAN, @HOVA, @KM, @SZOVEG, @SZORZO);\r\nSELECT ID, DOLGOZO_ID, DATUM, HONNAN, HOVA, KM, SZOVEG, SZORZO FROM kilometer WHERE (ID = SCOPE_IDENTITY())",
				CommandType = CommandType.Text
			};
			this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@DOLGOZO_ID", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "DOLGOZO_ID", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@DATUM", SqlDbType.Date, 0, ParameterDirection.Input, 0, 0, "DATUM", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@HONNAN", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HONNAN", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@HOVA", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HOVA", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@KM", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "KM", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@SZOVEG", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SZOVEG", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@SZORZO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SZORZO", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.UpdateCommand = new SqlCommand()
			{
				Connection = this.Connection,
				CommandText = "UPDATE [dbo].[kilometer] SET [DOLGOZO_ID] = @DOLGOZO_ID, [DATUM] = @DATUM, [HONNAN] = @HONNAN, [HOVA] = @HOVA, [KM] = @KM, [SZOVEG] = @SZOVEG, [SZORZO] = @SZORZO WHERE (([ID] = @Original_ID) AND ([DOLGOZO_ID] = @Original_DOLGOZO_ID) AND ([DATUM] = @Original_DATUM) AND ((@IsNull_HONNAN = 1 AND [HONNAN] IS NULL) OR ([HONNAN] = @Original_HONNAN)) AND ((@IsNull_HOVA = 1 AND [HOVA] IS NULL) OR ([HOVA] = @Original_HOVA)) AND ([KM] = @Original_KM) AND ((@IsNull_SZOVEG = 1 AND [SZOVEG] IS NULL) OR ([SZOVEG] = @Original_SZOVEG)) AND ([SZORZO] = @Original_SZORZO));\r\nSELECT ID, DOLGOZO_ID, DATUM, HONNAN, HOVA, KM, SZOVEG, SZORZO FROM kilometer WHERE (ID = @ID)",
				CommandType = CommandType.Text
			};
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DOLGOZO_ID", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "DOLGOZO_ID", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DATUM", SqlDbType.Date, 0, ParameterDirection.Input, 0, 0, "DATUM", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@HONNAN", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HONNAN", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@HOVA", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HOVA", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@KM", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "KM", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SZOVEG", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SZOVEG", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SZORZO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SZORZO", DataRowVersion.Current, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ID", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_DOLGOZO_ID", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "DOLGOZO_ID", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_DATUM", SqlDbType.Date, 0, ParameterDirection.Input, 0, 0, "DATUM", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_HONNAN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HONNAN", DataRowVersion.Original, true, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_HONNAN", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HONNAN", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_HOVA", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HOVA", DataRowVersion.Original, true, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_HOVA", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HOVA", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_KM", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "KM", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SZOVEG", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SZOVEG", DataRowVersion.Original, true, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SZOVEG", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SZOVEG", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SZORZO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SZORZO", DataRowVersion.Original, false, null, "", "", ""));
			this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt, 8, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Current, false, null, "", "", ""));
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitCommandCollection()
		{
			this._commandCollection = new SqlCommand[] { new SqlCommand() };
			this._commandCollection[0].Connection = this.Connection;
			this._commandCollection[0].CommandText = "SELECT ID, DOLGOZO_ID, DATUM, HONNAN, HOVA, KM, SZOVEG, SZORZO FROM dbo.kilometer";
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
		public virtual int Insert(long DOLGOZO_ID, DateTime DATUM, string HONNAN, string HOVA, int KM, string SZOVEG, int SZORZO)
		{
			int num;
			this.Adapter.InsertCommand.Parameters[0].Value = DOLGOZO_ID;
			this.Adapter.InsertCommand.Parameters[1].Value = DATUM;
			if (HONNAN != null)
			{
				this.Adapter.InsertCommand.Parameters[2].Value = HONNAN;
			}
			else
			{
				this.Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
			}
			if (HOVA != null)
			{
				this.Adapter.InsertCommand.Parameters[3].Value = HOVA;
			}
			else
			{
				this.Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
			}
			this.Adapter.InsertCommand.Parameters[4].Value = KM;
			if (SZOVEG != null)
			{
				this.Adapter.InsertCommand.Parameters[5].Value = SZOVEG;
			}
			else
			{
				this.Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
			}
			this.Adapter.InsertCommand.Parameters[6].Value = SZORZO;
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
		public virtual int Update(TKE.DataSet.kilometerDataTable dataTable)
		{
			return this.Adapter.Update(dataTable);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Update(TKE.DataSet dataSet)
		{
			return this.Adapter.Update(dataSet, "kilometer");
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
		public virtual int Update(long DOLGOZO_ID, DateTime DATUM, string HONNAN, string HOVA, int KM, string SZOVEG, int SZORZO, long Original_ID, long Original_DOLGOZO_ID, DateTime Original_DATUM, string Original_HONNAN, string Original_HOVA, int Original_KM, string Original_SZOVEG, int Original_SZORZO, long ID)
		{
			int num;
			this.Adapter.UpdateCommand.Parameters[0].Value = DOLGOZO_ID;
			this.Adapter.UpdateCommand.Parameters[1].Value = DATUM;
			if (HONNAN != null)
			{
				this.Adapter.UpdateCommand.Parameters[2].Value = HONNAN;
			}
			else
			{
				this.Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
			}
			if (HOVA != null)
			{
				this.Adapter.UpdateCommand.Parameters[3].Value = HOVA;
			}
			else
			{
				this.Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
			}
			this.Adapter.UpdateCommand.Parameters[4].Value = KM;
			if (SZOVEG != null)
			{
				this.Adapter.UpdateCommand.Parameters[5].Value = SZOVEG;
			}
			else
			{
				this.Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
			}
			this.Adapter.UpdateCommand.Parameters[6].Value = SZORZO;
			this.Adapter.UpdateCommand.Parameters[7].Value = Original_ID;
			this.Adapter.UpdateCommand.Parameters[8].Value = Original_DOLGOZO_ID;
			this.Adapter.UpdateCommand.Parameters[9].Value = Original_DATUM;
			if (Original_HONNAN != null)
			{
				this.Adapter.UpdateCommand.Parameters[10].Value = 0;
				this.Adapter.UpdateCommand.Parameters[11].Value = Original_HONNAN;
			}
			else
			{
				this.Adapter.UpdateCommand.Parameters[10].Value = 1;
				this.Adapter.UpdateCommand.Parameters[11].Value = DBNull.Value;
			}
			if (Original_HOVA != null)
			{
				this.Adapter.UpdateCommand.Parameters[12].Value = 0;
				this.Adapter.UpdateCommand.Parameters[13].Value = Original_HOVA;
			}
			else
			{
				this.Adapter.UpdateCommand.Parameters[12].Value = 1;
				this.Adapter.UpdateCommand.Parameters[13].Value = DBNull.Value;
			}
			this.Adapter.UpdateCommand.Parameters[14].Value = Original_KM;
			if (Original_SZOVEG != null)
			{
				this.Adapter.UpdateCommand.Parameters[15].Value = 0;
				this.Adapter.UpdateCommand.Parameters[16].Value = Original_SZOVEG;
			}
			else
			{
				this.Adapter.UpdateCommand.Parameters[15].Value = 1;
				this.Adapter.UpdateCommand.Parameters[16].Value = DBNull.Value;
			}
			this.Adapter.UpdateCommand.Parameters[17].Value = Original_SZORZO;
			this.Adapter.UpdateCommand.Parameters[18].Value = ID;
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
		public virtual int Update(long DOLGOZO_ID, DateTime DATUM, string HONNAN, string HOVA, int KM, string SZOVEG, int SZORZO, long Original_ID, long Original_DOLGOZO_ID, DateTime Original_DATUM, string Original_HONNAN, string Original_HOVA, int Original_KM, string Original_SZOVEG, int Original_SZORZO)
		{
			return this.Update(DOLGOZO_ID, DATUM, HONNAN, HOVA, KM, SZOVEG, SZORZO, Original_ID, Original_DOLGOZO_ID, Original_DATUM, Original_HONNAN, Original_HOVA, Original_KM, Original_SZOVEG, Original_SZORZO, Original_ID);
		}
	}
}