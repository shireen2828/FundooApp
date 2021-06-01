using FundooManager.Interfaces;
using FundooModels;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class CollaboratorManager : ICollaboratorManager
    {
        private readonly ICollaboratorRepository repository;

        public CollaboratorManager(ICollaboratorRepository userRepository)
        {
            this.repository = userRepository;
        }

        public bool AddCollaborator(CollaboratorModel model)
        {
            try
            {
                bool result = this.repository.AddCollaborator(model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteCollaborator(int collaboratorId)
        {
            try
            {
                bool result = this.repository.DeleteCollaborator(collaboratorId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CollaboratorModel> GetCollaborator(int noteId)
        {
            try
            {
                IEnumerable<CollaboratorModel> notes = this.repository.GetCollaborator(noteId);
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
