using FundooManager.Interfaces;
using FundooModels;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class LabelManager : ILabelManager
    {
        private readonly ILabelRepository repository;

        public LabelManager(ILabelRepository userRepository)
        {
            this.repository = userRepository;
        }

        public bool AddLabel(LabelModel model)
        {
            try
            {
                bool result = this.repository.AddLabel(model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UpdateLabel(LabelModel model)
        {
            try
            {
                string result = this.repository.UpdateLabel(model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool RemoveLabel(int labelId)
        {
            try
            {
                bool result = this.repository.RemoveLabel(labelId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<LabelModel> GetLabel(int noteId)
        {
            try
            {
                IEnumerable<LabelModel> lables = this.repository.GetLabel(noteId);
                return lables;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public LabelModel GetLabelbyId(int userId)
        {
            try
            {
                LabelModel labels = this.repository.GetLabelbyId(userId);
                return labels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
