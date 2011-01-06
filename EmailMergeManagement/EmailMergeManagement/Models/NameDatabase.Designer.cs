﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace EmailMergeManagement.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class namesEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new namesEntities object using the connection string found in the 'namesEntities' section of the application configuration file.
        /// </summary>
        public namesEntities() : base("name=namesEntities", "namesEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new namesEntities object.
        /// </summary>
        public namesEntities(string connectionString) : base(connectionString, "namesEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new namesEntities object.
        /// </summary>
        public namesEntities(EntityConnection connection) : base(connection, "namesEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<PersonName> PersonNames
        {
            get
            {
                if ((_PersonNames == null))
                {
                    _PersonNames = base.CreateObjectSet<PersonName>("PersonNames");
                }
                return _PersonNames;
            }
        }
        private ObjectSet<PersonName> _PersonNames;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the PersonNames EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPersonNames(PersonName personName)
        {
            base.AddObject("PersonNames", personName);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="namesModel", Name="PersonName")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class PersonName : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new PersonName object.
        /// </summary>
        /// <param name="nameId">Initial value of the NameId property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="sexOf">Initial value of the SexOf property.</param>
        /// <param name="surname">Initial value of the Surname property.</param>
        public static PersonName CreatePersonName(global::System.Guid nameId, global::System.String name, global::System.String sexOf, global::System.Boolean surname)
        {
            PersonName personName = new PersonName();
            personName.NameId = nameId;
            personName.Name = name;
            personName.SexOf = sexOf;
            personName.Surname = surname;
            return personName;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid NameId
        {
            get
            {
                return _NameId;
            }
            set
            {
                if (_NameId != value)
                {
                    OnNameIdChanging(value);
                    ReportPropertyChanging("NameId");
                    _NameId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("NameId");
                    OnNameIdChanged();
                }
            }
        }
        private global::System.Guid _NameId;
        partial void OnNameIdChanging(global::System.Guid value);
        partial void OnNameIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String SexOf
        {
            get
            {
                return _SexOf;
            }
            set
            {
                OnSexOfChanging(value);
                ReportPropertyChanging("SexOf");
                _SexOf = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("SexOf");
                OnSexOfChanged();
            }
        }
        private global::System.String _SexOf;
        partial void OnSexOfChanging(global::System.String value);
        partial void OnSexOfChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean Surname
        {
            get
            {
                return _Surname;
            }
            set
            {
                OnSurnameChanging(value);
                ReportPropertyChanging("Surname");
                _Surname = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Surname");
                OnSurnameChanged();
            }
        }
        private global::System.Boolean _Surname;
        partial void OnSurnameChanging(global::System.Boolean value);
        partial void OnSurnameChanged();

        #endregion
    
    }

    #endregion
    
}
