﻿ 
namespace SF.Entitys.Abstraction
{
    using System;

#if !NET20

    /// <summary>
    /// Represents an entity that has an unique identifier, updated metadata and version info, 
    /// using a byte[] for the <see cref="IHaveVersion{T}.Version"/>.
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    /// <typeparam name="TUpdatedBy">The updated by type</typeparam>
    public abstract class EntityWithUpdatedMetaAndVersionAsByteArray<TIdentity, TUpdatedBy>
        : EntityWithTypedId<TIdentity>, IHaveUpdatedMeta<TUpdatedBy>, IHaveVersionAsByteArray
    {
        private DateTimeOffset _updatedOn;
        
        #region Implementation of IHaveUpdatedMeta<TUpdatedBy>

        /// <summary>
        /// The <see cref="DateTimeOffset"/> when it was last updated
        /// </summary>
        public virtual DateTimeOffset UpdatedOn
        {
            get { return _updatedOn; }
            set { _updatedOn = value; }
        }

        /// <summary>
        /// The identifier (or entity) which last updated this entity
        /// </summary>
        public virtual TUpdatedBy UpdatedBy { get; set; }

        #endregion

        #region Implementation of IHaveVersionAsByteArray

        /// <summary>
        /// The entity version
        /// </summary>
        public virtual byte[] Version { get; set; }

        #endregion

        /// <summary>
        /// Creates a new instance and sets the <see cref="UpdatedOn"/> 
        /// to <see cref="DateTimeOffset.Now"/>
        /// </summary>
        protected EntityWithUpdatedMetaAndVersionAsByteArray()
        {
            _updatedOn = DateTimeOffset.Now;
        }

        /// <summary>
        /// Creates a new instance and sets the <see cref="UpdatedOn"/> 
        /// to <see cref="DateTimeOffset.Now"/>
        /// </summary>
        /// <param name="id">The entity id</param>
        protected EntityWithUpdatedMetaAndVersionAsByteArray(TIdentity id) : base(id)
        {
            _updatedOn = DateTimeOffset.Now;
        }
    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated, deleted metadata and version info, 
    /// using a byte[] for the <see cref="IHaveVersion{T}.Version"/> and a <see cref="string"/> as an 
    /// identifier for the <see cref="IHaveCreatedMeta{T}.CreatedBy"/>,
    /// and <see cref="IHaveUpdatedMeta{T}.UpdatedBy"/>
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    public abstract class EntityWithUpdatedMetaAndVersionAsByteArray<TIdentity>
        : EntityWithUpdatedMetaAndVersionAsByteArray<TIdentity, string>, IHaveUpdatedMeta
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithUpdatedMetaAndVersionAsByteArray()
        {
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The entity id</param>
        protected EntityWithUpdatedMetaAndVersionAsByteArray(TIdentity id) : base(id)
        {
        }
    }

#endif
}
