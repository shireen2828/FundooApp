// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelRepository.cs" company="Bridgelabz">
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
    using Microsoft.EntityFrameworkCore;
    
    /// <summary>
    /// class for Label Repository
    /// </summary>
    public class LabelRepository : ILabelRepository
    {
        /// <summary>
        /// private method for user context 
        /// </summary>
        private UserContext userContext;

        /// <summary>
        /// constructor for label repository
        /// </summary>
        /// <param name="userContext"></user context>
        public LabelRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// methhod for add label
        /// </summary>
        /// <param name="model"></model>
        /// <returns></returns>
        public bool AddLabel(LabelModel model)
        {
            try
            {
                if (model != null)
                {
                    this.userContext.LabelModels.Add(model);
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
        /// method for update label
        /// </summary>
        /// <param name="model"></model>
        /// <returns></returns>
        public string UpdateLabel(LabelModel model)
        {
            try
            {
                if (model.NoteId != 0)
                {
                    this.userContext.Entry(model).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    return "UPDATE SUCCESSFULL";
                }

                return "Updation Failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for remove label
        /// </summary>
        /// <param name="labelId"></labelId>
        /// <returns></returns>
        public bool RemoveLabel(int labelId)
        {
            try
            {
                var label = this.userContext.LabelModels.Where(x => x.LabelId == labelId).SingleOrDefault();
                if (label != null)
                {
                    this.userContext.LabelModels.Remove(label);
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
        /// method for get label
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <returns></returns>
        public IEnumerable<LabelModel> GetLabel(int noteId)
        {
            try
            {
                IEnumerable<LabelModel> result;
                IEnumerable<LabelModel> labels = this.userContext.LabelModels.Where(x => x.NoteId == noteId);
                if (labels != null)
                {
                    result = labels;
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

        /// <summary>
        /// method for get label
        /// </summary>
        /// <param name="userId"></userId>
        /// <returns></returns>
        public LabelModel GetLabelbyId(int userId)
        {
            try
            {
                if (userId > 0)
                {
                    LabelModel labels = this.userContext.LabelModels.Where(x => x.UserId == userId).SingleOrDefault();
                    return labels;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
