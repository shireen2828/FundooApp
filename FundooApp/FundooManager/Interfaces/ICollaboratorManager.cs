// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratormanager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Shireen kk"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooManager.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooModels;

    /// <summary>
    /// class for  ICollaboratorManager 
    /// </summary>
    public interface ICollaboratorManager
    {
        /// <summary>
        /// initialization of method for add collaborator
        /// </summary>
        /// <param name="model"></model>
        /// <returns></returns>
        public bool AddCollaborator(CollaboratorModel model);

        /// <summary>
        ///  initialization of method for delete collaborator
        /// </summary>
        /// <param name="collaboratorId"></collaboratorId>
        /// <returns></returns>
        public bool DeleteCollaborator(int collaboratorId);

        /// <summary>
        ///  initialization of method for get collaborator
        /// </summary>
        /// <param name="userId"></userId>
        /// <returns></returns>
        public IEnumerable<CollaboratorModel> GetCollaborator(int userId);
    }
}
