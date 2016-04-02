using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TKE
{
	[DesignerCategory("code")]
	[HelpKeyword("vs.data.DataSet")]
	[Serializable]
	[ToolboxItem(true)]
	[XmlRoot("DataSet")]
	[XmlSchemaProvider("GetTypedDataSetSchema")]
	public class DataSet : System.Data.DataSet
	{
		private TKE.DataSet.dolgozoDataTable tabledolgozo;

		private TKE.DataSet.kilometerDataTable tablekilometer;

		private TKE.DataSet.parameterDataTable tableparameter;

		private TKE.DataSet.tuloraDataTable tabletulora;

		private TKE.DataSet.TK_ViewDataTable tableTK_View;

		private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

		[Browsable(false)]
		[DebuggerNonUserCode]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public TKE.DataSet.dolgozoDataTable dolgozo
		{
			get
			{
				return this.tabledolgozo;
			}
		}

		[Browsable(false)]
		[DebuggerNonUserCode]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public TKE.DataSet.kilometerDataTable kilometer
		{
			get
			{
				return this.tablekilometer;
			}
		}

		[Browsable(false)]
		[DebuggerNonUserCode]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public TKE.DataSet.parameterDataTable parameter
		{
			get
			{
				return this.tableparameter;
			}
		}

		[DebuggerNonUserCode]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public new DataRelationCollection Relations
		{
			get
			{
				return base.Relations;
			}
		}

		[Browsable(true)]
		[DebuggerNonUserCode]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override System.Data.SchemaSerializationMode SchemaSerializationMode
		{
			get
			{
				return this._schemaSerializationMode;
			}
			set
			{
				this._schemaSerializationMode = value;
			}
		}

		[DebuggerNonUserCode]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public new DataTableCollection Tables
		{
			get
			{
				return base.Tables;
			}
		}

		[Browsable(false)]
		[DebuggerNonUserCode]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public TKE.DataSet.TK_ViewDataTable TK_View
		{
			get
			{
				return this.tableTK_View;
			}
		}

		[Browsable(false)]
		[DebuggerNonUserCode]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public TKE.DataSet.tuloraDataTable tulora
		{
			get
			{
				return this.tabletulora;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataSet()
		{
			base.BeginInit();
			this.InitClass();
			CollectionChangeEventHandler collectionChangeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
			base.Tables.CollectionChanged += collectionChangeEventHandler;
			base.Relations.CollectionChanged += collectionChangeEventHandler;
			base.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected DataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
		{
			if (base.IsBinarySerialized(info, context))
			{
				this.InitVars(false);
				CollectionChangeEventHandler collectionChangeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
				this.Tables.CollectionChanged += collectionChangeEventHandler;
				this.Relations.CollectionChanged += collectionChangeEventHandler;
				return;
			}
			string value = (string)info.GetValue("XmlSchema", typeof(string));
			if (base.DetermineSchemaSerializationMode(info, context) != System.Data.SchemaSerializationMode.IncludeSchema)
			{
				base.ReadXmlSchema(new XmlTextReader(new StringReader(value)));
			}
			else
			{
				System.Data.DataSet dataSet = new System.Data.DataSet();
				dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(value)));
				if (dataSet.Tables["dolgozo"] != null)
				{
					base.Tables.Add(new TKE.DataSet.dolgozoDataTable(dataSet.Tables["dolgozo"]));
				}
				if (dataSet.Tables["kilometer"] != null)
				{
					base.Tables.Add(new TKE.DataSet.kilometerDataTable(dataSet.Tables["kilometer"]));
				}
				if (dataSet.Tables["parameter"] != null)
				{
					base.Tables.Add(new TKE.DataSet.parameterDataTable(dataSet.Tables["parameter"]));
				}
				if (dataSet.Tables["tulora"] != null)
				{
					base.Tables.Add(new TKE.DataSet.tuloraDataTable(dataSet.Tables["tulora"]));
				}
				if (dataSet.Tables["TK_View"] != null)
				{
					base.Tables.Add(new TKE.DataSet.TK_ViewDataTable(dataSet.Tables["TK_View"]));
				}
				base.DataSetName = dataSet.DataSetName;
				base.Prefix = dataSet.Prefix;
				base.Namespace = dataSet.Namespace;
				base.Locale = dataSet.Locale;
				base.CaseSensitive = dataSet.CaseSensitive;
				base.EnforceConstraints = dataSet.EnforceConstraints;
				base.Merge(dataSet, false, MissingSchemaAction.Add);
				this.InitVars();
			}
			base.GetSerializationData(info, context);
			CollectionChangeEventHandler collectionChangeEventHandler1 = new CollectionChangeEventHandler(this.SchemaChanged);
			base.Tables.CollectionChanged += collectionChangeEventHandler1;
			this.Relations.CollectionChanged += collectionChangeEventHandler1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override System.Data.DataSet Clone()
		{
			TKE.DataSet schemaSerializationMode = (TKE.DataSet)base.Clone();
			schemaSerializationMode.InitVars();
			schemaSerializationMode.SchemaSerializationMode = this.SchemaSerializationMode;
			return schemaSerializationMode;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override XmlSchema GetSchemaSerializable()
		{
			MemoryStream memoryStream = new MemoryStream();
			base.WriteXmlSchema(new XmlTextWriter(memoryStream, null));
			memoryStream.Position = (long)0;
			return XmlSchema.Read(new XmlTextReader(memoryStream), null);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType;
			XmlSchema xmlSchema;
			TKE.DataSet dataSet = new TKE.DataSet();
			XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
			{
				Namespace = dataSet.Namespace
			};
			xmlSchemaSequence.Items.Add(xmlSchemaAny);
			xmlSchemaComplexType1.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = dataSet.GetSchemaSerializable();
			if (xs.Contains(schemaSerializable.TargetNamespace))
			{
				MemoryStream memoryStream = new MemoryStream();
				MemoryStream memoryStream1 = new MemoryStream();
				try
				{
					XmlSchema current = null;
					schemaSerializable.Write(memoryStream);
					IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
					while (enumerator.MoveNext())
					{
						current = (XmlSchema)enumerator.Current;
						memoryStream1.SetLength((long)0);
						current.Write(memoryStream1);
						if (memoryStream.Length != memoryStream1.Length)
						{
							continue;
						}
						memoryStream.Position = (long)0;
						memoryStream1.Position = (long)0;
						while (memoryStream.Position != memoryStream.Length && memoryStream.ReadByte() == memoryStream1.ReadByte())
						{
						}
						if (memoryStream.Position != memoryStream.Length)
						{
							continue;
						}
						xmlSchemaComplexType = xmlSchemaComplexType1;
						return xmlSchemaComplexType;
					}
					xmlSchema = xs.Add(schemaSerializable);
					return xmlSchemaComplexType1;
				}
				finally
				{
					if (memoryStream != null)
					{
						memoryStream.Close();
					}
					if (memoryStream1 != null)
					{
						memoryStream1.Close();
					}
				}
				return xmlSchemaComplexType;
			}
			xmlSchema = xs.Add(schemaSerializable);
			return xmlSchemaComplexType1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitClass()
		{
			base.DataSetName = "DataSet";
			base.Prefix = "";
			base.Namespace = "http://tempuri.org/DataSet.xsd";
			base.EnforceConstraints = true;
			this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			this.tabledolgozo = new TKE.DataSet.dolgozoDataTable();
			base.Tables.Add(this.tabledolgozo);
			this.tablekilometer = new TKE.DataSet.kilometerDataTable();
			base.Tables.Add(this.tablekilometer);
			this.tableparameter = new TKE.DataSet.parameterDataTable();
			base.Tables.Add(this.tableparameter);
			this.tabletulora = new TKE.DataSet.tuloraDataTable();
			base.Tables.Add(this.tabletulora);
			this.tableTK_View = new TKE.DataSet.TK_ViewDataTable();
			base.Tables.Add(this.tableTK_View);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void InitializeDerivedDataSet()
		{
			base.BeginInit();
			this.InitClass();
			base.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void InitVars()
		{
			this.InitVars(true);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void InitVars(bool initTable)
		{
			this.tabledolgozo = (TKE.DataSet.dolgozoDataTable)base.Tables["dolgozo"];
			if (initTable && this.tabledolgozo != null)
			{
				this.tabledolgozo.InitVars();
			}
			this.tablekilometer = (TKE.DataSet.kilometerDataTable)base.Tables["kilometer"];
			if (initTable && this.tablekilometer != null)
			{
				this.tablekilometer.InitVars();
			}
			this.tableparameter = (TKE.DataSet.parameterDataTable)base.Tables["parameter"];
			if (initTable && this.tableparameter != null)
			{
				this.tableparameter.InitVars();
			}
			this.tabletulora = (TKE.DataSet.tuloraDataTable)base.Tables["tulora"];
			if (initTable && this.tabletulora != null)
			{
				this.tabletulora.InitVars();
			}
			this.tableTK_View = (TKE.DataSet.TK_ViewDataTable)base.Tables["TK_View"];
			if (initTable && this.tableTK_View != null)
			{
				this.tableTK_View.InitVars();
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void ReadXmlSerializable(XmlReader reader)
		{
			if (base.DetermineSchemaSerializationMode(reader) != System.Data.SchemaSerializationMode.IncludeSchema)
			{
				base.ReadXml(reader);
				this.InitVars();
				return;
			}
			this.Reset();
			System.Data.DataSet dataSet = new System.Data.DataSet();
			dataSet.ReadXml(reader);
			if (dataSet.Tables["dolgozo"] != null)
			{
				base.Tables.Add(new TKE.DataSet.dolgozoDataTable(dataSet.Tables["dolgozo"]));
			}
			if (dataSet.Tables["kilometer"] != null)
			{
				base.Tables.Add(new TKE.DataSet.kilometerDataTable(dataSet.Tables["kilometer"]));
			}
			if (dataSet.Tables["parameter"] != null)
			{
				base.Tables.Add(new TKE.DataSet.parameterDataTable(dataSet.Tables["parameter"]));
			}
			if (dataSet.Tables["tulora"] != null)
			{
				base.Tables.Add(new TKE.DataSet.tuloraDataTable(dataSet.Tables["tulora"]));
			}
			if (dataSet.Tables["TK_View"] != null)
			{
				base.Tables.Add(new TKE.DataSet.TK_ViewDataTable(dataSet.Tables["TK_View"]));
			}
			base.DataSetName = dataSet.DataSetName;
			base.Prefix = dataSet.Prefix;
			base.Namespace = dataSet.Namespace;
			base.Locale = dataSet.Locale;
			base.CaseSensitive = dataSet.CaseSensitive;
			base.EnforceConstraints = dataSet.EnforceConstraints;
			base.Merge(dataSet, false, MissingSchemaAction.Add);
			this.InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void SchemaChanged(object sender, CollectionChangeEventArgs e)
		{
			if (e.Action == CollectionChangeAction.Remove)
			{
				this.InitVars();
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private bool ShouldSerializedolgozo()
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private bool ShouldSerializekilometer()
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private bool ShouldSerializeparameter()
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override bool ShouldSerializeRelations()
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override bool ShouldSerializeTables()
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private bool ShouldSerializeTK_View()
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private bool ShouldSerializetulora()
		{
			return false;
		}

		[Serializable]
		[XmlSchemaProvider("GetTypedTableSchema")]
		public class dolgozoDataTable : TypedTableBase<TKE.DataSet.dolgozoRow>
		{
			private DataColumn columnID;

			private DataColumn columnDOLGOZO_NEV;

			private DataColumn columnAZONOSITO;

			private DataColumn columnJELSZO;

			private DataColumn columnSZINT;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn AZONOSITOColumn
			{
				get
				{
					return this.columnAZONOSITO;
				}
			}

			[Browsable(false)]
			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int Count
			{
				get
				{
					return base.Rows.Count;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn DOLGOZO_NEVColumn
			{
				get
				{
					return this.columnDOLGOZO_NEV;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn IDColumn
			{
				get
				{
					return this.columnID;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.dolgozoRow this[int index]
			{
				get
				{
					return (TKE.DataSet.dolgozoRow)base.Rows[index];
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn JELSZOColumn
			{
				get
				{
					return this.columnJELSZO;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn SZINTColumn
			{
				get
				{
					return this.columnSZINT;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public dolgozoDataTable()
			{
				base.TableName = "dolgozo";
				this.BeginInit();
				this.InitClass();
				this.EndInit();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal dolgozoDataTable(DataTable table)
			{
				base.TableName = table.TableName;
				if (table.CaseSensitive != table.DataSet.CaseSensitive)
				{
					base.CaseSensitive = table.CaseSensitive;
				}
				if (table.Locale.ToString() != table.DataSet.Locale.ToString())
				{
					base.Locale = table.Locale;
				}
				if (table.Namespace != table.DataSet.Namespace)
				{
					base.Namespace = table.Namespace;
				}
				base.Prefix = table.Prefix;
				base.MinimumCapacity = table.MinimumCapacity;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected dolgozoDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
			{
				this.InitVars();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void AdddolgozoRow(TKE.DataSet.dolgozoRow row)
			{
				base.Rows.Add(row);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.dolgozoRow AdddolgozoRow(string DOLGOZO_NEV, string AZONOSITO, string JELSZO, string SZINT)
			{
				TKE.DataSet.dolgozoRow _dolgozoRow = (TKE.DataSet.dolgozoRow)base.NewRow();
				object[] dOLGOZONEV = new object[] { null, DOLGOZO_NEV, AZONOSITO, JELSZO, SZINT };
				_dolgozoRow.ItemArray = dOLGOZONEV;
				base.Rows.Add(_dolgozoRow);
				return _dolgozoRow;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public override DataTable Clone()
			{
				TKE.DataSet.dolgozoDataTable _dolgozoDataTable = (TKE.DataSet.dolgozoDataTable)base.Clone();
				_dolgozoDataTable.InitVars();
				return _dolgozoDataTable;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataTable CreateInstance()
			{
				return new TKE.DataSet.dolgozoDataTable();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.dolgozoRow FindByID(long ID)
			{
				DataRowCollection rows = base.Rows;
				object[] d = new object[] { ID };
				return (TKE.DataSet.dolgozoRow)rows.Find(d);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override Type GetRowType()
			{
				return typeof(TKE.DataSet.dolgozoRow);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
			{
				XmlSchemaComplexType xmlSchemaComplexType;
				XmlSchema xmlSchema;
				XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
				XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
				TKE.DataSet dataSet = new TKE.DataSet();
				XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
				{
					Namespace = "http://www.w3.org/2001/XMLSchema",
					MinOccurs = new decimal(0),
					MaxOccurs = new decimal(-1, -1, -1, false, 0),
					ProcessContents = XmlSchemaContentProcessing.Lax
				};
				xmlSchemaSequence.Items.Add(xmlSchemaAny);
				XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny()
				{
					Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
					MinOccurs = new decimal(1),
					ProcessContents = XmlSchemaContentProcessing.Lax
				};
				xmlSchemaSequence.Items.Add(xmlSchemaAny1);
				XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute()
				{
					Name = "namespace",
					FixedValue = dataSet.Namespace
				};
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
				XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
				{
					Name = "tableTypeName",
					FixedValue = "dolgozoDataTable"
				};
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
				xmlSchemaComplexType1.Particle = xmlSchemaSequence;
				XmlSchema schemaSerializable = dataSet.GetSchemaSerializable();
				if (xs.Contains(schemaSerializable.TargetNamespace))
				{
					MemoryStream memoryStream = new MemoryStream();
					MemoryStream memoryStream1 = new MemoryStream();
					try
					{
						XmlSchema current = null;
						schemaSerializable.Write(memoryStream);
						IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
						while (enumerator.MoveNext())
						{
							current = (XmlSchema)enumerator.Current;
							memoryStream1.SetLength((long)0);
							current.Write(memoryStream1);
							if (memoryStream.Length != memoryStream1.Length)
							{
								continue;
							}
							memoryStream.Position = (long)0;
							memoryStream1.Position = (long)0;
							while (memoryStream.Position != memoryStream.Length && memoryStream.ReadByte() == memoryStream1.ReadByte())
							{
							}
							if (memoryStream.Position != memoryStream.Length)
							{
								continue;
							}
							xmlSchemaComplexType = xmlSchemaComplexType1;
							return xmlSchemaComplexType;
						}
						xmlSchema = xs.Add(schemaSerializable);
						return xmlSchemaComplexType1;
					}
					finally
					{
						if (memoryStream != null)
						{
							memoryStream.Close();
						}
						if (memoryStream1 != null)
						{
							memoryStream1.Close();
						}
					}
					return xmlSchemaComplexType;
				}
				xmlSchema = xs.Add(schemaSerializable);
				return xmlSchemaComplexType1;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			private void InitClass()
			{
				this.columnID = new DataColumn("ID", typeof(long), null, MappingType.Element);
				base.Columns.Add(this.columnID);
				this.columnDOLGOZO_NEV = new DataColumn("DOLGOZO_NEV", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnDOLGOZO_NEV);
				this.columnAZONOSITO = new DataColumn("AZONOSITO", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnAZONOSITO);
				this.columnJELSZO = new DataColumn("JELSZO", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnJELSZO);
				this.columnSZINT = new DataColumn("SZINT", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnSZINT);
				ConstraintCollection constraints = base.Constraints;
				DataColumn[] dataColumnArray = new DataColumn[] { this.columnID };
				constraints.Add(new UniqueConstraint("Constraint1", dataColumnArray, true));
				this.columnID.AutoIncrement = true;
				this.columnID.AutoIncrementSeed = (long)-1;
				this.columnID.AutoIncrementStep = (long)-1;
				this.columnID.AllowDBNull = false;
				this.columnID.ReadOnly = true;
				this.columnID.Unique = true;
				this.columnDOLGOZO_NEV.AllowDBNull = false;
				this.columnDOLGOZO_NEV.MaxLength = 45;
				this.columnAZONOSITO.AllowDBNull = false;
				this.columnAZONOSITO.MaxLength = 10;
				this.columnJELSZO.AllowDBNull = false;
				this.columnJELSZO.MaxLength = 45;
				this.columnSZINT.AllowDBNull = false;
				this.columnSZINT.MaxLength = 1;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal void InitVars()
			{
				this.columnID = base.Columns["ID"];
				this.columnDOLGOZO_NEV = base.Columns["DOLGOZO_NEV"];
				this.columnAZONOSITO = base.Columns["AZONOSITO"];
				this.columnJELSZO = base.Columns["JELSZO"];
				this.columnSZINT = base.Columns["SZINT"];
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.dolgozoRow NewdolgozoRow()
			{
				return (TKE.DataSet.dolgozoRow)base.NewRow();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
			{
				return new TKE.DataSet.dolgozoRow(builder);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanged(DataRowChangeEventArgs e)
			{
				base.OnRowChanged(e);
				if (this.dolgozoRowChanged != null)
				{
					this.dolgozoRowChanged(this, new TKE.DataSet.dolgozoRowChangeEvent((TKE.DataSet.dolgozoRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanging(DataRowChangeEventArgs e)
			{
				base.OnRowChanging(e);
				if (this.dolgozoRowChanging != null)
				{
					this.dolgozoRowChanging(this, new TKE.DataSet.dolgozoRowChangeEvent((TKE.DataSet.dolgozoRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleted(DataRowChangeEventArgs e)
			{
				base.OnRowDeleted(e);
				if (this.dolgozoRowDeleted != null)
				{
					this.dolgozoRowDeleted(this, new TKE.DataSet.dolgozoRowChangeEvent((TKE.DataSet.dolgozoRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleting(DataRowChangeEventArgs e)
			{
				base.OnRowDeleting(e);
				if (this.dolgozoRowDeleting != null)
				{
					this.dolgozoRowDeleting(this, new TKE.DataSet.dolgozoRowChangeEvent((TKE.DataSet.dolgozoRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void RemovedolgozoRow(TKE.DataSet.dolgozoRow row)
			{
				base.Rows.Remove(row);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.dolgozoRowChangeEventHandler dolgozoRowChanged;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.dolgozoRowChangeEventHandler dolgozoRowChanging;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.dolgozoRowChangeEventHandler dolgozoRowDeleted;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.dolgozoRowChangeEventHandler dolgozoRowDeleting;
		}

		public class dolgozoRow : DataRow
		{
			private TKE.DataSet.dolgozoDataTable tabledolgozo;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string AZONOSITO
			{
				get
				{
					return (string)base[this.tabledolgozo.AZONOSITOColumn];
				}
				set
				{
					base[this.tabledolgozo.AZONOSITOColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string DOLGOZO_NEV
			{
				get
				{
					return (string)base[this.tabledolgozo.DOLGOZO_NEVColumn];
				}
				set
				{
					base[this.tabledolgozo.DOLGOZO_NEVColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public long ID
			{
				get
				{
					return (long)base[this.tabledolgozo.IDColumn];
				}
				set
				{
					base[this.tabledolgozo.IDColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string JELSZO
			{
				get
				{
					return (string)base[this.tabledolgozo.JELSZOColumn];
				}
				set
				{
					base[this.tabledolgozo.JELSZOColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string SZINT
			{
				get
				{
					return (string)base[this.tabledolgozo.SZINTColumn];
				}
				set
				{
					base[this.tabledolgozo.SZINTColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal dolgozoRow(DataRowBuilder rb) : base(rb)
			{
				this.tabledolgozo = (TKE.DataSet.dolgozoDataTable)base.Table;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public class dolgozoRowChangeEvent : EventArgs
		{
			private TKE.DataSet.dolgozoRow eventRow;

			private DataRowAction eventAction;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataRowAction Action
			{
				get
				{
					return this.eventAction;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.dolgozoRow Row
			{
				get
				{
					return this.eventRow;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public dolgozoRowChangeEvent(TKE.DataSet.dolgozoRow row, DataRowAction action)
			{
				this.eventRow = row;
				this.eventAction = action;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public delegate void dolgozoRowChangeEventHandler(object sender, TKE.DataSet.dolgozoRowChangeEvent e);

		[Serializable]
		[XmlSchemaProvider("GetTypedTableSchema")]
		public class kilometerDataTable : TypedTableBase<TKE.DataSet.kilometerRow>
		{
			private DataColumn columnID;

			private DataColumn columnDOLGOZO_ID;

			private DataColumn columnDATUM;

			private DataColumn columnHONNAN;

			private DataColumn columnHOVA;

			private DataColumn columnKM;

			private DataColumn columnSZOVEG;

			private DataColumn columnSZORZO;

			[Browsable(false)]
			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int Count
			{
				get
				{
					return base.Rows.Count;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn DATUMColumn
			{
				get
				{
					return this.columnDATUM;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn DOLGOZO_IDColumn
			{
				get
				{
					return this.columnDOLGOZO_ID;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn HONNANColumn
			{
				get
				{
					return this.columnHONNAN;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn HOVAColumn
			{
				get
				{
					return this.columnHOVA;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn IDColumn
			{
				get
				{
					return this.columnID;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.kilometerRow this[int index]
			{
				get
				{
					return (TKE.DataSet.kilometerRow)base.Rows[index];
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn KMColumn
			{
				get
				{
					return this.columnKM;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn SZORZOColumn
			{
				get
				{
					return this.columnSZORZO;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn SZOVEGColumn
			{
				get
				{
					return this.columnSZOVEG;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public kilometerDataTable()
			{
				base.TableName = "kilometer";
				this.BeginInit();
				this.InitClass();
				this.EndInit();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal kilometerDataTable(DataTable table)
			{
				base.TableName = table.TableName;
				if (table.CaseSensitive != table.DataSet.CaseSensitive)
				{
					base.CaseSensitive = table.CaseSensitive;
				}
				if (table.Locale.ToString() != table.DataSet.Locale.ToString())
				{
					base.Locale = table.Locale;
				}
				if (table.Namespace != table.DataSet.Namespace)
				{
					base.Namespace = table.Namespace;
				}
				base.Prefix = table.Prefix;
				base.MinimumCapacity = table.MinimumCapacity;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected kilometerDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
			{
				this.InitVars();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void AddkilometerRow(TKE.DataSet.kilometerRow row)
			{
				base.Rows.Add(row);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.kilometerRow AddkilometerRow(long DOLGOZO_ID, DateTime DATUM, string HONNAN, string HOVA, decimal KM, string SZOVEG, int SZORZO)
			{
				TKE.DataSet.kilometerRow _kilometerRow = (TKE.DataSet.kilometerRow)base.NewRow();
				object[] dOLGOZOID = new object[] { null, DOLGOZO_ID, DATUM, HONNAN, HOVA, KM, SZOVEG, SZORZO };
				_kilometerRow.ItemArray = dOLGOZOID;
				base.Rows.Add(_kilometerRow);
				return _kilometerRow;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public override DataTable Clone()
			{
				TKE.DataSet.kilometerDataTable _kilometerDataTable = (TKE.DataSet.kilometerDataTable)base.Clone();
				_kilometerDataTable.InitVars();
				return _kilometerDataTable;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataTable CreateInstance()
			{
				return new TKE.DataSet.kilometerDataTable();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.kilometerRow FindByID(long ID)
			{
				DataRowCollection rows = base.Rows;
				object[] d = new object[] { ID };
				return (TKE.DataSet.kilometerRow)rows.Find(d);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override Type GetRowType()
			{
				return typeof(TKE.DataSet.kilometerRow);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
			{
				XmlSchemaComplexType xmlSchemaComplexType;
				XmlSchema xmlSchema;
				XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
				XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
				TKE.DataSet dataSet = new TKE.DataSet();
				XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
				{
					Namespace = "http://www.w3.org/2001/XMLSchema",
					MinOccurs = new decimal(0),
					MaxOccurs = new decimal(-1, -1, -1, false, 0),
					ProcessContents = XmlSchemaContentProcessing.Lax
				};
				xmlSchemaSequence.Items.Add(xmlSchemaAny);
				XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny()
				{
					Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
					MinOccurs = new decimal(1),
					ProcessContents = XmlSchemaContentProcessing.Lax
				};
				xmlSchemaSequence.Items.Add(xmlSchemaAny1);
				XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute()
				{
					Name = "namespace",
					FixedValue = dataSet.Namespace
				};
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
				XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
				{
					Name = "tableTypeName",
					FixedValue = "kilometerDataTable"
				};
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
				xmlSchemaComplexType1.Particle = xmlSchemaSequence;
				XmlSchema schemaSerializable = dataSet.GetSchemaSerializable();
				if (xs.Contains(schemaSerializable.TargetNamespace))
				{
					MemoryStream memoryStream = new MemoryStream();
					MemoryStream memoryStream1 = new MemoryStream();
					try
					{
						XmlSchema current = null;
						schemaSerializable.Write(memoryStream);
						IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
						while (enumerator.MoveNext())
						{
							current = (XmlSchema)enumerator.Current;
							memoryStream1.SetLength((long)0);
							current.Write(memoryStream1);
							if (memoryStream.Length != memoryStream1.Length)
							{
								continue;
							}
							memoryStream.Position = (long)0;
							memoryStream1.Position = (long)0;
							while (memoryStream.Position != memoryStream.Length && memoryStream.ReadByte() == memoryStream1.ReadByte())
							{
							}
							if (memoryStream.Position != memoryStream.Length)
							{
								continue;
							}
							xmlSchemaComplexType = xmlSchemaComplexType1;
							return xmlSchemaComplexType;
						}
						xmlSchema = xs.Add(schemaSerializable);
						return xmlSchemaComplexType1;
					}
					finally
					{
						if (memoryStream != null)
						{
							memoryStream.Close();
						}
						if (memoryStream1 != null)
						{
							memoryStream1.Close();
						}
					}
					return xmlSchemaComplexType;
				}
				xmlSchema = xs.Add(schemaSerializable);
				return xmlSchemaComplexType1;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			private void InitClass()
			{
				this.columnID = new DataColumn("ID", typeof(long), null, MappingType.Element);
				base.Columns.Add(this.columnID);
				this.columnDOLGOZO_ID = new DataColumn("DOLGOZO_ID", typeof(long), null, MappingType.Element);
				base.Columns.Add(this.columnDOLGOZO_ID);
				this.columnDATUM = new DataColumn("DATUM", typeof(DateTime), null, MappingType.Element);
				base.Columns.Add(this.columnDATUM);
				this.columnHONNAN = new DataColumn("HONNAN", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnHONNAN);
				this.columnHOVA = new DataColumn("HOVA", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnHOVA);
				this.columnKM = new DataColumn("KM", typeof(decimal), null, MappingType.Element);
				base.Columns.Add(this.columnKM);
				this.columnSZOVEG = new DataColumn("SZOVEG", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnSZOVEG);
				this.columnSZORZO = new DataColumn("SZORZO", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.columnSZORZO);
				ConstraintCollection constraints = base.Constraints;
				DataColumn[] dataColumnArray = new DataColumn[] { this.columnID };
				constraints.Add(new UniqueConstraint("Constraint1", dataColumnArray, true));
				this.columnID.AutoIncrement = true;
				this.columnID.AutoIncrementSeed = (long)-1;
				this.columnID.AutoIncrementStep = (long)-1;
				this.columnID.AllowDBNull = false;
				this.columnID.ReadOnly = true;
				this.columnID.Unique = true;
				this.columnDOLGOZO_ID.AllowDBNull = false;
				this.columnDATUM.AllowDBNull = false;
				this.columnHONNAN.MaxLength = 50;
				this.columnHOVA.MaxLength = 50;
				this.columnKM.AllowDBNull = false;
				this.columnSZOVEG.MaxLength = 50;
				this.columnSZORZO.AllowDBNull = false;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal void InitVars()
			{
				this.columnID = base.Columns["ID"];
				this.columnDOLGOZO_ID = base.Columns["DOLGOZO_ID"];
				this.columnDATUM = base.Columns["DATUM"];
				this.columnHONNAN = base.Columns["HONNAN"];
				this.columnHOVA = base.Columns["HOVA"];
				this.columnKM = base.Columns["KM"];
				this.columnSZOVEG = base.Columns["SZOVEG"];
				this.columnSZORZO = base.Columns["SZORZO"];
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.kilometerRow NewkilometerRow()
			{
				return (TKE.DataSet.kilometerRow)base.NewRow();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
			{
				return new TKE.DataSet.kilometerRow(builder);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanged(DataRowChangeEventArgs e)
			{
				base.OnRowChanged(e);
				if (this.kilometerRowChanged != null)
				{
					this.kilometerRowChanged(this, new TKE.DataSet.kilometerRowChangeEvent((TKE.DataSet.kilometerRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanging(DataRowChangeEventArgs e)
			{
				base.OnRowChanging(e);
				if (this.kilometerRowChanging != null)
				{
					this.kilometerRowChanging(this, new TKE.DataSet.kilometerRowChangeEvent((TKE.DataSet.kilometerRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleted(DataRowChangeEventArgs e)
			{
				base.OnRowDeleted(e);
				if (this.kilometerRowDeleted != null)
				{
					this.kilometerRowDeleted(this, new TKE.DataSet.kilometerRowChangeEvent((TKE.DataSet.kilometerRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleting(DataRowChangeEventArgs e)
			{
				base.OnRowDeleting(e);
				if (this.kilometerRowDeleting != null)
				{
					this.kilometerRowDeleting(this, new TKE.DataSet.kilometerRowChangeEvent((TKE.DataSet.kilometerRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void RemovekilometerRow(TKE.DataSet.kilometerRow row)
			{
				base.Rows.Remove(row);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.kilometerRowChangeEventHandler kilometerRowChanged;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.kilometerRowChangeEventHandler kilometerRowChanging;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.kilometerRowChangeEventHandler kilometerRowDeleted;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.kilometerRowChangeEventHandler kilometerRowDeleting;
		}

		public class kilometerRow : DataRow
		{
			private TKE.DataSet.kilometerDataTable tablekilometer;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DateTime DATUM
			{
				get
				{
					return (DateTime)base[this.tablekilometer.DATUMColumn];
				}
				set
				{
					base[this.tablekilometer.DATUMColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public long DOLGOZO_ID
			{
				get
				{
					return (long)base[this.tablekilometer.DOLGOZO_IDColumn];
				}
				set
				{
					base[this.tablekilometer.DOLGOZO_IDColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string HONNAN
			{
				get
				{
					string item;
					try
					{
						item = (string)base[this.tablekilometer.HONNANColumn];
					}
					catch (InvalidCastException invalidCastException)
					{
						throw new StrongTypingException("The value for column 'HONNAN' in table 'kilometer' is DBNull.", invalidCastException);
					}
					return item;
				}
				set
				{
					base[this.tablekilometer.HONNANColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string HOVA
			{
				get
				{
					string item;
					try
					{
						item = (string)base[this.tablekilometer.HOVAColumn];
					}
					catch (InvalidCastException invalidCastException)
					{
						throw new StrongTypingException("The value for column 'HOVA' in table 'kilometer' is DBNull.", invalidCastException);
					}
					return item;
				}
				set
				{
					base[this.tablekilometer.HOVAColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public long ID
			{
				get
				{
					return (long)base[this.tablekilometer.IDColumn];
				}
				set
				{
					base[this.tablekilometer.IDColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public decimal KM
			{
				get
				{
					return (decimal)base[this.tablekilometer.KMColumn];
				}
				set
				{
					base[this.tablekilometer.KMColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int SZORZO
			{
				get
				{
					return (int)base[this.tablekilometer.SZORZOColumn];
				}
				set
				{
					base[this.tablekilometer.SZORZOColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string SZOVEG
			{
				get
				{
					string item;
					try
					{
						item = (string)base[this.tablekilometer.SZOVEGColumn];
					}
					catch (InvalidCastException invalidCastException)
					{
						throw new StrongTypingException("The value for column 'SZOVEG' in table 'kilometer' is DBNull.", invalidCastException);
					}
					return item;
				}
				set
				{
					base[this.tablekilometer.SZOVEGColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal kilometerRow(DataRowBuilder rb) : base(rb)
			{
				this.tablekilometer = (TKE.DataSet.kilometerDataTable)base.Table;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsHONNANNull()
			{
				return base.IsNull(this.tablekilometer.HONNANColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsHOVANull()
			{
				return base.IsNull(this.tablekilometer.HOVAColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsSZOVEGNull()
			{
				return base.IsNull(this.tablekilometer.SZOVEGColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetHONNANNull()
			{
				base[this.tablekilometer.HONNANColumn] = Convert.DBNull;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetHOVANull()
			{
				base[this.tablekilometer.HOVAColumn] = Convert.DBNull;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetSZOVEGNull()
			{
				base[this.tablekilometer.SZOVEGColumn] = Convert.DBNull;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public class kilometerRowChangeEvent : EventArgs
		{
			private TKE.DataSet.kilometerRow eventRow;

			private DataRowAction eventAction;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataRowAction Action
			{
				get
				{
					return this.eventAction;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.kilometerRow Row
			{
				get
				{
					return this.eventRow;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public kilometerRowChangeEvent(TKE.DataSet.kilometerRow row, DataRowAction action)
			{
				this.eventRow = row;
				this.eventAction = action;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public delegate void kilometerRowChangeEventHandler(object sender, TKE.DataSet.kilometerRowChangeEvent e);

		[Serializable]
		[XmlSchemaProvider("GetTypedTableSchema")]
		public class parameterDataTable : TypedTableBase<TKE.DataSet.parameterRow>
		{
			private DataColumn columnID;

			private DataColumn columnNEV;

			private DataColumn columnERTEK;

			[Browsable(false)]
			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int Count
			{
				get
				{
					return base.Rows.Count;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn ERTEKColumn
			{
				get
				{
					return this.columnERTEK;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn IDColumn
			{
				get
				{
					return this.columnID;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.parameterRow this[int index]
			{
				get
				{
					return (TKE.DataSet.parameterRow)base.Rows[index];
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn NEVColumn
			{
				get
				{
					return this.columnNEV;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public parameterDataTable()
			{
				base.TableName = "parameter";
				this.BeginInit();
				this.InitClass();
				this.EndInit();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal parameterDataTable(DataTable table)
			{
				base.TableName = table.TableName;
				if (table.CaseSensitive != table.DataSet.CaseSensitive)
				{
					base.CaseSensitive = table.CaseSensitive;
				}
				if (table.Locale.ToString() != table.DataSet.Locale.ToString())
				{
					base.Locale = table.Locale;
				}
				if (table.Namespace != table.DataSet.Namespace)
				{
					base.Namespace = table.Namespace;
				}
				base.Prefix = table.Prefix;
				base.MinimumCapacity = table.MinimumCapacity;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected parameterDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
			{
				this.InitVars();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void AddparameterRow(TKE.DataSet.parameterRow row)
			{
				base.Rows.Add(row);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.parameterRow AddparameterRow(string NEV, string ERTEK)
			{
				TKE.DataSet.parameterRow nEV = (TKE.DataSet.parameterRow)base.NewRow();
				nEV.ItemArray = new object[] { null, NEV, ERTEK };
				base.Rows.Add(nEV);
				return nEV;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public override DataTable Clone()
			{
				TKE.DataSet.parameterDataTable _parameterDataTable = (TKE.DataSet.parameterDataTable)base.Clone();
				_parameterDataTable.InitVars();
				return _parameterDataTable;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataTable CreateInstance()
			{
				return new TKE.DataSet.parameterDataTable();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.parameterRow FindByID(long ID)
			{
				DataRowCollection rows = base.Rows;
				object[] d = new object[] { ID };
				return (TKE.DataSet.parameterRow)rows.Find(d);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override Type GetRowType()
			{
				return typeof(TKE.DataSet.parameterRow);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
			{
				XmlSchemaComplexType xmlSchemaComplexType;
				XmlSchema xmlSchema;
				XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
				XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
				TKE.DataSet dataSet = new TKE.DataSet();
				XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
				{
					Namespace = "http://www.w3.org/2001/XMLSchema",
					MinOccurs = new decimal(0),
					MaxOccurs = new decimal(-1, -1, -1, false, 0),
					ProcessContents = XmlSchemaContentProcessing.Lax
				};
				xmlSchemaSequence.Items.Add(xmlSchemaAny);
				XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny()
				{
					Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
					MinOccurs = new decimal(1),
					ProcessContents = XmlSchemaContentProcessing.Lax
				};
				xmlSchemaSequence.Items.Add(xmlSchemaAny1);
				XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute()
				{
					Name = "namespace",
					FixedValue = dataSet.Namespace
				};
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
				XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
				{
					Name = "tableTypeName",
					FixedValue = "parameterDataTable"
				};
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
				xmlSchemaComplexType1.Particle = xmlSchemaSequence;
				XmlSchema schemaSerializable = dataSet.GetSchemaSerializable();
				if (xs.Contains(schemaSerializable.TargetNamespace))
				{
					MemoryStream memoryStream = new MemoryStream();
					MemoryStream memoryStream1 = new MemoryStream();
					try
					{
						XmlSchema current = null;
						schemaSerializable.Write(memoryStream);
						IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
						while (enumerator.MoveNext())
						{
							current = (XmlSchema)enumerator.Current;
							memoryStream1.SetLength((long)0);
							current.Write(memoryStream1);
							if (memoryStream.Length != memoryStream1.Length)
							{
								continue;
							}
							memoryStream.Position = (long)0;
							memoryStream1.Position = (long)0;
							while (memoryStream.Position != memoryStream.Length && memoryStream.ReadByte() == memoryStream1.ReadByte())
							{
							}
							if (memoryStream.Position != memoryStream.Length)
							{
								continue;
							}
							xmlSchemaComplexType = xmlSchemaComplexType1;
							return xmlSchemaComplexType;
						}
						xmlSchema = xs.Add(schemaSerializable);
						return xmlSchemaComplexType1;
					}
					finally
					{
						if (memoryStream != null)
						{
							memoryStream.Close();
						}
						if (memoryStream1 != null)
						{
							memoryStream1.Close();
						}
					}
					return xmlSchemaComplexType;
				}
				xmlSchema = xs.Add(schemaSerializable);
				return xmlSchemaComplexType1;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			private void InitClass()
			{
				this.columnID = new DataColumn("ID", typeof(long), null, MappingType.Element);
				base.Columns.Add(this.columnID);
				this.columnNEV = new DataColumn("NEV", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnNEV);
				this.columnERTEK = new DataColumn("ERTEK", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnERTEK);
				ConstraintCollection constraints = base.Constraints;
				DataColumn[] dataColumnArray = new DataColumn[] { this.columnID };
				constraints.Add(new UniqueConstraint("Constraint1", dataColumnArray, true));
				this.columnID.AutoIncrement = true;
				this.columnID.AutoIncrementSeed = (long)-1;
				this.columnID.AutoIncrementStep = (long)-1;
				this.columnID.AllowDBNull = false;
				this.columnID.ReadOnly = true;
				this.columnID.Unique = true;
				this.columnNEV.AllowDBNull = false;
				this.columnNEV.MaxLength = 20;
				this.columnERTEK.AllowDBNull = false;
				this.columnERTEK.MaxLength = 50;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal void InitVars()
			{
				this.columnID = base.Columns["ID"];
				this.columnNEV = base.Columns["NEV"];
				this.columnERTEK = base.Columns["ERTEK"];
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.parameterRow NewparameterRow()
			{
				return (TKE.DataSet.parameterRow)base.NewRow();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
			{
				return new TKE.DataSet.parameterRow(builder);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanged(DataRowChangeEventArgs e)
			{
				base.OnRowChanged(e);
				if (this.parameterRowChanged != null)
				{
					this.parameterRowChanged(this, new TKE.DataSet.parameterRowChangeEvent((TKE.DataSet.parameterRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanging(DataRowChangeEventArgs e)
			{
				base.OnRowChanging(e);
				if (this.parameterRowChanging != null)
				{
					this.parameterRowChanging(this, new TKE.DataSet.parameterRowChangeEvent((TKE.DataSet.parameterRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleted(DataRowChangeEventArgs e)
			{
				base.OnRowDeleted(e);
				if (this.parameterRowDeleted != null)
				{
					this.parameterRowDeleted(this, new TKE.DataSet.parameterRowChangeEvent((TKE.DataSet.parameterRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleting(DataRowChangeEventArgs e)
			{
				base.OnRowDeleting(e);
				if (this.parameterRowDeleting != null)
				{
					this.parameterRowDeleting(this, new TKE.DataSet.parameterRowChangeEvent((TKE.DataSet.parameterRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void RemoveparameterRow(TKE.DataSet.parameterRow row)
			{
				base.Rows.Remove(row);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.parameterRowChangeEventHandler parameterRowChanged;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.parameterRowChangeEventHandler parameterRowChanging;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.parameterRowChangeEventHandler parameterRowDeleted;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.parameterRowChangeEventHandler parameterRowDeleting;
		}

		public class parameterRow : DataRow
		{
			private TKE.DataSet.parameterDataTable tableparameter;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string ERTEK
			{
				get
				{
					return (string)base[this.tableparameter.ERTEKColumn];
				}
				set
				{
					base[this.tableparameter.ERTEKColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public long ID
			{
				get
				{
					return (long)base[this.tableparameter.IDColumn];
				}
				set
				{
					base[this.tableparameter.IDColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string NEV
			{
				get
				{
					return (string)base[this.tableparameter.NEVColumn];
				}
				set
				{
					base[this.tableparameter.NEVColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal parameterRow(DataRowBuilder rb) : base(rb)
			{
				this.tableparameter = (TKE.DataSet.parameterDataTable)base.Table;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public class parameterRowChangeEvent : EventArgs
		{
			private TKE.DataSet.parameterRow eventRow;

			private DataRowAction eventAction;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataRowAction Action
			{
				get
				{
					return this.eventAction;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.parameterRow Row
			{
				get
				{
					return this.eventRow;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public parameterRowChangeEvent(TKE.DataSet.parameterRow row, DataRowAction action)
			{
				this.eventRow = row;
				this.eventAction = action;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public delegate void parameterRowChangeEventHandler(object sender, TKE.DataSet.parameterRowChangeEvent e);

		[Serializable]
		[XmlSchemaProvider("GetTypedTableSchema")]
		public class TK_ViewDataTable : TypedTableBase<TKE.DataSet.TK_ViewRow>
		{
			private DataColumn columnDOLGOZO_NEV;

			private DataColumn columnDATUM;

			private DataColumn columnTK;

			private DataColumn columnTulora;

			private DataColumn columnKilometer;

			private DataColumn columnSZORZO;

			private DataColumn columnTFT;

			private DataColumn columnKFT;

			private DataColumn columnSZOVEG;

			private DataColumn columnHONNAN;

			private DataColumn columnHOVA;

			[Browsable(false)]
			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int Count
			{
				get
				{
					return base.Rows.Count;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn DATUMColumn
			{
				get
				{
					return this.columnDATUM;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn DOLGOZO_NEVColumn
			{
				get
				{
					return this.columnDOLGOZO_NEV;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn HONNANColumn
			{
				get
				{
					return this.columnHONNAN;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn HOVAColumn
			{
				get
				{
					return this.columnHOVA;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.TK_ViewRow this[int index]
			{
				get
				{
					return (TKE.DataSet.TK_ViewRow)base.Rows[index];
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn KFTColumn
			{
				get
				{
					return this.columnKFT;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn KilometerColumn
			{
				get
				{
					return this.columnKilometer;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn SZORZOColumn
			{
				get
				{
					return this.columnSZORZO;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn SZOVEGColumn
			{
				get
				{
					return this.columnSZOVEG;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn TFTColumn
			{
				get
				{
					return this.columnTFT;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn TKColumn
			{
				get
				{
					return this.columnTK;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn TuloraColumn
			{
				get
				{
					return this.columnTulora;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TK_ViewDataTable()
			{
				base.TableName = "TK_View";
				this.BeginInit();
				this.InitClass();
				this.EndInit();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal TK_ViewDataTable(DataTable table)
			{
				base.TableName = table.TableName;
				if (table.CaseSensitive != table.DataSet.CaseSensitive)
				{
					base.CaseSensitive = table.CaseSensitive;
				}
				if (table.Locale.ToString() != table.DataSet.Locale.ToString())
				{
					base.Locale = table.Locale;
				}
				if (table.Namespace != table.DataSet.Namespace)
				{
					base.Namespace = table.Namespace;
				}
				base.Prefix = table.Prefix;
				base.MinimumCapacity = table.MinimumCapacity;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected TK_ViewDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
			{
				this.InitVars();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void AddTK_ViewRow(TKE.DataSet.TK_ViewRow row)
			{
				base.Rows.Add(row);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.TK_ViewRow AddTK_ViewRow(string DOLGOZO_NEV, DateTime DATUM, string TK, decimal Tulora, decimal Kilometer, int SZORZO, decimal TFT, decimal KFT, string SZOVEG, string HONNAN, string HOVA)
			{
				TKE.DataSet.TK_ViewRow tKViewRow = (TKE.DataSet.TK_ViewRow)base.NewRow();
				object[] dOLGOZONEV = new object[] { DOLGOZO_NEV, DATUM, TK, Tulora, Kilometer, SZORZO, TFT, KFT, SZOVEG, HONNAN, HOVA };
				tKViewRow.ItemArray = dOLGOZONEV;
				base.Rows.Add(tKViewRow);
				return tKViewRow;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public override DataTable Clone()
			{
				TKE.DataSet.TK_ViewDataTable tKViewDataTable = (TKE.DataSet.TK_ViewDataTable)base.Clone();
				tKViewDataTable.InitVars();
				return tKViewDataTable;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataTable CreateInstance()
			{
				return new TKE.DataSet.TK_ViewDataTable();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override Type GetRowType()
			{
				return typeof(TKE.DataSet.TK_ViewRow);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
			{
				XmlSchemaComplexType xmlSchemaComplexType;
				XmlSchema xmlSchema;
				XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
				XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
				TKE.DataSet dataSet = new TKE.DataSet();
				XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
				{
					Namespace = "http://www.w3.org/2001/XMLSchema",
					MinOccurs = new decimal(0),
					MaxOccurs = new decimal(-1, -1, -1, false, 0),
					ProcessContents = XmlSchemaContentProcessing.Lax
				};
				xmlSchemaSequence.Items.Add(xmlSchemaAny);
				XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny()
				{
					Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
					MinOccurs = new decimal(1),
					ProcessContents = XmlSchemaContentProcessing.Lax
				};
				xmlSchemaSequence.Items.Add(xmlSchemaAny1);
				XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute()
				{
					Name = "namespace",
					FixedValue = dataSet.Namespace
				};
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
				XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
				{
					Name = "tableTypeName",
					FixedValue = "TK_ViewDataTable"
				};
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
				xmlSchemaComplexType1.Particle = xmlSchemaSequence;
				XmlSchema schemaSerializable = dataSet.GetSchemaSerializable();
				if (xs.Contains(schemaSerializable.TargetNamespace))
				{
					MemoryStream memoryStream = new MemoryStream();
					MemoryStream memoryStream1 = new MemoryStream();
					try
					{
						XmlSchema current = null;
						schemaSerializable.Write(memoryStream);
						IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
						while (enumerator.MoveNext())
						{
							current = (XmlSchema)enumerator.Current;
							memoryStream1.SetLength((long)0);
							current.Write(memoryStream1);
							if (memoryStream.Length != memoryStream1.Length)
							{
								continue;
							}
							memoryStream.Position = (long)0;
							memoryStream1.Position = (long)0;
							while (memoryStream.Position != memoryStream.Length && memoryStream.ReadByte() == memoryStream1.ReadByte())
							{
							}
							if (memoryStream.Position != memoryStream.Length)
							{
								continue;
							}
							xmlSchemaComplexType = xmlSchemaComplexType1;
							return xmlSchemaComplexType;
						}
						xmlSchema = xs.Add(schemaSerializable);
						return xmlSchemaComplexType1;
					}
					finally
					{
						if (memoryStream != null)
						{
							memoryStream.Close();
						}
						if (memoryStream1 != null)
						{
							memoryStream1.Close();
						}
					}
					return xmlSchemaComplexType;
				}
				xmlSchema = xs.Add(schemaSerializable);
				return xmlSchemaComplexType1;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			private void InitClass()
			{
				this.columnDOLGOZO_NEV = new DataColumn("DOLGOZO_NEV", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnDOLGOZO_NEV);
				this.columnDATUM = new DataColumn("DATUM", typeof(DateTime), null, MappingType.Element);
				base.Columns.Add(this.columnDATUM);
				this.columnTK = new DataColumn("TK", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnTK);
				this.columnTulora = new DataColumn("Tulora", typeof(decimal), null, MappingType.Element);
				base.Columns.Add(this.columnTulora);
				this.columnKilometer = new DataColumn("Kilometer", typeof(decimal), null, MappingType.Element);
				base.Columns.Add(this.columnKilometer);
				this.columnSZORZO = new DataColumn("SZORZO", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.columnSZORZO);
				this.columnTFT = new DataColumn("TFT", typeof(decimal), null, MappingType.Element);
				base.Columns.Add(this.columnTFT);
				this.columnKFT = new DataColumn("KFT", typeof(decimal), null, MappingType.Element);
				base.Columns.Add(this.columnKFT);
				this.columnSZOVEG = new DataColumn("SZOVEG", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnSZOVEG);
				this.columnHONNAN = new DataColumn("HONNAN", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnHONNAN);
				this.columnHOVA = new DataColumn("HOVA", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnHOVA);
				this.columnDOLGOZO_NEV.AllowDBNull = false;
				this.columnDOLGOZO_NEV.MaxLength = 45;
				this.columnDATUM.AllowDBNull = false;
				this.columnTK.AllowDBNull = false;
				this.columnTK.MaxLength = 1;
				this.columnTulora.AllowDBNull = false;
				this.columnTulora.ReadOnly = true;
				this.columnKilometer.AllowDBNull = false;
				this.columnKilometer.ReadOnly = true;
				this.columnSZORZO.AllowDBNull = false;
				this.columnSZOVEG.MaxLength = 50;
				this.columnHONNAN.MaxLength = 50;
				this.columnHOVA.MaxLength = 50;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal void InitVars()
			{
				this.columnDOLGOZO_NEV = base.Columns["DOLGOZO_NEV"];
				this.columnDATUM = base.Columns["DATUM"];
				this.columnTK = base.Columns["TK"];
				this.columnTulora = base.Columns["Tulora"];
				this.columnKilometer = base.Columns["Kilometer"];
				this.columnSZORZO = base.Columns["SZORZO"];
				this.columnTFT = base.Columns["TFT"];
				this.columnKFT = base.Columns["KFT"];
				this.columnSZOVEG = base.Columns["SZOVEG"];
				this.columnHONNAN = base.Columns["HONNAN"];
				this.columnHOVA = base.Columns["HOVA"];
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
			{
				return new TKE.DataSet.TK_ViewRow(builder);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.TK_ViewRow NewTK_ViewRow()
			{
				return (TKE.DataSet.TK_ViewRow)base.NewRow();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanged(DataRowChangeEventArgs e)
			{
				base.OnRowChanged(e);
				if (this.TK_ViewRowChanged != null)
				{
					this.TK_ViewRowChanged(this, new TKE.DataSet.TK_ViewRowChangeEvent((TKE.DataSet.TK_ViewRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanging(DataRowChangeEventArgs e)
			{
				base.OnRowChanging(e);
				if (this.TK_ViewRowChanging != null)
				{
					this.TK_ViewRowChanging(this, new TKE.DataSet.TK_ViewRowChangeEvent((TKE.DataSet.TK_ViewRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleted(DataRowChangeEventArgs e)
			{
				base.OnRowDeleted(e);
				if (this.TK_ViewRowDeleted != null)
				{
					this.TK_ViewRowDeleted(this, new TKE.DataSet.TK_ViewRowChangeEvent((TKE.DataSet.TK_ViewRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleting(DataRowChangeEventArgs e)
			{
				base.OnRowDeleting(e);
				if (this.TK_ViewRowDeleting != null)
				{
					this.TK_ViewRowDeleting(this, new TKE.DataSet.TK_ViewRowChangeEvent((TKE.DataSet.TK_ViewRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void RemoveTK_ViewRow(TKE.DataSet.TK_ViewRow row)
			{
				base.Rows.Remove(row);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.TK_ViewRowChangeEventHandler TK_ViewRowChanged;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.TK_ViewRowChangeEventHandler TK_ViewRowChanging;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.TK_ViewRowChangeEventHandler TK_ViewRowDeleted;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.TK_ViewRowChangeEventHandler TK_ViewRowDeleting;
		}

		public class TK_ViewRow : DataRow
		{
			private TKE.DataSet.TK_ViewDataTable tableTK_View;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DateTime DATUM
			{
				get
				{
					return (DateTime)base[this.tableTK_View.DATUMColumn];
				}
				set
				{
					base[this.tableTK_View.DATUMColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string DOLGOZO_NEV
			{
				get
				{
					return (string)base[this.tableTK_View.DOLGOZO_NEVColumn];
				}
				set
				{
					base[this.tableTK_View.DOLGOZO_NEVColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string HONNAN
			{
				get
				{
					string item;
					try
					{
						item = (string)base[this.tableTK_View.HONNANColumn];
					}
					catch (InvalidCastException invalidCastException)
					{
						throw new StrongTypingException("The value for column 'HONNAN' in table 'TK_View' is DBNull.", invalidCastException);
					}
					return item;
				}
				set
				{
					base[this.tableTK_View.HONNANColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string HOVA
			{
				get
				{
					string item;
					try
					{
						item = (string)base[this.tableTK_View.HOVAColumn];
					}
					catch (InvalidCastException invalidCastException)
					{
						throw new StrongTypingException("The value for column 'HOVA' in table 'TK_View' is DBNull.", invalidCastException);
					}
					return item;
				}
				set
				{
					base[this.tableTK_View.HOVAColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public decimal KFT
			{
				get
				{
					decimal item;
					try
					{
						item = (decimal)base[this.tableTK_View.KFTColumn];
					}
					catch (InvalidCastException invalidCastException)
					{
						throw new StrongTypingException("The value for column 'KFT' in table 'TK_View' is DBNull.", invalidCastException);
					}
					return item;
				}
				set
				{
					base[this.tableTK_View.KFTColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public decimal Kilometer
			{
				get
				{
					return (decimal)base[this.tableTK_View.KilometerColumn];
				}
				set
				{
					base[this.tableTK_View.KilometerColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int SZORZO
			{
				get
				{
					return (int)base[this.tableTK_View.SZORZOColumn];
				}
				set
				{
					base[this.tableTK_View.SZORZOColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string SZOVEG
			{
				get
				{
					string item;
					try
					{
						item = (string)base[this.tableTK_View.SZOVEGColumn];
					}
					catch (InvalidCastException invalidCastException)
					{
						throw new StrongTypingException("The value for column 'SZOVEG' in table 'TK_View' is DBNull.", invalidCastException);
					}
					return item;
				}
				set
				{
					base[this.tableTK_View.SZOVEGColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public decimal TFT
			{
				get
				{
					decimal item;
					try
					{
						item = (decimal)base[this.tableTK_View.TFTColumn];
					}
					catch (InvalidCastException invalidCastException)
					{
						throw new StrongTypingException("The value for column 'TFT' in table 'TK_View' is DBNull.", invalidCastException);
					}
					return item;
				}
				set
				{
					base[this.tableTK_View.TFTColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string TK
			{
				get
				{
					return (string)base[this.tableTK_View.TKColumn];
				}
				set
				{
					base[this.tableTK_View.TKColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public decimal Tulora
			{
				get
				{
					return (decimal)base[this.tableTK_View.TuloraColumn];
				}
				set
				{
					base[this.tableTK_View.TuloraColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal TK_ViewRow(DataRowBuilder rb) : base(rb)
			{
				this.tableTK_View = (TKE.DataSet.TK_ViewDataTable)base.Table;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsHONNANNull()
			{
				return base.IsNull(this.tableTK_View.HONNANColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsHOVANull()
			{
				return base.IsNull(this.tableTK_View.HOVAColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsKFTNull()
			{
				return base.IsNull(this.tableTK_View.KFTColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsTFTNull()
			{
				return base.IsNull(this.tableTK_View.TFTColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsSZOVEGNull()
			{
				return base.IsNull(this.tableTK_View.SZOVEGColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetHONNANNull()
			{
				base[this.tableTK_View.HONNANColumn] = Convert.DBNull;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetHOVANull()
			{
				base[this.tableTK_View.HOVAColumn] = Convert.DBNull;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetKFTNull()
			{
				base[this.tableTK_View.KFTColumn] = Convert.DBNull;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetSZOVEGNull()
			{
				base[this.tableTK_View.SZOVEGColumn] = Convert.DBNull;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetTFTNull()
			{
				base[this.tableTK_View.TFTColumn] = Convert.DBNull;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public class TK_ViewRowChangeEvent : EventArgs
		{
			private TKE.DataSet.TK_ViewRow eventRow;

			private DataRowAction eventAction;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataRowAction Action
			{
				get
				{
					return this.eventAction;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.TK_ViewRow Row
			{
				get
				{
					return this.eventRow;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TK_ViewRowChangeEvent(TKE.DataSet.TK_ViewRow row, DataRowAction action)
			{
				this.eventRow = row;
				this.eventAction = action;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public delegate void TK_ViewRowChangeEventHandler(object sender, TKE.DataSet.TK_ViewRowChangeEvent e);

		[Serializable]
		[XmlSchemaProvider("GetTypedTableSchema")]
		public class tuloraDataTable : TypedTableBase<TKE.DataSet.tuloraRow>
		{
			private DataColumn columnID;

			private DataColumn columnDOLGOZO_ID;

			private DataColumn columnDATUM;

			private DataColumn columnSZOVEG;

			private DataColumn columnORA;

			private DataColumn columnSZORZO;

			[Browsable(false)]
			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int Count
			{
				get
				{
					return base.Rows.Count;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn DATUMColumn
			{
				get
				{
					return this.columnDATUM;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn DOLGOZO_IDColumn
			{
				get
				{
					return this.columnDOLGOZO_ID;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn IDColumn
			{
				get
				{
					return this.columnID;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.tuloraRow this[int index]
			{
				get
				{
					return (TKE.DataSet.tuloraRow)base.Rows[index];
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn ORAColumn
			{
				get
				{
					return this.columnORA;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn SZORZOColumn
			{
				get
				{
					return this.columnSZORZO;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn SZOVEGColumn
			{
				get
				{
					return this.columnSZOVEG;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public tuloraDataTable()
			{
				base.TableName = "tulora";
				this.BeginInit();
				this.InitClass();
				this.EndInit();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal tuloraDataTable(DataTable table)
			{
				base.TableName = table.TableName;
				if (table.CaseSensitive != table.DataSet.CaseSensitive)
				{
					base.CaseSensitive = table.CaseSensitive;
				}
				if (table.Locale.ToString() != table.DataSet.Locale.ToString())
				{
					base.Locale = table.Locale;
				}
				if (table.Namespace != table.DataSet.Namespace)
				{
					base.Namespace = table.Namespace;
				}
				base.Prefix = table.Prefix;
				base.MinimumCapacity = table.MinimumCapacity;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected tuloraDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
			{
				this.InitVars();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void AddtuloraRow(TKE.DataSet.tuloraRow row)
			{
				base.Rows.Add(row);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.tuloraRow AddtuloraRow(long DOLGOZO_ID, DateTime DATUM, string SZOVEG, decimal ORA, int SZORZO)
			{
				TKE.DataSet.tuloraRow _tuloraRow = (TKE.DataSet.tuloraRow)base.NewRow();
				object[] dOLGOZOID = new object[] { null, DOLGOZO_ID, DATUM, SZOVEG, ORA, SZORZO };
				_tuloraRow.ItemArray = dOLGOZOID;
				base.Rows.Add(_tuloraRow);
				return _tuloraRow;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public override DataTable Clone()
			{
				TKE.DataSet.tuloraDataTable _tuloraDataTable = (TKE.DataSet.tuloraDataTable)base.Clone();
				_tuloraDataTable.InitVars();
				return _tuloraDataTable;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataTable CreateInstance()
			{
				return new TKE.DataSet.tuloraDataTable();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.tuloraRow FindByID(long ID)
			{
				DataRowCollection rows = base.Rows;
				object[] d = new object[] { ID };
				return (TKE.DataSet.tuloraRow)rows.Find(d);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override Type GetRowType()
			{
				return typeof(TKE.DataSet.tuloraRow);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
			{
				XmlSchemaComplexType xmlSchemaComplexType;
				XmlSchema xmlSchema;
				XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
				XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
				TKE.DataSet dataSet = new TKE.DataSet();
				XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
				{
					Namespace = "http://www.w3.org/2001/XMLSchema",
					MinOccurs = new decimal(0),
					MaxOccurs = new decimal(-1, -1, -1, false, 0),
					ProcessContents = XmlSchemaContentProcessing.Lax
				};
				xmlSchemaSequence.Items.Add(xmlSchemaAny);
				XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny()
				{
					Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
					MinOccurs = new decimal(1),
					ProcessContents = XmlSchemaContentProcessing.Lax
				};
				xmlSchemaSequence.Items.Add(xmlSchemaAny1);
				XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute()
				{
					Name = "namespace",
					FixedValue = dataSet.Namespace
				};
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
				XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
				{
					Name = "tableTypeName",
					FixedValue = "tuloraDataTable"
				};
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
				xmlSchemaComplexType1.Particle = xmlSchemaSequence;
				XmlSchema schemaSerializable = dataSet.GetSchemaSerializable();
				if (xs.Contains(schemaSerializable.TargetNamespace))
				{
					MemoryStream memoryStream = new MemoryStream();
					MemoryStream memoryStream1 = new MemoryStream();
					try
					{
						XmlSchema current = null;
						schemaSerializable.Write(memoryStream);
						IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
						while (enumerator.MoveNext())
						{
							current = (XmlSchema)enumerator.Current;
							memoryStream1.SetLength((long)0);
							current.Write(memoryStream1);
							if (memoryStream.Length != memoryStream1.Length)
							{
								continue;
							}
							memoryStream.Position = (long)0;
							memoryStream1.Position = (long)0;
							while (memoryStream.Position != memoryStream.Length && memoryStream.ReadByte() == memoryStream1.ReadByte())
							{
							}
							if (memoryStream.Position != memoryStream.Length)
							{
								continue;
							}
							xmlSchemaComplexType = xmlSchemaComplexType1;
							return xmlSchemaComplexType;
						}
						xmlSchema = xs.Add(schemaSerializable);
						return xmlSchemaComplexType1;
					}
					finally
					{
						if (memoryStream != null)
						{
							memoryStream.Close();
						}
						if (memoryStream1 != null)
						{
							memoryStream1.Close();
						}
					}
					return xmlSchemaComplexType;
				}
				xmlSchema = xs.Add(schemaSerializable);
				return xmlSchemaComplexType1;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			private void InitClass()
			{
				this.columnID = new DataColumn("ID", typeof(long), null, MappingType.Element);
				base.Columns.Add(this.columnID);
				this.columnDOLGOZO_ID = new DataColumn("DOLGOZO_ID", typeof(long), null, MappingType.Element);
				base.Columns.Add(this.columnDOLGOZO_ID);
				this.columnDATUM = new DataColumn("DATUM", typeof(DateTime), null, MappingType.Element);
				base.Columns.Add(this.columnDATUM);
				this.columnSZOVEG = new DataColumn("SZOVEG", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnSZOVEG);
				this.columnORA = new DataColumn("ORA", typeof(decimal), null, MappingType.Element);
				base.Columns.Add(this.columnORA);
				this.columnSZORZO = new DataColumn("SZORZO", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.columnSZORZO);
				ConstraintCollection constraints = base.Constraints;
				DataColumn[] dataColumnArray = new DataColumn[] { this.columnID };
				constraints.Add(new UniqueConstraint("Constraint1", dataColumnArray, true));
				this.columnID.AutoIncrement = true;
				this.columnID.AutoIncrementSeed = (long)-1;
				this.columnID.AutoIncrementStep = (long)-1;
				this.columnID.AllowDBNull = false;
				this.columnID.ReadOnly = true;
				this.columnID.Unique = true;
				this.columnDOLGOZO_ID.AllowDBNull = false;
				this.columnDATUM.AllowDBNull = false;
				this.columnSZOVEG.MaxLength = 50;
				this.columnORA.AllowDBNull = false;
				this.columnSZORZO.AllowDBNull = false;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal void InitVars()
			{
				this.columnID = base.Columns["ID"];
				this.columnDOLGOZO_ID = base.Columns["DOLGOZO_ID"];
				this.columnDATUM = base.Columns["DATUM"];
				this.columnSZOVEG = base.Columns["SZOVEG"];
				this.columnORA = base.Columns["ORA"];
				this.columnSZORZO = base.Columns["SZORZO"];
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
			{
				return new TKE.DataSet.tuloraRow(builder);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.tuloraRow NewtuloraRow()
			{
				return (TKE.DataSet.tuloraRow)base.NewRow();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanged(DataRowChangeEventArgs e)
			{
				base.OnRowChanged(e);
				if (this.tuloraRowChanged != null)
				{
					this.tuloraRowChanged(this, new TKE.DataSet.tuloraRowChangeEvent((TKE.DataSet.tuloraRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanging(DataRowChangeEventArgs e)
			{
				base.OnRowChanging(e);
				if (this.tuloraRowChanging != null)
				{
					this.tuloraRowChanging(this, new TKE.DataSet.tuloraRowChangeEvent((TKE.DataSet.tuloraRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleted(DataRowChangeEventArgs e)
			{
				base.OnRowDeleted(e);
				if (this.tuloraRowDeleted != null)
				{
					this.tuloraRowDeleted(this, new TKE.DataSet.tuloraRowChangeEvent((TKE.DataSet.tuloraRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleting(DataRowChangeEventArgs e)
			{
				base.OnRowDeleting(e);
				if (this.tuloraRowDeleting != null)
				{
					this.tuloraRowDeleting(this, new TKE.DataSet.tuloraRowChangeEvent((TKE.DataSet.tuloraRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void RemovetuloraRow(TKE.DataSet.tuloraRow row)
			{
				base.Rows.Remove(row);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.tuloraRowChangeEventHandler tuloraRowChanged;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.tuloraRowChangeEventHandler tuloraRowChanging;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.tuloraRowChangeEventHandler tuloraRowDeleted;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event TKE.DataSet.tuloraRowChangeEventHandler tuloraRowDeleting;
		}

		public class tuloraRow : DataRow
		{
			private TKE.DataSet.tuloraDataTable tabletulora;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DateTime DATUM
			{
				get
				{
					return (DateTime)base[this.tabletulora.DATUMColumn];
				}
				set
				{
					base[this.tabletulora.DATUMColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public long DOLGOZO_ID
			{
				get
				{
					return (long)base[this.tabletulora.DOLGOZO_IDColumn];
				}
				set
				{
					base[this.tabletulora.DOLGOZO_IDColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public long ID
			{
				get
				{
					return (long)base[this.tabletulora.IDColumn];
				}
				set
				{
					base[this.tabletulora.IDColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public decimal ORA
			{
				get
				{
					return (decimal)base[this.tabletulora.ORAColumn];
				}
				set
				{
					base[this.tabletulora.ORAColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int SZORZO
			{
				get
				{
					return (int)base[this.tabletulora.SZORZOColumn];
				}
				set
				{
					base[this.tabletulora.SZORZOColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string SZOVEG
			{
				get
				{
					string item;
					try
					{
						item = (string)base[this.tabletulora.SZOVEGColumn];
					}
					catch (InvalidCastException invalidCastException)
					{
						throw new StrongTypingException("The value for column 'SZOVEG' in table 'tulora' is DBNull.", invalidCastException);
					}
					return item;
				}
				set
				{
					base[this.tabletulora.SZOVEGColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal tuloraRow(DataRowBuilder rb) : base(rb)
			{
				this.tabletulora = (TKE.DataSet.tuloraDataTable)base.Table;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public bool IsSZOVEGNull()
			{
				return base.IsNull(this.tabletulora.SZOVEGColumn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void SetSZOVEGNull()
			{
				base[this.tabletulora.SZOVEGColumn] = Convert.DBNull;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public class tuloraRowChangeEvent : EventArgs
		{
			private TKE.DataSet.tuloraRow eventRow;

			private DataRowAction eventAction;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataRowAction Action
			{
				get
				{
					return this.eventAction;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public TKE.DataSet.tuloraRow Row
			{
				get
				{
					return this.eventRow;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public tuloraRowChangeEvent(TKE.DataSet.tuloraRow row, DataRowAction action)
			{
				this.eventRow = row;
				this.eventAction = action;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public delegate void tuloraRowChangeEventHandler(object sender, TKE.DataSet.tuloraRowChangeEvent e);
	}
}