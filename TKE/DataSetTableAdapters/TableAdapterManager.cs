using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using TKE;

namespace TKE.DataSetTableAdapters
{
	[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[DesignerCategory("code")]
	[HelpKeyword("vs.data.TableAdapterManager")]
	[ToolboxItem(true)]
	public class TableAdapterManager : Component
	{
		private TableAdapterManager.UpdateOrderOption _updateOrder;

		private TKE.DataSetTableAdapters.dolgozoTableAdapter _dolgozoTableAdapter;

		private TKE.DataSetTableAdapters.kilometerTableAdapter _kilometerTableAdapter;

		private TKE.DataSetTableAdapters.parameterTableAdapter _parameterTableAdapter;

		private TKE.DataSetTableAdapters.tuloraTableAdapter _tuloraTableAdapter;

		private bool _backupDataSetBeforeUpdate;

		private IDbConnection _connection;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool BackupDataSetBeforeUpdate
		{
			get
			{
				return this._backupDataSetBeforeUpdate;
			}
			set
			{
				this._backupDataSetBeforeUpdate = value;
			}
		}

		[Browsable(false)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public IDbConnection Connection
		{
			get
			{
				if (this._connection != null)
				{
					return this._connection;
				}
				if (this._dolgozoTableAdapter != null && this._dolgozoTableAdapter.Connection != null)
				{
					return this._dolgozoTableAdapter.Connection;
				}
				if (this._kilometerTableAdapter != null && this._kilometerTableAdapter.Connection != null)
				{
					return this._kilometerTableAdapter.Connection;
				}
				if (this._parameterTableAdapter != null && this._parameterTableAdapter.Connection != null)
				{
					return this._parameterTableAdapter.Connection;
				}
				if (this._tuloraTableAdapter == null || this._tuloraTableAdapter.Connection == null)
				{
					return null;
				}
				return this._tuloraTableAdapter.Connection;
			}
			set
			{
				this._connection = value;
			}
		}

		[DebuggerNonUserCode]
		[Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public TKE.DataSetTableAdapters.dolgozoTableAdapter dolgozoTableAdapter
		{
			get
			{
				return this._dolgozoTableAdapter;
			}
			set
			{
				this._dolgozoTableAdapter = value;
			}
		}

		[DebuggerNonUserCode]
		[Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public TKE.DataSetTableAdapters.kilometerTableAdapter kilometerTableAdapter
		{
			get
			{
				return this._kilometerTableAdapter;
			}
			set
			{
				this._kilometerTableAdapter = value;
			}
		}

		[DebuggerNonUserCode]
		[Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public TKE.DataSetTableAdapters.parameterTableAdapter parameterTableAdapter
		{
			get
			{
				return this._parameterTableAdapter;
			}
			set
			{
				this._parameterTableAdapter = value;
			}
		}

		[Browsable(false)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int TableAdapterInstanceCount
		{
			get
			{
				int num = 0;
				if (this._dolgozoTableAdapter != null)
				{
					num++;
				}
				if (this._kilometerTableAdapter != null)
				{
					num++;
				}
				if (this._parameterTableAdapter != null)
				{
					num++;
				}
				if (this._tuloraTableAdapter != null)
				{
					num++;
				}
				return num;
			}
		}

		[DebuggerNonUserCode]
		[Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public TKE.DataSetTableAdapters.tuloraTableAdapter tuloraTableAdapter
		{
			get
			{
				return this._tuloraTableAdapter;
			}
			set
			{
				this._tuloraTableAdapter = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public TableAdapterManager.UpdateOrderOption UpdateOrder
		{
			get
			{
				return this._updateOrder;
			}
			set
			{
				this._updateOrder = value;
			}
		}

		public TableAdapterManager()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private DataRow[] GetRealUpdatedRows(DataRow[] updatedRows, List<DataRow> allAddedRows)
		{
			if (updatedRows == null || (int)updatedRows.Length < 1)
			{
				return updatedRows;
			}
			if (allAddedRows == null || allAddedRows.Count < 1)
			{
				return updatedRows;
			}
			List<DataRow> dataRows = new List<DataRow>();
			for (int i = 0; i < (int)updatedRows.Length; i++)
			{
				DataRow dataRow = updatedRows[i];
				if (!allAddedRows.Contains(dataRow))
				{
					dataRows.Add(dataRow);
				}
			}
			return dataRows.ToArray();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected virtual bool MatchTableAdapterConnection(IDbConnection inputConnection)
		{
			if (this._connection != null)
			{
				return true;
			}
			if (this.Connection == null || inputConnection == null)
			{
				return true;
			}
			if (string.Equals(this.Connection.ConnectionString, inputConnection.ConnectionString, StringComparison.Ordinal))
			{
				return true;
			}
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected virtual void SortSelfReferenceRows(DataRow[] rows, DataRelation relation, bool childFirst)
		{
			Array.Sort<DataRow>(rows, new TableAdapterManager.SelfReferenceComparer(relation, childFirst));
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public virtual int UpdateAll(TKE.DataSet dataSet)
		{
			if (dataSet == null)
			{
				throw new ArgumentNullException("dataSet");
			}
			if (!dataSet.HasChanges())
			{
				return 0;
			}
			if (this._dolgozoTableAdapter != null && !this.MatchTableAdapterConnection(this._dolgozoTableAdapter.Connection))
			{
				throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
			}
			if (this._kilometerTableAdapter != null && !this.MatchTableAdapterConnection(this._kilometerTableAdapter.Connection))
			{
				throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
			}
			if (this._parameterTableAdapter != null && !this.MatchTableAdapterConnection(this._parameterTableAdapter.Connection))
			{
				throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
			}
			if (this._tuloraTableAdapter != null && !this.MatchTableAdapterConnection(this._tuloraTableAdapter.Connection))
			{
				throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
			}
			IDbConnection connection = this.Connection;
			if (connection == null)
			{
				throw new ApplicationException("TableAdapterManager contains no connection information. Set each TableAdapterManager TableAdapter property to a valid TableAdapter instance.");
			}
			bool flag = false;
			if ((connection.State & ConnectionState.Broken) == ConnectionState.Broken)
			{
				connection.Close();
			}
			if (connection.State == ConnectionState.Closed)
			{
				connection.Open();
				flag = true;
			}
			IDbTransaction dbTransaction = connection.BeginTransaction();
			if (dbTransaction == null)
			{
				throw new ApplicationException("The transaction cannot begin. The current data connection does not support transactions or the current state is not allowing the transaction to begin.");
			}
			List<DataRow> dataRows = new List<DataRow>();
			List<DataRow> dataRows1 = new List<DataRow>();
			List<DataAdapter> dataAdapters = new List<DataAdapter>();
			Dictionary<object, IDbConnection> objs = new Dictionary<object, IDbConnection>();
			int num = 0;
			System.Data.DataSet dataSet1 = null;
			if (this.BackupDataSetBeforeUpdate)
			{
				dataSet1 = new System.Data.DataSet();
				dataSet1.Merge(dataSet);
			}
			try
			{
				try
				{
					if (this._dolgozoTableAdapter != null)
					{
						objs.Add(this._dolgozoTableAdapter, this._dolgozoTableAdapter.Connection);
						this._dolgozoTableAdapter.Connection = (SqlConnection)connection;
						this._dolgozoTableAdapter.Transaction = (SqlTransaction)dbTransaction;
						if (this._dolgozoTableAdapter.Adapter.AcceptChangesDuringUpdate)
						{
							this._dolgozoTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
							dataAdapters.Add(this._dolgozoTableAdapter.Adapter);
						}
					}
					if (this._kilometerTableAdapter != null)
					{
						objs.Add(this._kilometerTableAdapter, this._kilometerTableAdapter.Connection);
						this._kilometerTableAdapter.Connection = (SqlConnection)connection;
						this._kilometerTableAdapter.Transaction = (SqlTransaction)dbTransaction;
						if (this._kilometerTableAdapter.Adapter.AcceptChangesDuringUpdate)
						{
							this._kilometerTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
							dataAdapters.Add(this._kilometerTableAdapter.Adapter);
						}
					}
					if (this._parameterTableAdapter != null)
					{
						objs.Add(this._parameterTableAdapter, this._parameterTableAdapter.Connection);
						this._parameterTableAdapter.Connection = (SqlConnection)connection;
						this._parameterTableAdapter.Transaction = (SqlTransaction)dbTransaction;
						if (this._parameterTableAdapter.Adapter.AcceptChangesDuringUpdate)
						{
							this._parameterTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
							dataAdapters.Add(this._parameterTableAdapter.Adapter);
						}
					}
					if (this._tuloraTableAdapter != null)
					{
						objs.Add(this._tuloraTableAdapter, this._tuloraTableAdapter.Connection);
						this._tuloraTableAdapter.Connection = (SqlConnection)connection;
						this._tuloraTableAdapter.Transaction = (SqlTransaction)dbTransaction;
						if (this._tuloraTableAdapter.Adapter.AcceptChangesDuringUpdate)
						{
							this._tuloraTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
							dataAdapters.Add(this._tuloraTableAdapter.Adapter);
						}
					}
					if (this.UpdateOrder != TableAdapterManager.UpdateOrderOption.UpdateInsertDelete)
					{
						num = num + this.UpdateInsertedRows(dataSet, dataRows1);
						num = num + this.UpdateUpdatedRows(dataSet, dataRows, dataRows1);
					}
					else
					{
						num = num + this.UpdateUpdatedRows(dataSet, dataRows, dataRows1);
						num = num + this.UpdateInsertedRows(dataSet, dataRows1);
					}
					num = num + this.UpdateDeletedRows(dataSet, dataRows);
					dbTransaction.Commit();
					if (0 < dataRows1.Count)
					{
						DataRow[] dataRowArray = new DataRow[dataRows1.Count];
						dataRows1.CopyTo(dataRowArray);
						for (int i = 0; i < (int)dataRowArray.Length; i++)
						{
							dataRowArray[i].AcceptChanges();
						}
					}
					if (0 < dataRows.Count)
					{
						DataRow[] dataRowArray1 = new DataRow[dataRows.Count];
						dataRows.CopyTo(dataRowArray1);
						for (int j = 0; j < (int)dataRowArray1.Length; j++)
						{
							dataRowArray1[j].AcceptChanges();
						}
					}
				}
				catch (Exception exception1)
				{
					Exception exception = exception1;
					dbTransaction.Rollback();
					if (this.BackupDataSetBeforeUpdate)
					{
						dataSet.Clear();
						dataSet.Merge(dataSet1);
					}
					else if (0 < dataRows1.Count)
					{
						DataRow[] dataRowArray2 = new DataRow[dataRows1.Count];
						dataRows1.CopyTo(dataRowArray2);
						for (int k = 0; k < (int)dataRowArray2.Length; k++)
						{
							DataRow dataRow = dataRowArray2[k];
							dataRow.AcceptChanges();
							dataRow.SetAdded();
						}
					}
					throw exception;
				}
			}
			finally
			{
				if (flag)
				{
					connection.Close();
				}
				if (this._dolgozoTableAdapter != null)
				{
					this._dolgozoTableAdapter.Connection = (SqlConnection)objs[this._dolgozoTableAdapter];
					this._dolgozoTableAdapter.Transaction = null;
				}
				if (this._kilometerTableAdapter != null)
				{
					this._kilometerTableAdapter.Connection = (SqlConnection)objs[this._kilometerTableAdapter];
					this._kilometerTableAdapter.Transaction = null;
				}
				if (this._parameterTableAdapter != null)
				{
					this._parameterTableAdapter.Connection = (SqlConnection)objs[this._parameterTableAdapter];
					this._parameterTableAdapter.Transaction = null;
				}
				if (this._tuloraTableAdapter != null)
				{
					this._tuloraTableAdapter.Connection = (SqlConnection)objs[this._tuloraTableAdapter];
					this._tuloraTableAdapter.Transaction = null;
				}
				if (0 < dataAdapters.Count)
				{
					DataAdapter[] dataAdapterArray = new DataAdapter[dataAdapters.Count];
					dataAdapters.CopyTo(dataAdapterArray);
					for (int l = 0; l < (int)dataAdapterArray.Length; l++)
					{
						dataAdapterArray[l].AcceptChangesDuringUpdate = true;
					}
				}
			}
			return num;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private int UpdateDeletedRows(TKE.DataSet dataSet, List<DataRow> allChangedRows)
		{
			int num = 0;
			if (this._kilometerTableAdapter != null)
			{
				DataRow[] dataRowArray = dataSet.kilometer.Select(null, null, DataViewRowState.Deleted);
				if (dataRowArray != null && 0 < (int)dataRowArray.Length)
				{
					num = num + this._kilometerTableAdapter.Update(dataRowArray);
					allChangedRows.AddRange(dataRowArray);
				}
			}
			if (this._dolgozoTableAdapter != null)
			{
				DataRow[] dataRowArray1 = dataSet.dolgozo.Select(null, null, DataViewRowState.Deleted);
				if (dataRowArray1 != null && 0 < (int)dataRowArray1.Length)
				{
					num = num + this._dolgozoTableAdapter.Update(dataRowArray1);
					allChangedRows.AddRange(dataRowArray1);
				}
			}
			if (this._parameterTableAdapter != null)
			{
				DataRow[] dataRowArray2 = dataSet.parameter.Select(null, null, DataViewRowState.Deleted);
				if (dataRowArray2 != null && 0 < (int)dataRowArray2.Length)
				{
					num = num + this._parameterTableAdapter.Update(dataRowArray2);
					allChangedRows.AddRange(dataRowArray2);
				}
			}
			if (this._tuloraTableAdapter != null)
			{
				DataRow[] dataRowArray3 = dataSet.tulora.Select(null, null, DataViewRowState.Deleted);
				if (dataRowArray3 != null && 0 < (int)dataRowArray3.Length)
				{
					num = num + this._tuloraTableAdapter.Update(dataRowArray3);
					allChangedRows.AddRange(dataRowArray3);
				}
			}
			return num;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private int UpdateInsertedRows(TKE.DataSet dataSet, List<DataRow> allAddedRows)
		{
			int num = 0;
			if (this._tuloraTableAdapter != null)
			{
				DataRow[] dataRowArray = dataSet.tulora.Select(null, null, DataViewRowState.Added);
				if (dataRowArray != null && 0 < (int)dataRowArray.Length)
				{
					num = num + this._tuloraTableAdapter.Update(dataRowArray);
					allAddedRows.AddRange(dataRowArray);
				}
			}
			if (this._parameterTableAdapter != null)
			{
				DataRow[] dataRowArray1 = dataSet.parameter.Select(null, null, DataViewRowState.Added);
				if (dataRowArray1 != null && 0 < (int)dataRowArray1.Length)
				{
					num = num + this._parameterTableAdapter.Update(dataRowArray1);
					allAddedRows.AddRange(dataRowArray1);
				}
			}
			if (this._dolgozoTableAdapter != null)
			{
				DataRow[] dataRowArray2 = dataSet.dolgozo.Select(null, null, DataViewRowState.Added);
				if (dataRowArray2 != null && 0 < (int)dataRowArray2.Length)
				{
					num = num + this._dolgozoTableAdapter.Update(dataRowArray2);
					allAddedRows.AddRange(dataRowArray2);
				}
			}
			if (this._kilometerTableAdapter != null)
			{
				DataRow[] dataRowArray3 = dataSet.kilometer.Select(null, null, DataViewRowState.Added);
				if (dataRowArray3 != null && 0 < (int)dataRowArray3.Length)
				{
					num = num + this._kilometerTableAdapter.Update(dataRowArray3);
					allAddedRows.AddRange(dataRowArray3);
				}
			}
			return num;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private int UpdateUpdatedRows(TKE.DataSet dataSet, List<DataRow> allChangedRows, List<DataRow> allAddedRows)
		{
			int num = 0;
			if (this._tuloraTableAdapter != null)
			{
				DataRow[] realUpdatedRows = dataSet.tulora.Select(null, null, DataViewRowState.ModifiedCurrent);
				realUpdatedRows = this.GetRealUpdatedRows(realUpdatedRows, allAddedRows);
				if (realUpdatedRows != null && 0 < (int)realUpdatedRows.Length)
				{
					num = num + this._tuloraTableAdapter.Update(realUpdatedRows);
					allChangedRows.AddRange(realUpdatedRows);
				}
			}
			if (this._parameterTableAdapter != null)
			{
				DataRow[] dataRowArray = dataSet.parameter.Select(null, null, DataViewRowState.ModifiedCurrent);
				dataRowArray = this.GetRealUpdatedRows(dataRowArray, allAddedRows);
				if (dataRowArray != null && 0 < (int)dataRowArray.Length)
				{
					num = num + this._parameterTableAdapter.Update(dataRowArray);
					allChangedRows.AddRange(dataRowArray);
				}
			}
			if (this._dolgozoTableAdapter != null)
			{
				DataRow[] realUpdatedRows1 = dataSet.dolgozo.Select(null, null, DataViewRowState.ModifiedCurrent);
				realUpdatedRows1 = this.GetRealUpdatedRows(realUpdatedRows1, allAddedRows);
				if (realUpdatedRows1 != null && 0 < (int)realUpdatedRows1.Length)
				{
					num = num + this._dolgozoTableAdapter.Update(realUpdatedRows1);
					allChangedRows.AddRange(realUpdatedRows1);
				}
			}
			if (this._kilometerTableAdapter != null)
			{
				DataRow[] dataRowArray1 = dataSet.kilometer.Select(null, null, DataViewRowState.ModifiedCurrent);
				dataRowArray1 = this.GetRealUpdatedRows(dataRowArray1, allAddedRows);
				if (dataRowArray1 != null && 0 < (int)dataRowArray1.Length)
				{
					num = num + this._kilometerTableAdapter.Update(dataRowArray1);
					allChangedRows.AddRange(dataRowArray1);
				}
			}
			return num;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private class SelfReferenceComparer : IComparer<DataRow>
		{
			private DataRelation _relation;

			private int _childFirst;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal SelfReferenceComparer(DataRelation relation, bool childFirst)
			{
				this._relation = relation;
				if (childFirst)
				{
					this._childFirst = -1;
					return;
				}
				this._childFirst = 1;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int Compare(DataRow row1, DataRow row2)
			{
				if (object.ReferenceEquals(row1, row2))
				{
					return 0;
				}
				if (row1 == null)
				{
					return -1;
				}
				if (row2 == null)
				{
					return 1;
				}
				int num = 0;
				DataRow root = this.GetRoot(row1, out num);
				int num1 = 0;
				DataRow dataRow = this.GetRoot(row2, out num1);
				if (object.ReferenceEquals(root, dataRow))
				{
					return this._childFirst * num.CompareTo(num1);
				}
				if (root.Table.Rows.IndexOf(root) < dataRow.Table.Rows.IndexOf(dataRow))
				{
					return -1;
				}
				return 1;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			private DataRow GetRoot(DataRow row, out int distance)
			{
				DataRow i;
				DataRow dataRow = row;
				distance = 0;
				IDictionary<DataRow, DataRow> dataRows = new Dictionary<DataRow, DataRow>();
				dataRows[row] = row;
				for (i = row.GetParentRow(this._relation, DataRowVersion.Default); i != null && !dataRows.ContainsKey(i); i = i.GetParentRow(this._relation, DataRowVersion.Default))
				{
					distance = distance + 1;
					dataRow = i;
					dataRows[i] = i;
				}
				if (distance == 0)
				{
					dataRows.Clear();
					dataRows[row] = row;
					for (i = row.GetParentRow(this._relation, DataRowVersion.Original); i != null && !dataRows.ContainsKey(i); i = i.GetParentRow(this._relation, DataRowVersion.Original))
					{
						distance = distance + 1;
						dataRow = i;
						dataRows[i] = i;
					}
				}
				return dataRow;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public enum UpdateOrderOption
		{
			InsertUpdateDelete,
			UpdateInsertDelete
		}
	}
}