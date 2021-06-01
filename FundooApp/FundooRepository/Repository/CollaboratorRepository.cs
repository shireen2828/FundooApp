// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Shireen kk"/>
//---------------------------------------------------------------------------------------

namespace FundooRepository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FundooModels;
    using FundooRepository.Context;
    using FundooRepository.Interface;
    using Microsoft.Extensions.Configuration;
    
    /// <summary>
    /// class for Collaborator Repository
    /// </summary>
    public class CollaboratorRepository : ICollaboratorRepository
    {
        /// <summary>
        /// private method for user context
        /// </summary>
        private UserContext userContext;

        /// <summary>
        /// method for collaborator repository
        /// </summary>
        /// <param name="userContext"></usercontext>
        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// method for add collaborator
        /// </summary>
        /// <param name="model"></model>
        /// <returns></returns>
        public bool AddCollaborator(CollaboratorModel model)
        {
            try
            {
                if (model != null)
                {
                    this.userContext.CollaboratorModels.Add(model);
                    this.userContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for delete collaborator
        /// </summary>
        /// <param name="collaboratorId"></collaborator Id>
        /// <returns></returns>
        public bool DeleteCollaborator(int collaboratorId)
        {
            try
            {
                if (collaboratorId > 0)
                {
                    var collaborator = this.userContext.CollaboratorModels.Where(x => x.CollaboratorId == collaboratorId).SingleOrDefault();
                    this.userContext.CollaboratorModels.Remove(collaborator);
                    this.userContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for get collaborator
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <returns></returns>
        public IEnumerable<CollaboratorModel> GetCollaborator(int noteId)
        {
            try
            {
                IEnumerable<CollaboratorModel> result;
                IEnumerable<CollaboratorModel> notes = this.userContext.CollaboratorModels.Where(x => x.NoteId == noteId);
                if (notes != null)
                {
                    result = notes;
                }
                else
                {
                    result = null;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}